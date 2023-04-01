import React, { useState } from 'react';
import { Button, TextField, Grid, Typography, Box } from '@mui/material';

export default function RegisterError() {
    return (
        <Box mt={3} mb={3} display="flex"
            justifyContent="center"
            alignItems="center">
            <Typography variant="h6" align="center" sx={{color: "red"}}>Username is Not available, or you don't have permission to do this.</Typography>
        </Box>

    )
}