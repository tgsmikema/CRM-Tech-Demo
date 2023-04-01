import React, { useState, useContext } from 'react';
import { Button, TextField, Grid, Typography, Box } from '@mui/material';
import axios from "axios";
import { Outlet, useNavigate } from 'react-router-dom';
import { AppContext } from './AppContextProvider';

const RegisterPage = ({ userType }) => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');

    const navigate = useNavigate();

    const { login } = useContext(AppContext);

    const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || "";


    const handleSubmitUser = (e) => {
        e.preventDefault();

        const userData = {
            userName: userName,
            password: password,
            firstName: firstName,
            lastName: lastName,
        }

        axios.post(`${API_BASE_URL}/api/registerUser`, userData, {
            headers: {
                'Content-Type': 'application/json',
                accept: 'text/plain', // If you receieve JSON response.
            }
        })
        .then((response) => {
            console.log(response.data);
            navigate("/", {replace: true});
        })
        .catch(function (error) {
           navigate("error", {replace: true});
        });
    }

    const handleSubmitAdmin = (e) => {
        e.preventDefault();

        const userData = {
            userName: userName,
            password: password,
            firstName: firstName,
            lastName: lastName,
        }

        axios.post(`${API_BASE_URL}/api/registerAdmin`, userData, {
            headers: {
                'Content-Type': 'application/json',
                accept: 'text/plain', // If you receieve JSON response.
            },
            auth: {
                username: login.userName,
                password: login.password
            }
        })
        .then((response) => {
            console.log(response.data);
            navigate("/dashboard", {replace: true});
        })
        .catch(function (error) {
            navigate("error", {replace: true});
        });
    }


        return (
            <>
            <Grid container spacing={2} justifyContent="center">
                <Grid item xs={12} sm={8} md={6} lg={4}>
                    <Box mt={3} mb={3}>
                        <Typography variant="h3" align="center">
                            {userType === "admin" ? "Register an Admin" : "Register an User"}
                        </Typography>
                    </Box>
                    <form onSubmit={userType === "user" ? handleSubmitUser : handleSubmitAdmin}>
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <TextField type="text" required fullWidth label="Username" value={userName} onChange={(e) => setUserName(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="password" required fullWidth label="Password" value={password} onChange={(e) => setPassword(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="text" required fullWidth label="First Name" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="text" required fullWidth label="Last Name" value={lastName} onChange={(e) => setLastName(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <Button type="submit" variant="contained" color="primary" fullWidth>Submit</Button>
                            </Grid>
                        </Grid>
                    </form>
                </Grid>
            </Grid>
            <Outlet />
            </>
        );
    };

    export default RegisterPage;
