import axios from "../api/api";

const EMPLOYEE_PROFILE = 'EmployeeProfile/actions/getemployeeprofile'
const LOGUOT_URL = 'Login/actions/logout'


const getEmployeeProfileById = async (id) => {
    try {
      const response = await axios.get(`${EMPLOYEE_PROFILE}?id=${id}`, {
        headers: {
          'Content-Type': 'text/plain'
        }
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  };

const logout = async (id) => {
  try {
    const response = await axios.put(`${LOGUOT_URL}?sessionId=${id}`, {
      headers: {
        'Content-Type': 'text/plain'
      }
    });
    console.log(response)
    return response.data;
  } catch (error) {
    throw error;
  }
}



  export {getEmployeeProfileById, logout}