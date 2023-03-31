import React, { useState } from 'react';
import { Routes, Route, useNavigate, useParams, Navigate } from 'react-router-dom';
import './App.css';
import Button from '@mui/material/Button';
import HomePage from "./HomePage";

function App() {

  return (
    <Routes>
      <Route path="/" element={<HomePage />}>
        <Route path="login" element={undefined} />
      </Route>
    </Routes>
  )
}

export default App
