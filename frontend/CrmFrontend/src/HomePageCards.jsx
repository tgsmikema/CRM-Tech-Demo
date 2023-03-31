import * as React from 'react';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import { Container, Stack, Card } from '@mui/material';
import Typography from '@mui/material/Typography';
import CRM_Card from './assets/CRM_Card.jpg'

const buttonMargin = {
    marginRight: "20px",
    marginTop: "10px",
    width: 180,
}

export default function HomePageCards() {
  return (
    <div style={{margin: '4%'}}>
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
                <Button variant="contained" color="primary" size="large" sx={buttonMargin}>Login</Button>
                <Button variant="contained" color="secondary" size="large" sx={buttonMargin}>Register</Button>
                <Button variant="contained" color="secondary" size="large" sx={{...buttonMargin, backgroundColor: "green"}}>Admin Register</Button>
            </Container>
      </CardContent>
    </Card>
    </div>
  );
}