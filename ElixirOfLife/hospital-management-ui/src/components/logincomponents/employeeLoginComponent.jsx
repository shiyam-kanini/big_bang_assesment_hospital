import React, { useState } from 'react';
import { loginEmployee } from '../../services/loginService';
import useAuth from '../auth/authContext';
import { Modal,Stack, Typography, TextField } from '@mui/material';
import '../../App.css'
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

  
  const height = window.screen.height - 100;
  const width = window.screen.width ;

const EmployeeLogin = () => {
  const {auth, updateAuth} = useAuth()
  const [loginCredentials, setLoginData] = useState({
    loginId: '',
    password: ''
  });
  const [response, setResponse] = useState(null);
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
          const data = await loginEmployee(loginCredentials);
          setResponse(data);
          setResponseModal(true)
          window.localStorage.setItem('sessionId', data.loginLog.sessionId)
          window.localStorage.setItem('loginId', data.loginLog.loginId)
          window.localStorage.setItem('token', data.loginLog.token)
          window.localStorage.setItem('isLoggedIn', data.loginLog.isLoggedIn)
          window.localStorage.setItem('role', data.role)
          updateAuth(data.loginLog.sessionId, data.loginLog.loginId, data.loginLog.token, data.loginLog.isLoggedIn, data.role)
      } catch (error) {
        setResponse(error);
        setResponseModal(true)

      }
      handleOpen();
  };

  return (
    !auth.loginLog.isLoggedIn ?
    <div style={{height:`${height}px`}} className='bg' >
      <div style={{position:'relative',top:'20%'}}>
        <form className="card border-primary"  onSubmit={handleSubmit} style={{width:'30%', backgroundColor:'rgba(200,200,200,.1)', transform:'translateX(25%)'}}>
          <div className="card-head border-primary">
            <h3 className="card-text text-center">Employee Login</h3>
          </div>
          <div className="card-body">
          <TextField
          id="loginId"
          label="Login Id"
            type="text"
            className="form-control"
            name="loginId"
            style={{backgroundColor:'rgba(255,255,255,.1)'}}
            value={loginCredentials.loginId}
            onChange={handleInputChange}
            placeholder='Password'
            required
          />
            <TextField
          id="password"
          label="Passworrd"
            type="password"
            className="form-control"
            name="password"
            style={{backgroundColor:'rgba(255,255,255,.1)'}}
            value={loginCredentials.password}
            onChange={handleInputChange}
            placeholder='Password'
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

export default EmployeeLogin;
