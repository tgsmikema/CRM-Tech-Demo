import React, { useState, useContext } from 'react';
import { Button, TextField, Grid, Typography, Box } from '@mui/material';
import { AppContext } from './AppContextProvider';
import { Outlet, useNavigate } from 'react-router-dom';

export default function Dashboard(){

    const navigate = useNavigate();

    const handleLogout = () => {
        clearLogin();
        navigate("/");
    }

    const { login, clearLogin } = useContext(AppContext);

    return (
        <Button onClick={handleLogout}>{login.userName + login.password}</Button>
    )
}