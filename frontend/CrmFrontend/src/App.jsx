import React, { useState } from 'react';
import { Routes, Route, useNavigate, useParams, Navigate, Link } from 'react-router-dom';
import './App.css';
import HomePage from "./HomePage";
import LoginPage from './LoginPage';
import LoginError from './LoginError';
import Dashboard from './Dashboard';
import RegisterPage from './RegisterPage';
import RegisterError from './RegisterError';
import AddNewCustomer from "./AddNewCustomer";
import SuccessMessage from './SuccessMessage';
import GeneralError from './GeneralError';
import CustomerList from './CustomerList';

function App() {

  return (
    <Routes>
      <Route path="/" element={undefined}>
        <Route index element={<Navigate to="home" />} />
        <Route path="home" element={<HomePage />} />
        <Route path="login" element={<LoginPage />} >
          <Route path="error" element={<LoginError />} />
        </Route>
        <Route path="registerUser" element={<RegisterPage userType={`user`}/>}>
          <Route path="error" element={<RegisterError />} />
        </Route>
        <Route path="dashboard" element={<Dashboard />} >
          <Route index element={<Navigate to="listCustomers"></Navigate>} />
          <Route path="registerAdmin" element={<RegisterPage userType={`admin`}/>}>
            <Route path="error" element={<RegisterError />} />
          </Route>
          <Route path="addNewCustomer" element={<AddNewCustomer />}>
            <Route path="success" element={<SuccessMessage />} />
            <Route path="error" element={<GeneralError />} />
          </Route>
          <Route path="listCustomers" element={<CustomerList />}>
            <Route path="success" element={<SuccessMessage />} />
            <Route path="error" element={<GeneralError />} />
          </Route>
        </Route>
      </Route>
    </Routes>
  )
}

export default App
