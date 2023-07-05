import axios from '../api/api';

const LAB_REPORT_REQUEST = 'LabReport/actions/requestlabreport'
const LAB_REPORT_PROVIDE = 'LabReport/actions/providelabreport'
const GET_ALL_LAB_REPORTS_URL = 'LabReport/actions/getlabreports'
const labreportRequest = async (labreportData) => {
    try {
      const response = await axios.post(LAB_REPORT_REQUEST, labreportData, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };
  const labreportResponse = async (labreportData) => {
      try{
          const response = await axios.post(LAB_REPORT_PROVIDE, labreportData, {
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
  const getAllReports = async () => {
    try{
        const response = await axios.get(GET_ALL_LAB_REPORTS_URL);
        return response.data;
    }
    catch(error){
        return error;
    }
  } 
  
  
  export {labreportRequest, labreportResponse, getAllReports}