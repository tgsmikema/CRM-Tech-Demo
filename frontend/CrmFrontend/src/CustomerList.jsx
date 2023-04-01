import React, { useContext, useEffect, useState } from 'react';
import { Box, Container, Typography , TextField, Button} from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import { AppContext } from './AppContextProvider';
import axios from 'axios';
import { Outlet, useNavigate } from 'react-router-dom';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || '';

const columns = [
    { field: 'id', headerName: 'ID', type: "number", width: 40 },
    { field: 'firstName', headerName: 'First name', width: 100 },
    { field: 'lastName', headerName: 'Last name', width: 100 },
    { field: 'emailAddress', headerName: 'Email', width: 170 },
    { field: 'phoneNumber', headerName: 'Phone', width: 130 },
    { field: 'description', headerName: 'Description', width: 250 },
    { field: 'createdDateAndTime', headerName: 'Created Time', width: 220 },
    { field: 'createdByUserId', headerName: 'Created By User Id', type: "number", width: 130 },
];

export default function CustomerList() {

    const navigate = useNavigate();

    const { login } = useContext(AppContext);

    const [rows, setRows] = useState([]);

    const [customerId, setCustomerId] = useState(0);

    const listCustomerUrl = `${API_BASE_URL}/api/allCustomers`;

    const handleSubmit = (e) => {
        e.preventDefault();
        setRows((current) =>
            current.filter(customer => customer.id !== parseInt(customerId))
        );
        
        axios.get(`${API_BASE_URL}/api/deleteCustomer?customerId=${customerId}`, {
            auth: {
                username: login.userName,
                password: login.password
            }
        })
        .then((response) => {
            console.log(response.data);
            navigate("success", {replace: true});
        })
        .catch(function (error) {
            console.log(error);
           navigate("error", {replace: true});
        });
    }

    useEffect(() => {
        axios.get(listCustomerUrl, {
            auth: {
                username: login.userName,
                password: login.password
            }
        })
            .then(
                response => {
                    //console.log(response.data)
                    setRows(response.data)
                })
            .catch(function (error) {
                console.log(error);
            });;
    }, [listCustomerUrl]);

    return (
        <Container sx={{
            display: 'flex',
            flexDirection: "column",
            alignItems: "center",
            marginTop: "50px"
        }}>
            <Typography variant="h6" align="center">
                {`Hi ${login.userType}, `}
                {login.userType === "admin" ? "you can view all customers in the database." : "you can only view customers that was added by you."}
            </Typography>
            <div style={{ height: 600, width: '100%', marginTop: "30px" }}>
                <DataGrid
                    rows={rows}
                    columns={columns}
                    pageSize={5}
                    rowsPerPageOptions={[5]}
                    //checkboxSelection
                    disableRowSelectionOnClick
                />
            </div>
            <Container sx={{
                display: 'flex',
                flexDirection: "row",
                alignItems: "center",
                justifyContent: "center",
                marginTop: "50px"
            }}>
                <Typography variant="h6" align="center">Delete a Customer by customer id: </Typography>
                <form onSubmit={handleSubmit}>
                    <TextField type="number" required value={customerId} onChange={(e) => setCustomerId(e.target.value)} sx={{
                        marginLeft: "20px",
                        marginRight: "20px",
                    }} />
                    <Button type="submit" variant="contained" color="primary" sx={{height: "56px", width: "200px", backgroundColor:"darkred"}}>Delete</Button>
                </form>
            </Container>
            <Outlet />


        </Container>
    )
}