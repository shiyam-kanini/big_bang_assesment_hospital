import React, { useState } from 'react';
import { registerEmployee } from '../../services/registerService';
import { Modal,Typography, Stack, FormControl, InputLabel,Select,MenuItem, TextField  } from '@mui/material';
import useAuth from '../auth/authContext';
import { Navigate } from 'react-router-dom';

const height = window.screen.height - 0;
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

const EmployeeRegistration = () => {
  const auth = useAuth()
  const [registerData, setRegisterData] = useState({
    employeeFirstName: '',
    employeeLastName: '',
    employeeQualification: '',
    gender: '',
    password: '',
    employeeImgURL: '',
  });

  const [response, setResponse] = useState(null);
  const [open, setOpen] = useState(false);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setRegisterData({ ...registerData, [name]: value });
    console.log(value)
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const response = await registerEmployee(registerData);
      setResponse(response);
    } catch (error) {
      setResponse(error);
    }
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    !auth.loginLog.isLoggedIn ?
    <div style={{height:`${height}px`}} className='bg' >
      <div style={{position:'relative',top:'17%'}}>
        <form className="card border-primary" style={{width:'35%', backgroundColor:'rgba(200,200,200,.1)', transform:'translateX(20%)'}} onSubmit={handleSubmit}>
        <div className="card-body">
        <h3 className="card-title text-center">Employee Registration</h3>
          <TextField
          id="fname"
          label="First Name"
            type="text"
            className="form-control"
            name="employeeFirstName"
            value={registerData.employeeFirstName}
            onChange={handleInputChange}
            autoComplete="off"
            style={{backgroundColor:'rgba(255,255,255,.1)'}}
            placeholder='First Name'
            required
          />
          <TextField
            id="lname"
            label="Last Name"
            type="text"
            className="form-control"
            name="employeeLastName"
            value={registerData.employeeLastName}
            onChange={handleInputChange}
            style={{backgroundColor:'rgba(255,255,255,.1)'}}
            placeholder='Last Name'
            autoComplete="off"
            required
          />
          <TextField
          id="qualification"
          label="Qualification"
            type="text"
            className="form-control"
            name="employeeQualification"
            value={registerData.employeeQualification}
            onChange={handleInputChange}
            style={{backgroundColor:'rgba(255,255,255,.1)'}}
            placeholder='Qualification'
            autoComplete="off"
            required
          />
          <FormControl fullWidth>
              <InputLabel id="demo-simple-select-label">Gender</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={registerData.gender}
              label="gender"
              name='gender'
              onChange={handleInputChange}
              required>
              <MenuItem value={'Male'}>Male</MenuItem>
              <MenuItem value={'Female'}>Female</MenuItem>
            </Select>
          </FormControl>
          <TextField
          id="password"
          label="Passworrd"
            type="password"
            className="form-control"
            name="password"
            style={{backgroundColor:'rgba(255,255,255,.1)'}}
            value={registerData.password}
            onChange={handleInputChange}
            placeholder='Password'
            required
          />
          <TextField
          id="imgurl"
          label="Image URL"
            type="text"
            className="form-control"
            name="employeeImgURL"
            style={{backgroundColor:'rgba(255,255,255,.1)'}}
            value={registerData.employeeImgURL}
            onChange={handleInputChange}
            placeholder='https://...'
            autoComplete="off"
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
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
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
    </div> :
        <Navigate to={'/'} replace />    

  );
};

export default EmployeeRegistration;
