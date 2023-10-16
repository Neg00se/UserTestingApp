import React, { useState } from "react";
import Container from "react-bootstrap/Container";
import { Col, Row, Form, Button, Alert } from "react-bootstrap";
import { useLoginMutation } from "./authApiSlice";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const navigate = useNavigate();

  const [login, { isLoading, isError, error }] = useLoginMutation();

  const [username, setUserName] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await login({ username, password }).unwrap();
      navigate("/");
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <Container className="align-middle">
      <Row className="justify-content-center">
        <Col md={3}>
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3" controlId="formBasicUsername">
              <Form.Label>Username</Form.Label>
              <Form.Control
                value={username}
                onChange={(e) => setUserName(e.target.value)}
                type="text"
                placeholder="Enter username"
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Password</Form.Label>
              <Form.Control
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                type="password"
                placeholder="Password"
              />
            </Form.Group>
            {isError && <Alert variant="danger">{error.data}</Alert>}

            <Button className="w-100" variant="primary" type="submit">
              Login
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default Login;
