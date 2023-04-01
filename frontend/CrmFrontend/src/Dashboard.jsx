import React, { useState, useContext } from 'react';
import { Button, TextField, Grid, Typography, Box, Container } from '@mui/material';
import { AppContext } from './AppContextProvider';
import { Outlet, useNavigate } from 'react-router-dom';

export default function Dashboard(){

    const navigate = useNavigate();

    const { login, clearLogin } = useContext(AppContext);

    const handleLogout = () => {
        clearLogin();
        navigate("/");
    }

    const handleRegisterAdmin = () => {
        navigate("registerAdmin");
    }

    const handleAddNewCustomer = () => {
        navigate("addNewCustomer");
    }

    const handleListCustomers = () => {
        navigate("listCustomers");
    }

    return (
        <>
        <Container sx={{
            display: 'flex',
            flexDirection: "row",
            justifyContent: "space-around",
            alignItems: "center",
        }}>
        <Typography  variant="h5" align="center">{`Hi ${login.firstName}, You are logged in as an `} <strong>{login.userType}</strong></Typography>
        <Button onClick={handleAddNewCustomer}>Add New Customer</Button>
        <Button onClick={handleListCustomers}>Customers List</Button>
        <Button variant="contained" onClick={handleRegisterAdmin}>Register Admin Account</Button>
        <Button variant="contained" color="secondary" size="medium" onClick={handleLogout}>Logout</Button>
        </Container>
        <Outlet />
        </>
    )
}