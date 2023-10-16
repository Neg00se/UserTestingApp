import React from "react";

const Questions = ({ question }) => {
  let answerOption = question.answerOptions.map(
    (id) => question.answerOptions[id]
  );

  return (
    <div>
      <h3>question.questionText</h3>
      <p>{answerOption}</p>
    </div>
  );
};

export default Questions;
