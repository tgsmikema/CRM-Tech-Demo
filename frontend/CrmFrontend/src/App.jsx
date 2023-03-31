import React, { useState } from 'react';
import { Routes, Route, useNavigate, useParams, Navigate } from 'react-router-dom';
import './App.css';
import HomePage from "./HomePage";
import LoginPage from './LoginPage';

function App() {

  return (
    <Routes>
      <Route path="/" element={undefined}>
        <Route index element={<Navigate to="home" />} />
        <Route path="home" element={<HomePage />} />
        <Route path="login" element={<LoginPage />} />
        <Route path="dashboard" element={undefined} />
      </Route>
    </Routes>
  )
}

export default App
