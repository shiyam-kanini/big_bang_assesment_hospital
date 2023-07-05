import axios from '../../api/api';

const GET_ROLES_URL = 'Role/actions/getroles'
const GET_ROLES_BY_ID_URL = 'Role/actions/getrolebyid'
const POST_ROLE_URL = 'Role/actions/postrole'
const PUT_ROLE_URL = 'Role/actions/putrole'
const DELETE_ROLE_URL = 'Role/actions/deleterole'
const getRoles = async () => {
    try {
      const response = await axios.get(GET_ROLES_URL);
      return response.data;
    } catch (error) {
      return error;
    }
  };
const getRoleById = async (roleId) => {
    try {
        const response = await axios.get(GET_ROLES_BY_ID_URL, roleId, {
          headers: {
            'Content-Type': 'text/plain'
          }
        });
        return response.data;
      } catch (error) {
        return error;
      }
    };
const postRole = async (roleData) => {
    try{
        const response = await axios.post(POST_ROLE_URL, roleData, {
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

const putRole = async (roleData) => {
    try{
        const response = await axios.put(PUT_ROLE_URL, roleData, {
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

const deleteRole = async (roleId) => {
    try{
        const response = await axios.post(DELETE_ROLE_URL, roleId, {
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
  export {getRoles, getRoleById, postRole, putRole, deleteRole}