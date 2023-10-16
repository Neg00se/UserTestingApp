import { useState } from "react";
import { Route, Routes } from "react-router-dom";
import Layout from "./components/Layout";
import Login from "./features/auth/Login";
import "bootstrap/dist/css/bootstrap.min.css";
import HomePage from "./pages/HomePage";
import Test from "./features/tests/Test";
import TestPage from "./pages/TestPage";
import RequireAuth from "./features/auth/RequireAuth";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route path="login" element={<Login />} />
        <Route element={<RequireAuth />}>
          <Route index element={<HomePage />} />
          <Route path="test/:testId" element={<TestPage />} />
        </Route>
      </Route>
    </Routes>
  );
}

export default App;
