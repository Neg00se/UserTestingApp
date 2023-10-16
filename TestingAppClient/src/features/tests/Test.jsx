import React from "react";
import { useGetUserTestsQuery } from "./testApiSlice";
import { useSelector } from "react-redux";
import { selectToken } from "../auth/authSlice";
import { Col, Row } from "react-bootstrap";
import { Link } from "react-router-dom";

const Test = ({ testId }) => {
  const token = useSelector(selectToken);

  const { test } = useGetUserTestsQuery(token, {
    selectFromResult: ({ data }) => ({
      test: data?.entities[testId],
    }),
  });

  return (
    <Row className="border rounded my-1">
      <Col as={Link} to={`/test/${test.id}`}>
        <h1>{test.title}</h1>
        {test.completed ? <p>completed</p> : <p>not completed</p>}
      </Col>
      <Col md={2}>
        {test.completed && <p>Mark</p>}
        {test.mark && <p>{test.mark}</p>}
      </Col>
    </Row>
  );
};

export default Test;
