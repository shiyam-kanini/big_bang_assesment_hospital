import React, { useState, useEffect } from 'react';
import { Stack, Modal, Typography } from '@mui/material';
import { getAllRooms } from '../../services/roomPatientServices';
import { requestRoom } from '../../services/roomPatientServices';
import request from '../../assets/img/request.svg'
import '../../styles/button.css'


const width = window.screen.width - 16;
const height = window.screen.height - 220;

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  border: 'none',
  boxShadow: 24,
  p: 4,
  backgroundColor : 'rgba(0,0,0,.8)',
};


const RoomsPage = () => {
  const [rooms, setRooms] = useState([]);
  const [background, setBackground] = useState('');
  const [activeIndex, setActiveIndex] = useState(0);
  const [requestData, setRequestData] = useState({});
  const [requestModal, setRequestModal] = useState(false);
  const [response, setResponse] = useState(null);
  const [responseModal, setResponseModal] = useState(false);

  const handleRequest = (requestData)=> {
    setRequestData({room:requestData, patient:"PID1866"})
    setRequestModal(true)
  }

  const sendRequest = async() => {
    setRequestModal(false)
    const response = await requestRoom(JSON.stringify(requestData));
    setResponse(response)
    setResponseModal(true);
  }


  useEffect(() => {
    const fetchRooms = async () => {
      try {
        const roomData = await getAllRooms();
        setRooms(roomData);
      } catch (error) {
        console.error(error);
      }
    };
    fetchRooms();
  }, []);

  const bg = {
    height: `${height + height/4}px`,
    backgroundImage: `url(${background})`,
    backgroundRepeat:'no-repeat',
    backgroundSize : 'cover',
  };

  

  const changeBg = (url) => {
    setBackground(url);
  };

  const handlePrev = () => {
    setActiveIndex((prevIndex) => (prevIndex === 0 ? rooms.length - 1 : prevIndex - 1));
  };

  const handleNext = () => {
    setActiveIndex((prevIndex) => (prevIndex === rooms.length - 1 ? 0 : prevIndex + 1));
  };

  return (
    <div id="c1" className="carousel slide" data-bs-ride="true" style={bg}>
      <div className="carousel-inner" style={{ position: 'relative', top: '35%' }}>
        {rooms.length > 0 ? (
          rooms.map((room, index) => (
            <div className={`carousel-item ${index === activeIndex ? 'active' : ''}`} key={room.roomId} style={{ position: 'relative', }}>
              <div className="card text-left" style={{ width: '40%', margin: 'auto', backgroundColor: 'rgba(255, 255, 255, .7)', padding:'5px'}} onClick={() => changeBg(room.roomImgURL)}>
                <Stack direction={'column'} justifyContent={'center'} alignItems={'flex-start'} >
                  <h4 className='card-title'>Room Id : {room.roomId}</h4>
                  <p className='font-weight-bold' >Room Type : {room.roomType}</p>
                  <p className='font-weight-bold'>Room Description : {room.roomDescription}</p>
                  <p className='font-weight-bold'>Room Count : {room.roomCount}</p>
                  <p className='font-weight-bold text-danger'>Room Cost : ₹{room.price}</p>
                </Stack>
                <button className='btn button' onClick={() => handleRequest(room.roomId)}><img src={request} alt="" width={'30px'} height={'30px'} /></button>
              </div>
            </div>
          ))
        ) : (
          <div className="text-center">No rooms available</div>
        )}
      </div>
      <button className="carousel-control-prev" type="button" data-bs-target="#c1" data-bs-slide="prev" style={{ backgroundColor: 'rgba(152, 170, 179, .5)' }} onClick={handlePrev}>
        <span className="carousel-control-prev-icon" aria-hidden="true"></span>
        <span className="visually-hidden">Previous</span>
      </button>
      <button className="carousel-control-next" type="button" data-bs-target="#c1" data-bs-slide="next" style={{ backgroundColor: 'rgba(152, 170, 179, .5)' }} onClick={handleNext}>
        <span className="carousel-control-next-icon" aria-hidden="true"></span>
        <span className="visually-hidden">Next</span>
      </button>
      <Modal
        open={requestModal}
        onClose={() => setRequestModal(false)}
        aria-labelledby="text-response-message"
        aria-describedby="text-response-token"
      >
        <Stack alignItems="center" justifyContent="space-evenly" sx={style} className="rounded">
          <Typography id="text-response-message" variant="h6" className="text-white">
            Send room request ?
          </Typography>
          <Typography id="text-response-token" className="text-primary"></Typography>
          <button className="btn btn-outline-primary btnMorph" onClick={sendRequest}>
            Proceed
          </button>
        </Stack>
      </Modal>
      <Modal
        open={responseModal}
        onClose={() => setResponseModal(false)}
        aria-labelledby="text-response-message"
        aria-describedby="text-response-token"
      >
        <Stack alignItems="center" justifyContent="space-evenly" sx={style} className="rounded">
          <Typography id="text-response-message" variant="h6" className="text-white">
            {response != null ?
              response.message : "_Bad_Request_" 
          }
          </Typography>
          <Typography id="text-response-token" className="text-primary"></Typography>
          <button className="btn btn-outline-primary btnMorph" onClick={() => setResponseModal(false)}>
            Go
          </button>
        </Stack>
      </Modal>
    </div>
    
  );
};

export default RoomsPage;
