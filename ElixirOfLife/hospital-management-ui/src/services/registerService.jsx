import axios from '../api/api';

const REGISTER_EMPLOYEE_URL = 'Register/actions/registeremployee';
const REGISTER_PATIENT_URL = 'Register/actions/registerpatient';
const registerEmployee = async (registerData) => {
  try {
    const response = await axios.post(REGISTER_EMPLOYEE_URL, registerData, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
    return response.data;
  } catch (error) {
    return error;
  }
};
const registerPatient = async (registerData) => {
    try{
        const response = await axios.post(REGISTER_PATIENT_URL, registerData, {
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

export {registerEmployee, registerPatient}
