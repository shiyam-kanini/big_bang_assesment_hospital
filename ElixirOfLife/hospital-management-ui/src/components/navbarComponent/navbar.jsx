import React, { useState } from 'react';
import 'E:/big_bang_assesment_hospital/ElixirOfLife/hospital-management-ui/src/styles/navbar.css'
import { Link } from 'react-router-dom'
import Profile from 'E:/big_bang_assesment_hospital/ElixirOfLife/hospital-management-ui/src//assets/img/profile.svg'
import useAuth from '../auth/authContext';
import home from '../../assets/img/home.svg'
import employee from '../../assets/img/employee.svg'
import patient from '../../assets/img/patient.png'
const ProfileStyle = {
    width :'50px',
    height : '50px',
    cursor : 'pointer'
}


const Navbar = () => {
  const {auth} = useAuth();
  const [collapseVisible, setCollapseVisible] = useState(false);
  const handleNavbarToggle = () => {
    setCollapseVisible(!collapseVisible);
  };

  return (
    <div>
      <nav className="navbar navbar-primary text-white" style={{backgroundColor : 'rgba(22, 120, 224, .4)'}}>
        <div className="nav-flex appear">
          <button className="navbar-toggler" type="button" onClick={handleNavbarToggle} aria-controls="navbarToggleExternalContent">
            <span className="navbar-toggler-icon"></span>
          </button>
          <h1 style={{ position: 'relative', top: '15px', fontFamily:'sans-serif', color:'black'}}>Elixir of Life</h1>         
          <div className='profile'>
            <Link to={'/profileComponent/doctorProfile'}><img src={Profile} alt='' style={ProfileStyle}></img></Link>
          </div> 
        </div>
      </nav>

      <div className={`collapse p-4${collapseVisible ? ' show' : ''}`} id="navbarToggleExternalContent">
      <div >
        <nav>
            <ul className='nav nav-tabs nav-fill'>
                <li className='nav-item'><Link to={'/'} className='nav-link'color='white'><img src={home} alt='' width={'40px'} height={'40px'}></img>Home</Link></li>
                {
                !auth.loginLog.isLoggedIn ? 
                <li className='nav-item'><Link to={'/registerComponents/registerEmployeeComponent'} className='nav-link'><img src={employee} alt='' width={'40px'} height={'40px'}></img> Employee Registration</Link></li>
                :
                <></>}
                {
                !auth.loginLog.isLoggedIn ? 
                <li className='nav-item'><Link to={'/registerComponents/registerPatientComponent'} className='nav-link'><img src={patient} alt='' width={'40px'} height={'40px'}></img>Patient Registration</Link></li>
                :
                <></>}
                {
                !auth.loginLog.isLoggedIn ? 
                <li className='nav-item'><Link to={'/loginComponents/employeeLoginComponent'} className='nav-link'><img src={employee} alt='' width={'40px'} height={'40px'}></img>Employee Login</Link></li>
                :
                <></>}
                {
                !auth.loginLog.isLoggedIn  ? 
                <li className='nav-item'><Link to={'/loginComponents/patientLoginComponent'} className='nav-link'><img src={patient} alt='' width={'40px'} height={'40px'}></img>Patient Login</Link></li>
                :
                <></>}
                {
                 auth.loginLog.isLoggedIn && auth.loginLog.role === 'ROLEID001' ? 
                <li className='nav-item'><Link to={'/roomComponent/roomsauth.loginLogorizePage'} className='nav-link'>Authorize Rooms</Link></li>
                :
                <></>}
                {
                auth.loginLog.isLoggedIn && auth.loginLog.role === 'Patient' ? 
                <li className='nav-item'><Link to={'/doctorsessionComponents/requestSessionComponent'} className='nav-link'>Request Session</Link></li>
                :
                <></>}
                {
                auth.loginLog.isLoggedIn && auth.loginLog.role === "Patient"? 
                <li className='nav-item'><Link to={'/labReportComponent/labReportRequest'} className='nav-link'>Get Lab Assistance</Link></li>
                :
                <></>}
                {
                auth.loginLog.isLoggedIn && auth.loginLog.role === 'ROLEID003' ? 
                <li className='nav-item'><Link to={'/labReportComponent/labReportResponse'} className='nav-link'>Send Lab Assistance</Link></li>
                :
                <></>}
                {
                auth.loginLog.isLoggedIn && auth.loginLog.role === 'ROLEID001' ? 
                <li className='nav-item'><Link to={'/adminComponents/enableEmployeePage'} className='nav-link'>Enable Employees</Link></li>
                :
                <></>}
                {
                auth.loginLog.isLoggedIn && auth.loginLog.role === 'Patient' ? 
                  <li className='nav-item'><Link to={'/roomComponent/roomsPage'} className='nav-link'>Explore Rooms</Link></li>:<></>
                }
                {
                 auth.loginLog.isLoggedIn && auth.loginLog.role === 'ROLEID002' ? 
                <li className='nav-item'><Link to={'/doctorsessionComponents/doctorPrescriptionPage'} className='nav-link'>Dashboard</Link></li>
                :
                <></>}


            </ul>
        </nav>
       </div>
      </div>
    </div>
  );
};

export default Navbar;
