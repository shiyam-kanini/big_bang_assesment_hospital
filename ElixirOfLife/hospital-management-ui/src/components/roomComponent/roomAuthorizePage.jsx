import React, { useState, useEffect } from 'react';
import { viewRoomRequests } from '../../services/getRoomPatientRequestsService';
import { provideRoom } from '../../services/roomPatientServices';

import { Modal,Stack, Typography } from '@mui/material';

const height = window.screen.height - 220;
const s = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  border: 'none',
  boxShadow: 24,
  p: 4,
  backgroundColor : 'rgba(0,0,0,.6)',
};
const bg = {
  height: `${height + height/4}px`,
  backgroundImage: `url()`,
  backgroundRepeat:'no-repeat',
  backgroundSize : 'cover',
};
const AuthorizeRoom = () => {
  const [roomRequests, setRoomRequests] = useState([]);
  const [assign, setAssign] = useState(null);
  const [assignModal, setAssignModal] = useState(false);
  const [responseModal, setResponseModal] = useState(false);
  const [response, setResponse] = useState(null);


  const handleAssign = (assignData) => {
    setAssign({rdpid : assignData, isActive : true})
    setAssignModal(true);
  } 
  const handleRevoke = (revokeData) => {
    setAssign({rdpid : revokeData, isActive : false})
    setAssignModal(true);
  } 
  const sendAssignResponse = async() => {
    try{
    setAssignModal(false)
        console.log(assign)
        const response = await provideRoom(JSON.stringify(assign))
        setResponse(response)
        setResponseModal(true);
    }
    catch(error){
      setResponse(response)
      setResponseModal(true);
    }
  }

  useEffect(() => {
    async function fetchData() {
      try {
        const data = await viewRoomRequests();
        setRoomRequests(data);
      } catch (error) {
        console.error(error);
      }
    }

    fetchData();
  }, []);

  return (
    <div style={{height : `${height}px`, position:'relative'}}>
      <h1 className='text-center'>Active Room Requests</h1>
      {
        roomRequests.length > 0 ?
        <table className="table table-striped border-primary" style={{width : '80%', margin:'auto', position: 'relative', top:'40px', backgroundColor:'rgba(0, 0, 0,.5)'}} >
        <thead>
          <tr>
            <th>Request ID</th>
            <th>Room</th>
            <th>Patient</th>
            <th>Active</th>
          </tr>
        </thead>
        <tbody>
          {roomRequests.length > 0 && roomRequests.map((request) => (
            <tr key={request.rdpid}>
              <td className= {!request.isActive ? '' : 'text-info'}>{request.rdpid}</td>
              <td className= {!request.isActive ? '' : 'text-info'}>{request.room.roomType}</td>
              <td className= {!request.isActive ? '' : 'text-info'}>{request.patient.patientName}</td>
              <td className= {!request.isActive ? '' : 'text-info'}>{!request.isActive ? <button className='btn btn-outline-success' onClick={() => handleAssign(request.rdpid)}>Allow</button> : <button className='btn btn-outline-warning' onClick={() => handleRevoke(request.rdpid)}>Revoke</button> }</td>
            </tr>            
          ))}
        </tbody>
      </table> 
      :
      <Stack direction={'column'} alignItems={'center'}>
                <div className="spinner-border text-primary" role="status">
            </div>
                <span className="sr-only">Loading...</span>
        </Stack>
      }
      <Modal
          open={assignModal}
          onClose={() => setAssignModal(false)}
          aria-labelledby="text-response-message"
          aria-describedby="text-response-token"
        >
          <Stack alignItems="center" justifyContent="space-evenly" sx={s} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {assign != null && assign.isActive?
                `Authorize room ${assign?.rdpid}` :
                `Revoke Authorized room under id : ${assign?.rdpid}`
              }
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
            <button className={assign != null && !assign.isActive ? " btn btn-outline-danger" : ' btn btn-outline-success'} onClick={sendAssignResponse}>
              { assign != null && assign.isActive ? "Authorize" : "Revoke"}
            </button>
          </Stack>
        </Modal>
        <Modal
          open={responseModal}
          onClose={() => setResponseModal(false)}
          aria-labelledby="text-response-message"
          aria-describedby="text-response-token"
        >
          <Stack alignItems="center" justifyContent="space-evenly" sx={s} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {response != null ? response.message : "_Bad_request_"}
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
            <button className="btn btn-outline-success" onClick={() => setResponseModal(false)}>
              { "go back"}
            </button>
          </Stack>
        </Modal>
    </div>
  );
};

export default AuthorizeRoom;
