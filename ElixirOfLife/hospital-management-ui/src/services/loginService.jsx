import axios from '../api/api';

const LOGIN_EMPLOYEE_URL = 'Login/actions/employeelogin'
const LOGIN_PATIENT_URL = 'Login/actions/patientlogin'

const loginEmployee = async (loginCredentials) => {
    try {
      const response = await axios.post(LOGIN_EMPLOYEE_URL, loginCredentials, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };
  const loginPatient = async (loginCredentials) => {
      try{
          const response = await axios.post(LOGIN_PATIENT_URL, loginCredentials, {
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
  
  export {loginEmployee, loginPatient}