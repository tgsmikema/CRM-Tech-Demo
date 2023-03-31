import React, { useState } from 'react';
import { Routes, Route, useNavigate, useParams, Navigate } from 'react-router-dom';
import Button from '@mui/material/Button';
import { Container, Stack, Card } from '@mui/material';
import HomePageCards from './HomePageCards';

export default function HomePage() {
    return (
        <Stack spacing={2}>
            <Container maxWidth="false" sx={{
                display: 'flex',
                flexDirection: "row",
                justifyContent: "center",
            }}>
                <HomePageCards />
            </Container>
        </Stack>
    )
}