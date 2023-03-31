import React, { useState } from 'react';
import { Button, TextField, Grid, Typography, Box } from '@mui/material';
import axios from "axios";

const LoginPage = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        axios({
            method:'get',
            url: `https://localhost:8080/api/login`,
            auth: {
                username: userName,
                password: password
            }
        })
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }


        return (
            <Grid container spacing={2} justifyContent="center">
                <Grid item xs={12} sm={8} md={6} lg={4}>
                    <Box mt={3} mb={3}>
                        <Typography variant="h3" align="center">
                            Login
                        </Typography>
                    </Box>
                    <form onSubmit={handleSubmit}>
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <TextField type="text" required fullWidth label="Username" value={userName} onChange={(e) => setUserName(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="password" required fullWidth label="Password" value={password} onChange={(e) => setPassword(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <Button type="submit" variant="contained" color="primary" fullWidth>Login</Button>
                            </Grid>
                        </Grid>
                    </form>
                </Grid>
            </Grid>
        );
    };

    export default LoginPage;