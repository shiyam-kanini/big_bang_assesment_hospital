import React, {useState} from 'react';
import { labreportRequest } from '../../services/labreportservices';

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
const LabReportRequest = () => {

  const  [patientData, setPatientData] = useState(null);

  const [response, setResponse] = useState(null);
  const [labRequestModal, setLabRequestModal] = useState(false);
  const [responseModal, setResponseModal] = useState(false);



  const handlePatientData = () => {
    setPatientData({patientId : "PID5277"})
    setLabRequestModal(true)
  } 
  const handleSendLabRequest = async() => {
    try{
        setLabRequestModal(false)
        const response = await labreportRequest(JSON.stringify(patientData))
        setResponse(response);
        setResponseModal(true);
    }
    catch(error){
        setResponse(error)
        setResponseModal(true);
    }
  } 

  return (
    <div style={{height:`${height}px`}}>
        <div className='card' style={{ width: '18rem' ,margin:'auto', position:'relative', top:'100px'}} >
            <div className='card-body'>
                <h5 className='card-tiitle'>Lab Reports</h5>
                <p className='card-text'>
                Generate lab reports for MRI and X-ray using our high-tech tools.
                </p>
                <button className='btn rounded btn-link' variant="secondary" onClick={handlePatientData}>Send lab request</button>
            </div>
        </div>
        <Modal
          open={labRequestModal}
          onClose={() => setLabRequestModal(false)}
          aria-labelledby="text-response-message"
          aria-describedby="text-response-token"
        >
          <Stack alignItems="center" justifyContent="space-evenly" sx={s} className="rounded">
            <Typography id="text-response-message" variant="h6" className="text-success">
              {patientData != null ?
                'Are you Sure ?' :
                "Bad_Request"
              }
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
            <button className="btn btn-outline-success" onClick={handleSendLabRequest}>
              Send
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
              {response != null ?
                response.message :
                "Bad_Request"
              }
            </Typography>
            <Typography id="text-response-token" className="text-primary"></Typography>
            <button className="btn btn-outline-success" onClick={() => setResponseModal(false)}>
              Go Back
            </button>
          </Stack>
        </Modal>
    </div>
    
  );
};

export default LabReportRequest;
