import axios from '../../api/api';

const GET_SPECIALIZATION_URL = 'Specialization/actions/getallspecialization'
const GET_SPECIALIZATION_BY_ID_URL = 'Specialization/actions/getspecializationbyid'
const POST_SPECIALIZATION_URL = 'Specialization/actions/postspecialization'
const PUT_SPECIALIZATION_URL = 'Specialization/actions/putspecialization'
const DELETE_SPECIALIZATION_URL = 'Specialization/actions/deletespecialization'

const getSpecializations = async () => {
    try {
      const response = await axios.get(GET_SPECIALIZATION_URL, {
        headers: {
          
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };
const getSpecializationById = async (specializationId) => {
    try {
        const response = await axios.get(GET_SPECIALIZATION_BY_ID_URL, specializationId, {
          headers: {
            'Content-Type': 'text/plain'
          }
        });
        return response.data;
      } catch (error) {
        return error;
      }
    };
const postSpecialization = async (specializationData) => {
    try{
        const response = await axios.post(POST_SPECIALIZATION_URL, specializationData, {
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

const putSpecialization = async (specializationData) => {
    try{
        const response = await axios.put(PUT_SPECIALIZATION_URL, specializationData, {
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

const deleteSpecialization = async (specializationId) => {
    try{
        const response = await axios.post(DELETE_SPECIALIZATION_URL, specializationId, {
            headers: {
                'Content-Type': 'text/plain'
            }
          });
        return response.data;
    }
    catch(error){
        return error;
    }
}
  export {getSpecializations, getSpecializationById, postSpecialization, putSpecialization, deleteSpecialization}