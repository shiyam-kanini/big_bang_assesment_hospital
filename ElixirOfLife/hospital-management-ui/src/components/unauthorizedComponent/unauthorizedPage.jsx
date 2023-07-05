import React from 'react'
import { Link } from 'react-router-dom'
import { Stack } from '@mui/material'
import useAuth from '../auth/authContext'
import expired from '../../assets/img/denied.png'
import unauthorized from '../../assets/img/unauth1.svg'
import notsure from '../../assets/img/unauth.jpg'
const height = window.screen.height - 220

const imgStyle = {
    width : '30%',
    height : '150px',
}

const bg = {
    backgroundImage: `url(${notsure})`,
    backgroundRepeat: 'no-repeat',
    backgroundSize: '100%',
    position: 'relative',
}

const Unauthorized = () => {
    const {auth} = useAuth()
  return (
    <Stack alignItems={'center'} justifyContent={'center'} height={`${height}px`} style={bg}>
        {!auth.loginLog.isLoggedIn ? 
            <Stack direction={'row'} className='card' style={{padding:'3%', position:'relative', left:'300px',backgroundColor:'rgba(255,255,255,.1)'}}>
                <img src={expired} alt="" style={imgStyle}/>
                <Stack direction={'column'} alignItems={'stretch'} justifyContent={'space-evenly'}>
                    <h4 className='text-danger' style={{padding:'0'}}>Session has been expired</h4>
                    <Link to={'/loginComponents/employeeLoginComponent'} className='btn btn-outline-success' >Employee Login</Link>
                    <Link to={'/loginComponents/patientLoginComponent'} className='btn btn-outline-success' >Patient Login</Link>
                </Stack>
            </Stack> : 
            <div>
                <Stack className='card' direction={'row'} style={{padding:'3%', position:'relative', left:'300px', backgroundColor:'rgba(0,20,200,.1)'}}>
                    <img src={unauthorized} alt="" style={imgStyle}/>
                    <Stack direction={'column'} alignItems={'center'} justifyContent={'center'}>
                        <h4 className='text-danger'>Unauthorized Access!</h4>
                    </Stack>
                </Stack>
            </div>
        }
    </Stack>
  )
}

export default Unauthorized