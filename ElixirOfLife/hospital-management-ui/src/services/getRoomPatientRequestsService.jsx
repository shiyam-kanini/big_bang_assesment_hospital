import axios from '../api/api';


const GET_ALL_ROOM_REQUEST = 'RoomPatient/actions/getallroompatients'



const viewRoomRequests = async () => {
  try {
    const response = await axios.get(GET_ALL_ROOM_REQUEST);
    return response.data;
  }
  catch(error){
    return error;
  }
}
  
  export {viewRoomRequests}