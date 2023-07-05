import axios from '../../api/api';

const GET_DRUGS_URL = 'DrugInventory/actions/getdrugs'
const GET_DRUG_BY_ID_URL = 'DrugInventory/actions/getdrugbyid'
const POST_DRUG_URL = 'DrugInventory/actions/postdrug'
const PUT_DRUG_URL = 'DrugInventory/actions/putdrug'
const DELETE_DRUG_URL = 'DrugInventory/actions/deletedrug'

const getDrugs = async () => {
    try {
      const response = await axios.get(GET_DRUGS_URL, {
        headers: {
          
        }
      });
      return response.data;
    } catch (error) {
      return error;
    }
  };
const getDrugById = async (drugId) => {
    try {
        const response = await axios.get(GET_DRUG_BY_ID_URL, drugId, {
          headers: {
            'Content-Type': 'text/plain'
          }
        });
        return response.data;
      } catch (error) {
        return error;
      }
    };
const postDrug = async (drugData) => {
    try{
        const response = await axios.post(POST_DRUG_URL, drugData, {
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

const putDrug = async (drugData) => {
    try{
        const response = await axios.put(PUT_DRUG_URL, drugData, {
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

const deleteDrug = async (drugId) => {
    try{
        const response = await axios.post(DELETE_DRUG_URL, drugId, {
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
  export {getDrugs, getDrugById, postDrug, putDrug, deleteDrug}