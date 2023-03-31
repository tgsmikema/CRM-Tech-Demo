import * as React from 'react';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import { Container, Stack, Card } from '@mui/material';
import CRM_Card from './assets/CRM_Card.jpg'
import { useNavigate } from 'react-router-dom';

const buttonMargin = {
    marginRight: "20px",
    marginTop: "10px",
    width: 180,
}

export default function HomePageCards() {

    const navigate = useNavigate();

    return (
        <div style={{ margin: '4%' }}>
            <Card sx={{ maxWidth: 1000 }}>
                <CardMedia
                    component="img"
                    height="500"
                    image={CRM_Card}
                    alt="CRM"
                />
                <CardContent>
                    <Container maxWidth="false" sx={{
                        display: 'flex',
                        flexDirection: "row",
                        justifyContent: "space-around",
                    }}>
                        <Button onClick={() => navigate("/login")} variant="contained" color="primary" size="large" sx={buttonMargin}>Login</Button>
                        <Button variant="contained" color="secondary" size="large" sx={buttonMargin}>Register</Button>
                        <Button variant="contained" color="secondary" size="large" sx={{ ...buttonMargin, backgroundColor: "green" }}>Admin Register</Button>
                    </Container>
                </CardContent>
            </Card>
        </div>
    );
}