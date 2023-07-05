import axios from '../api/api';

const REQUEST_ROOM_URL = 'RoomPatient/actions/requestroom'
const PROVIDE_ROOM_URL = 'RoomPatient/actions/provideroom'
const GET_ALL_ROOMS_URL = 'RoomPatient/actions/getallrooms'


const requestRoom = async (requestData) => {
    try {
      console.log(requestData)
      const response = await axios.post(REQUEST_ROOM_URL, requestData, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
      console.log(response.data)
      return response.data;
    } catch (error) {
      console.log(error)

      return error;
    }
  };
  const provideRoom = async (responseData) => {
      try{
          const response = await axios.put(PROVIDE_ROOM_URL, responseData, {
            headers: {
              'Content-Type': 'application/json'
            }
          });
          return response.data;
      }
      catch(error){
          return error;
      }
  }

  const getAllRooms = async () => {
    try{
        const response = await axios.get(GET_ALL_ROOMS_URL);
        console.log(response.data)
        return response.data
    }
    catch(error){
        return error;
    }
  }
  
  export {requestRoom, provideRoom, getAllRooms}