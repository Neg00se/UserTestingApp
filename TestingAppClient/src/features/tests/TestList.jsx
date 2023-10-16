import React from "react";
import Test from "./Test";
import { Row } from "react-bootstrap";

const TestList = ({ tests }) => {
  return (
    <Row>
      {tests.ids.map((id) => (
        <Test key={id} testId={id} />
      ))}
    </Row>
  );
};

export default TestList;
