import React from 'react'
import useAuth from '../auth/authContext'
const AlreadyLoggedIn = () => {
    const {auth} = useAuth()
  return (
    auth.loginLog.isLoggedIn ? 
    <></>
    :
    <></>
  )
}

export default AlreadyLoggedIn