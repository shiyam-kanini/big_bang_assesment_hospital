import React from 'react';
import useAuth from './authContext';
import { useLocation, Navigate, Outlet } from 'react-router-dom';

const RequireAuth = ({allowedRoles}) => {
  const { auth } = useAuth();
  const location = useLocation();
  return (
    allowedRoles.includes(auth.loginLog.role) ?
    <Outlet/>
    :
      <Navigate to={'/unauthorizedComponent/unauthorizedPage'} state={{ from: location }} replace />    
  );
};

export default RequireAuth;