import React, { useState } from 'react';
import { Button, TextField, Grid, Typography, Box } from '@mui/material';

export default function SuccessMessage() {
    return (
        <Box mt={3} mb={3} display="flex"
            justifyContent="center"
            alignItems="center">
            <Typography variant="h6" align="center" sx={{color: "green"}}>Success!</Typography>
        </Box>

    )
}