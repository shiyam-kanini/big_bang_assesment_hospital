import React, { useEffect, useState, lazy, Suspense } from 'react';
import { getAllDoctors } from '../../services/doctorsessionServices';
import { requestDoctorSession } from '../../services/doctorsessionServices';

import { Modal, Stack, Typography } from '@mui/material';


const s = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
  backgroundColor : '#27374D',
};

const height = window.screen.height - 220;

const RequestSessionComponent = () => {
  const [doctors, setDoctors] = useState([]);
  const[session, setSession] = useState({});
  const [sessionModal, setSessionModal] = useState(false);
  const [response, setResponse] = useState(null);
  const [sessionResponseModal, setSessionResponseModal] = useState(false);

  const handleDoctorSelect = (doctorId) => {
    setSession({prescriptionIssuer : doctorId, patient : "PID5277", sessionActive : true});
    setSessionModal(true);
  }
  const handleSessionRequest = async() => {
    handleSessionClose(false)
    const response = await requestDoctorSession(JSON.stringify(session));
    setResponse(response);
    setSessionResponseModal(true);
    console.log(response);
  }
  const handleSessionClose = () => {
    setSessionModal(false)
  }
  useEffect(() => {
    const fetchDoctors = async () => {
      try {
        const doctorsData = await getAllDoctors();
        console.log(doctorsData)
        setDoctors(doctorsData)
      } catch (error) {
        console.log(error)
        setDoctors(error)
    }
    };
    fetchDoctors();
},[]);

  return (
    <div style={{ height: `${height}px`, width: '70%', margin: 'auto' }}>
      <h1>Available Doctors</h1>
      <div className="py-5">
        <div className="container">
          <div className="row hidden-md-up">
            { doctors != null ? doctors.length > 0 ? doctors.map((doctor)  => (
              <div className="col-md-4" >
                <div className='card' style={{width:'15rem'}}>
                  <img src={doctor.employeeImgURL} className="card-img-top" alt="..."></img>
                  <div className="card-body">
                    <h5 className="card-title">Doctor Id : {doctor.employeeId}</h5>
                    <p className="card-text">Doctor Name : {doctor.employeeFirstName} {doctor.employeeLastName}</p>
                    <p className="card-text">Doctor Qualification : {doctor.employeeQualification}</p>
                    <p className="card-text">Gender : {doctor.gender}</p>
                    <p className="card-text">Role : {doctor.role.roleame}</p>

                    {doctor.isActive ? <button className= "btn btn-outline-secondary" onClick={() => handleDoctorSelect(doctor.employeeId)}>Consult</button>:<button className="btn btn-outline-danger" disabled></button>}
                  </div>
                </div>
                </div>
            ))
            :
            <div className='text-danger text-center'>No data found</div>
            :
            <Stack direction={'column'} alignItems={'center'}>
                <div className="spinner-border text-primary" role="status">
                </div>
                <span className="sr-only">Loading...</span>
            </Stack>
          }
          </div>
        </div>
      </div>
      <Modal
          open={sessionModal}
          onClose={() => setSessionModal(false)}
          aria-labelledby="text-response-message"
          aria-describedby="text-response-token"
        >
          <Stack alignItems="center" justifyContent="space-evenly" sx={s} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {session != null ?
                `Book : ${session.prescriptionIssuer}` :
                "Doctor Not found"
              }
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
            <button className="btn btn-outline-success" onClick={handleSessionRequest}>
              Proceed
            </button>
          </Stack>
        </Modal>
      <Modal
          open={sessionResponseModal}
          onClose={() => setSessionResponseModal(false)}
          aria-labelledby="text-response-message"
          aria-describedby="text-response-token"
        >
          <Stack alignItems="center" justifyContent="space-evenly" sx={s} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {response != null ?
                response.message :
                "Bad_Request"
              }
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
            <button className="btn btn-outline-success" onClick={() => setSessionResponseModal(false)}>
              Go Back
            </button>
          </Stack>
        </Modal>
    </div>
  );
};

export default RequestSessionComponent;
