import React from "react";
import { useSelector } from "react-redux";
import { selectToken } from "../features/auth/authSlice";
import { useGetUserTestsQuery } from "../features/tests/testApiSlice";
import { Col, Row } from "react-bootstrap";
import Container from "react-bootstrap/Container";
import TestList from "../features/tests/TestList";

const HomePage = () => {
  const token = useSelector(selectToken);

  const { data: tests, isSuccess, isLoading } = useGetUserTestsQuery(token);

  let content;
  if (isLoading) {
    content = <p>Loading..</p>;
  } else if (isSuccess) {
    content = (
      <Row>
        <Col>
          <TestList tests={tests} />
        </Col>
      </Row>
    );
  }

  return (
    <div className="HomePage">
      <Container>{content}</Container>
    </div>
  );
};

export default HomePage;
