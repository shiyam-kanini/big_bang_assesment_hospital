import React, { useEffect, useState } from 'react';
import { getAllPrescriptionsByDoctor } from '../../services/doctorsessionServices';
import useAuth from '../auth/authContext';


const height = window.screen.height - 100;
const DoctorPrescriptionPage = () => {
  const doctorId = window.localStorage.getItem('loginId')
  const [prescriptions, setPrescriptions] = useState([]);

  useEffect(() => {
    const fetchPrescription = async () => {
        try {
          const response = await getAllPrescriptionsByDoctor(doctorId
            );
          setPrescriptions(response);
          console.log(response)
        } catch (error) {
          console.error(error);
        }
      };
      fetchPrescription();
  }, []);

  

  return (
    <div style={{height:`${height}px`}}>
        <h1>Doctor Prescription Page</h1>
      {
        prescriptions.length > 0 ? 
      <table className='table'>
        <thead>
          <tr>
            <th>Prescription ID</th>
            <th>Patient Name</th>
            <th>Active</th>
          </tr>
        </thead>
        <tbody>
          {prescriptions.map((prescription) => (
            <tr key={prescription.prescriptionId}>
              <td>{prescription.prescriptionId}</td>
              <td>{prescription.patient.patientName}</td>
              <td>{prescription.sessionActive ? 'Yes' : 'No'}</td>
            </tr>
          ))}
        </tbody>
      </table>
      :
      <p>No Data Found</p>
      }

    </div>
    
  );
};

export default DoctorPrescriptionPage;
