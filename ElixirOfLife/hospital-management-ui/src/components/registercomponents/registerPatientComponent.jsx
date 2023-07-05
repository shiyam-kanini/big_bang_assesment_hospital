import React, { useState} from 'react';
import { registerPatient } from 'E:/big_bang_assesment_hospital/ElixirOfLife/hospital-management-ui/src/services/registerService';
import { Modal,Typography, Stack, FormControl, InputLabel,Select,MenuItem, TextField  } from '@mui/material';
import { Navigate } from 'react-router-dom';
import useAuth from '../auth/authContext';
const height = window.screen.height - 150;
const width = window.screen.width ;


const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  boxShadow: 24,
  p: 4,
  backgroundColor : 'rgba(180,180,180,.8)',
};

const PatientRegistration = () => {
  const auth = useAuth()
  const [patientData, setPatientData] = useState({
    patientName: '',
    gender: '',
    password: ''
  });

  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);
  const [responseModal, setResponseModal] = useState(false);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setPatientData({ ...patientData, [name]: value });
  };
  

  const handleOpen = () => {
    setResponseModal(true);
  };

  const handleClose = () => {
    setResponseModal(false);
  };

  const handleSubmit = async(event) => {
    event.preventDefault();
    try {
        const response = await registerPatient(patientData);
        setResponse(response);
        setError(null);
    } catch (error) {
      setResponse(null);
      setError(error);
    }
    handleOpen();
  };

  return (
    !auth.loginLog.isLoggedIn ?

    <div style={{height:`${height}px`}} className='bg' >
      <div style={{position:'relative',top:'20%'}}>
        <form className="card border-primary text-dark" style={{width:'35%', backgroundColor:'rgba(200,200,200,.1)', transform:'translateX(20%)'}} onSubmit={handleSubmit}>
        <div className="card-body" >
        <h3 className="card-title text-center">Patient Registration</h3>
            <TextField
                id="name"
                label="Patient Name"
                type="text"
                className="form-control"
                name="patientName"
                value={patientData.employeeFirstName}
                onChange={handleInputChange}
                autoComplete="off"
                style={{backgroundColor:'rgba(255,255,255,.1)'}}
                required
              />
            <FormControl fullWidth>
                <InputLabel id="demo-simple-select-label">Gender</InputLabel>
              <Select
                labelId="demo-simple-select-label"
                value={patientData.gender}
                label="gender"
                onChange={handleInputChange}
                required
                name='gender'
                >
                <MenuItem value={'Male'}>Male</MenuItem>
                <MenuItem value={'Female'}>Female</MenuItem>
              </Select>
            </FormControl>
            <br />
            <TextField
              id="password"
              label="Password"
                type="password"
                className="form-control"
                name="password"
                value={patientData.employeeFirstName}
                onChange={handleInputChange}
                autoComplete="off"
                style={{backgroundColor:'rgba(255,255,255,.1)'}}
                required
              />
        </div>
        <div className="card-footer text-center">
          <button type="submit" className="btn btn-outline-primary">
            Register
          </button>
        </div>
      </form>
      </div>
      <Modal
          open={responseModal}
          onClose={handleClose}
          aria-labelledby="text-response-message"
          aria-describedby="text-response-token"
        >
          <Stack alignItems="center" justifyContent="space-evenly" sx={style} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {response ? response.message : ''}
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
            <button className="btn btn-outline-success" onClick={handleClose}>
              Proceed
            </button>
          </Stack>
        </Modal>
    </div>
    :
    <Navigate to={'/'} replace />    

  );
};

export default PatientRegistration;
