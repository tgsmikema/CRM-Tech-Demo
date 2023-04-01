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


    return (
        <>
        <Container>
        <Button onClick={handleLogout}>{login.userName + login.password}</Button>
        <Button onClick={handleRegisterAdmin}>Register Admin Account</Button>
        </Container>
        <Outlet />
        </>
    )
}