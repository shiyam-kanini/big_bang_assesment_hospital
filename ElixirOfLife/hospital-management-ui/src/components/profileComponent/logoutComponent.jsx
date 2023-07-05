import React, { Suspense, useState, useEffect } from 'react';
import axios from 'axios';
import { Modal, Typography, Stack } from '@mui/material';
import { Link } from 'react-router-dom';
import useAuth from '../auth/authContext';
import { logout } from '../../services/profileServices';

const LogoutComponent = () => {
  const { auth, updateAuth } = useAuth();
  const [responseModal, setResponseModal] = useState(false);
  const [logoutResponse, setLogoutResponse] = useState({
    status : false,
    message :'',
    loginLog : {

    }
  });
  const [logoutModal, setLogoutModal] = useState(false)
  const [countdown, setCountdown] = useState(5000);

  useEffect(() => {
    let timerId;
    if (countdown > 0) {
      timerId = setTimeout(() => {
        setCountdown(countdown - 1);
      }, 1000);
    } else {
      //updateAuth(null, null, null, false, null);
    
    }
    return () => {
      clearTimeout(timerId);
    };
  }, [countdown, updateAuth]);

  const handleResponseClose = () => {
    setResponseModal(false);
  };


  const Logout = async () => {
    try {
      const response = await logout(auth.loginLog.sessionId)
      setLogoutResponse(response);
      setResponseModal(true);
      setLogoutModal(false)
      console.log(response)
      setCountdown(6);
    } catch (error) {
      console.log(error);
    }
  };

  const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
    backgroundColor: '#27374D',
  };

  const clearData = () => {
    updateAuth(null, null, null, false, null);
    window.localStorage.clear();
  }


  return (
    <div>
      {auth.loginLog.token != null ? (
        <button className="btn btn-outline-danger" style={{ marginTop: '10px' }} onClick={() => setLogoutModal(true)}>
          Logout
        </button>
      ) : (
        <></>
      )}
      <Suspense
        fallback={
          <div className="d-flex justify-content-center" style={{ opacity: '.7' }} direction={'column'}>
            <div className="spinner-border text-primary" role="status"></div>
            <span className="sr-only ">Loading</span>
          </div>
        }
      >
        <Modal
          open={responseModal}
          onClose={handleResponseClose}
          aria-labelledby={'text-response-message' || 'text-error-message'}
          aria-describedby={'text-response-token' || 'text-error-token'}>
          {logoutResponse && logoutResponse.status === true ? (
            <Stack sx={style} alignItems="center" justifyContent="space-evenly" className="rounded">
              <Typography id="text-response-message" variant="h6" className="text-warning">
                {logoutResponse.message}
              </Typography>
              <Typography id="text-response-token" className="text-primary"></Typography>
              <Link to={'/unauthorizedComponent/unauthorizedPage'} className='btn btn-outline-success' onClick={clearData} >Goto Login ({countdown})</Link>
            </Stack>
          ) : (
            <Stack sx={style} alignItems="center" justifyContent="space-evenly" className="rounded">
              <Typography id="text-response-message" variant="h6" className="text-warning">
                {logoutResponse.message}
              </Typography>
              <Typography id="text-response-token" className="text-primary"></Typography>
              <button className="btn btn-outline-success" onClick={handleResponseClose}>
                Go Back
              </button>
            </Stack>
          )}
        </Modal>
      </Suspense>
      <Suspense
        fallback={
          <div className="d-flex justify-content-center" style={{ opacity: '.7' }} direction={'column'}>
            <div className="spinner-border text-primary" role="status"></div>
            <span className="sr-only ">Loading</span>
          </div>
        }
      >
        <Modal
          open={logoutModal}
          onClose={() => setLogoutModal(false)}>
            <Stack sx={style} alignItems="center" justifyContent="space-evenly" className="rounded">
              <Typography id="text-response-message" variant="h6" className="text-warning text-center">
                Do you want to logout of the session?
              </Typography>
              <Typography id="text-response-token" className="text-primary"> </Typography>
              <Stack direction={'row'}>
                <button className='btn btn-outline-primary' style={{marginRight:'10px'}} onClick={() => setLogoutModal(false)}>Go Back</button>
                <button className='btn btn-danger' style={{marginLeft:'10px'}} onClick={Logout}>Logout</button>
              </Stack>
            </Stack>
        </Modal>
      </Suspense>
    </div>
  );
};

export default LogoutComponent;
