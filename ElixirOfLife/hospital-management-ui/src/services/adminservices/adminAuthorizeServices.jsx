import axios from '../../api/api';

const ENABLE_EMPLOYEE_URL = 'Admin/actions/enableemployee'
const ADD_SPECIALIZATION_URL = 'Admin/actions/addemployeespecialization'
const GET_ALL_EMPLOYEES = 'EmployeeProfile/actions/getallemployees'
const enableEmployee = async (employeeData) => {
    try {
      const response = await axios.put(ENABLE_EMPLOYEE_URL, employeeData);
      return response.data;
    } catch (error) {
      return error;
    }
  };
const addSpecialization = async (employeeData) => {
      try{
          const response = await axios.post(ADD_SPECIALIZATION_URL, employeeData);
          return response.data;
      }
      catch(error){
          return error;
      }
  }
const getAllEmployees = async () => {
    try{
        const response = await axios.get(GET_ALL_EMPLOYEES);
        return response.data;
    }
    catch(error){
        return error;
    }
}
  export {enableEmployee, addSpecialization, getAllEmployees}