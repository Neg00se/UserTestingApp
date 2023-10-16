import React, { useState } from "react";
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { selectToken } from "../features/auth/authSlice";
import { useGetUserTestsQuery } from "../features/tests/testApiSlice";
import { Container, Col } from "react-bootstrap";
import Questions from "../components/Questions";

const TestPage = () => {
  const { testId } = useParams();
  const token = useSelector(selectToken);

  const [questionId, setQuestionId] = useState();
  const [answer, setAnswer] = useState({});

  const { test } = useGetUserTestsQuery(token, {
    selectFromResult: ({ data }) => ({
      test: data?.entities[testId],
    }),
  });

  let questions = test.questions.map((id) => (
    <Questions key={id} question={test.questions[id]} />
  ));

  return (
    <Container>
      <h2>{test.title}</h2>

      <Col>{test.completed ? test.mark : questions}</Col>
    </Container>
  );
};

export default TestPage;
