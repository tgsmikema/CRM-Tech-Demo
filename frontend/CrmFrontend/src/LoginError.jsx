import React, { useState } from 'react';
import { Button, TextField, Grid, Typography, Box } from '@mui/material';

export default function LoginError() {
    return (
        <Box mt={3} mb={3} display="flex"
            justifyContent="center"
            alignItems="center">
            <Typography variant="h6" align="center" sx={{color: "red"}}>Login Error, Please Try Again!</Typography>
        </Box>

    )
}