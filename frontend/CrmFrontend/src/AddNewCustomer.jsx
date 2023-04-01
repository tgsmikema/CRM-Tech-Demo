import React, { useState, useContext } from 'react';
import { Button, TextField, Grid, Typography, Box } from '@mui/material';
import axios from "axios";
import { Outlet, useNavigate } from 'react-router-dom';
import { AppContext } from './AppContextProvider';

const AddNewCustomer = () => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [emailAddress, setEmailAddress] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [description, setDescription] = useState('');

    const { login } = useContext(AppContext);

    const navigate = useNavigate();

    const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || "";

    const handleSubmit = (e) => {
        e.preventDefault();

        const customerData = {
            firstName: firstName,
            lastName: lastName,
            emailAddress: emailAddress,
            description: description,
            phoneNumber: phoneNumber,
            createdByUserId : login.id,
        }

        axios.post(`${API_BASE_URL}/api/addNewCustomer`, customerData, {
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
                navigate("success", { replace: true });
            })
            .catch(function (error) {
                console.log(error);
                navigate("error", { replace: true });
            });

    }


    return (
        <>
            <Grid container spacing={2} justifyContent="center" sx={{
                marginTop: "100px"
            }}>
                <Grid item xs={12} sm={8} md={6} lg={4}>
                    <Box mt={3} mb={3}>
                        <Typography variant="h3" align="center">
                            Add A New Customer
                        </Typography>
                    </Box>
                    <form onSubmit={handleSubmit}>
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <TextField type="text" required fullWidth label="First Name" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="text" required fullWidth label="Last Name" value={lastName} onChange={(e) => setLastName(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="text" required fullWidth label="Email Address" value={emailAddress} onChange={(e) => setEmailAddress(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="text" fullWidth label="Phone Number" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <TextField type="text" fullWidth label="Description" value={description} onChange={(e) => setDescription(e.target.value)} />
                            </Grid>
                            <Grid item xs={12}>
                                <Button type="submit" variant="contained" color="primary" fullWidth>Add New Customer</Button>
                            </Grid>
                        </Grid>
                    </form>
                </Grid>
            </Grid>
            <Outlet />
        </>
    );
};

export default AddNewCustomer;
