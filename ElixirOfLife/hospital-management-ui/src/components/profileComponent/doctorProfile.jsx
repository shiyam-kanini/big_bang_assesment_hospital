import React, { useEffect, useState } from 'react';
import { getEmployeeProfileById, logout } from '../../services/profileServices';

// Rest of the code...
import LogoutComponent from './logoutComponent';
const height = window.screen.height


const EmployeeProfile = () => {
  const [employeeProfile, setEmployeeProfile] = useState(null);
const id = window.localStorage.getItem('sessionId')
  useEffect(() => {
    const getEmployeeData = async () => {
        try {
          const profile = await getEmployeeProfileById(id); 
          console.log(profile.employeeProfile)
          setEmployeeProfile(profile.employeeProfile);
        } catch (error) {
          console.error(error);
        }
      };
    getEmployeeData();
  }, []);

  

  return (
    <div style={{height:`${height}px`}}>
      {employeeProfile ? (
        <div className="card" style={{width:'30rem', margin:'auto', position:'relative', top:'100px'}}>
          <img src={employeeProfile.employeeImgURL} alt="Doctor Profile" className='rounded'/>
          <div className="card-body">
            <h5 className="card-title">
              Mx. {employeeProfile.employeeFirstName} {employeeProfile.employeeLastName}
            </h5>
            <p className="card-text">Qualification: {employeeProfile.employeeQualification}</p>
            <p className="card-text">Gender: {employeeProfile.gender}</p>
            <p className="card-text">Gender: {employeeProfile.gender}</p>
            <LogoutComponent></LogoutComponent>
          </div>
        </div>
      ) : (
        <p>Loading doctor profile...</p>
      )}
    </div>
  );
};

export default EmployeeProfile;
