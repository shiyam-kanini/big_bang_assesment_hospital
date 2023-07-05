import axios from '../api/api';

const REQUEST_DOCTOR_SESSION_URL = 'Prescription/actions/requestdoctorsession'
const DIAGNOSE_URL = 'Prescription/actions/diagnosesymptoms'
const BUY_DRUGS_URL = 'Prescription/actions/buydrugs'
const GET_ALL_PRESCRIPTION_URL = 'Prescription/actions/getallprescription'
const GET_ALL_DOCCTORS_URL = 'Prescription/actions/getalldoctors'
const GET_PRESCRIPTIONBYID = 'Prescription/actions/getprescriptionbyid'
const GET_PRESCRIPTIONBYDoctor = 'Prescription/actions/getprescriptionbydoctor'




const requestDoctorSession = async (requestData) => {
  
    try {
      const response = await axios.post(REQUEST_DOCTOR_SESSION_URL, requestData, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };
  const diagnoseStmptoms = async (buy) => {
      try{
          const response = await axios.post(DIAGNOSE_URL, buy, {
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

  const buyDrugs = async (symptoms) => {
    try{
        const response = await axios.post(BUY_DRUGS_URL, symptoms, {
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

  const getAllPrescriptions = async () => {
    try{
        const response = await axios.get(GET_ALL_PRESCRIPTION_URL);
        return response.data;
    }
    catch(error){
        return error;
    }
  }
  const getAllDoctors = async () => {
    try{
        const response = await axios.get(GET_ALL_DOCCTORS_URL);
        return response.data;
    }
    catch(error){
        return error;
    }
  }
  
  const getPrescriptionById =async(id) => {
    try{
      const response = await axios.get(`${GET_PRESCRIPTIONBYID}?id=${id}`, {
        headers : {
          "Content-type" : "text/plain",
          
        }
      })
      return response
    }
    catch(error) {
      return error
    }
  }
  const getAllPrescriptionsByDoctor = async (id) => {
    try{
        const response = await axios.get(`${GET_PRESCRIPTIONBYDoctor}?doctorId=${id}`, {
          headers : {
            "Content-type" : "text/plain",
          }
        });
        return response.data;
    }
    catch(error){
        return error;
    }
  }
  export {requestDoctorSession, diagnoseStmptoms, buyDrugs, getAllDoctors, getAllPrescriptions, getPrescriptionById, getAllPrescriptionsByDoctor}