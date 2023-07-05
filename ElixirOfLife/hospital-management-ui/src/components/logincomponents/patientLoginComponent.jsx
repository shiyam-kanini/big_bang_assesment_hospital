import React, { useEffect, useState } from 'react';
import '../../App.css'
import { loginPatient } from '../../services/loginService';
import useAuth from '../auth/authContext';
import { Modal,Stack,Typography, TextField } from '@mui/material';
import { Navigate } from 'react-router-dom';

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
  const height = window.screen.height - 50;

const PatientLogin = () => {
  const {auth, updateAuth} = useAuth()
  const [error, setError] = useState(null)
  const [loginCredentials, setLoginData] = useState({
    loginId: '',
    password: ''
  });
  const [response, setResponse] = useState({
    status : false,
    message : '',
    role : '',
    loginLog : {
      sessionId : '',
      loginId : '',
      token : '',
      isLoggedIn : false
    }
  });
  const [responseModal, setResponseModal] = useState(false);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setLoginData({ ...loginCredentials, [name]: value });
  };

  const handleOpen = () => {
    setResponseModal(true);
  };

  const handleClose = () => {
    setResponseModal(false);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
      try { 
          const data = await loginPatient(loginCredentials);
          setResponse(data);
          setResponseModal(true)
          window.localStorage.setItem('sessionId', data.loginLog.sessionId)
          window.localStorage.setItem('loginId', data.loginLog.loginId)
          window.localStorage.setItem('token', data.loginLog.token)
          window.localStorage.setItem('isLoggedIn', data.loginLog.isLoggedIn)
          window.localStorage.setItem('role', data.role)
          updateAuth(data.loginLog.sessionId, data.loginLog.loginId, data.loginLog.token, data.loginLog.isLoggedIn, data.role)
        }
      catch (error) {
        setError(error);
        setResponseModal(true)
      }
      handleOpen();
  };


  const proceed = () => {
    handleClose(false);
  }

  return (
    !auth.loginLog.isLoggedIn ?
    <div style={{height:`${height}px`}} className='bg' >
      <div style={{position:'relative',top:'20%'}}>
        <form className="card border-primary"  onSubmit={handleSubmit} style={{width:'30%', backgroundColor:'rgba(200,200,200,.2)', position:'relative', left:'8%'}}>
          <div className="card-head border-primary">
            <h3 className="card-text text-center">Patient Login</h3>
          </div>
          <div className="card-body">
          <TextField
              id="name"
              label="Patient Id"
              type="text"
              className="form-control inp"
              name="loginId"
              value={loginCredentials.patientId}
              onChange={handleInputChange}
              autoComplete="off"
              style={{backgroundColor:'rgba(255,255,255,.1)'}}
              required
            />
            <TextField
              id="password"
              label="Password"
              type="password"
              className="form-control inp"
              name="password"
              value={loginCredentials.password}
              onChange={handleInputChange}
              style={{backgroundColor:'rgba(255,255,255,.1)'}}
              required
            />
          </div>
          <div className="card-footer text-center">
            <button type="submit" className="btn btn-outline-primary" >
              Login            
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
          {error == null ?
          <Stack alignItems="center" justifyContent="space-evenly" sx={style} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {response ? response.message : ''}
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
              <button className='btn btn-outline-success' onClick={proceed}>Proceed</button>  
          </Stack>
          :
          <Stack alignItems="center" justifyContent="space-evenly" sx={style} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {error ? error.name : ''}
            </Typography>
            <Typography id="text-response-token" className="text-primary">{error? error.message : '' }</Typography>
            <button className='btn btn-outline-warning' onClick={proceed}>Go Back</button>  
          </Stack>
          }
        </Modal>
    </div>
    :
    <Navigate to={'/'} replace />    
  );
};

export default PatientLogin;
