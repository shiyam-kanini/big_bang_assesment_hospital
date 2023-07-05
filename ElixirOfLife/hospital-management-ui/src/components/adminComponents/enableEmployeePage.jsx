import React, { useEffect, useState } from 'react';
import { getAllEmployees } from '../../services/adminservices/adminAuthorizeServices';
import { Stack } from '@mui/material';
import { enableEmployee } from '../../services/adminservices/adminAuthorizeServices';
import { Modal, Typography, FormControl, InputLabel, MenuItem, Select } from '@mui/material';
import { getRoles } from '../../services/adminservices/rolesServices';
const height = window.screen.height - 220;
const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
    backgroundColor: '#27374D',
  };

const EnableEmployeePage = () => {
  const [employees, setEmployees] = useState([]);
  const [open, setOpen] = useState(false);
  const [roles, setRoles] = useState([])
  const [selectedRole, setSelectedRole] = useState('')
  const [activateData, setActivateData] = useState({
    employeeId: "",
    role: "",
    setActive: true
  });


  const handleInputChange = (e) => {
    setSelectedRole(e.target.value)
  };

  const handlesetActivateData = (employeeId) => {
    setActivateData({employeeId : employeeId, role : selectedRole, setActive:true})
    setOpen(true);
  }
  const ActivateRequest = async() => {
    try{
        await enableEmployee(activateData)
        setOpen(false);
    }
    catch(error){
        console.log(error)
        setOpen(false);
    }
  }
  useEffect (() => {
    const fetchRoles = async() =>{
      try{
        const roleData = await getRoles();
        setRoles(roleData.roles)
      }
      catch(error){
        console.log(error);
      }
    };
    fetchRoles();


  },[]);

  useEffect(() => {
    const fetchEmployees = async () => {
      try {
        const employeeData = await getAllEmployees();
        setEmployees(employeeData);
      } catch (error) {
        console.error(error);
      }
    };

    fetchEmployees();
  }, []);


  return (
        <div style={{height:`${height}px`}}>
           { employees.length > 0 ?
            <table className='table table-striped'>
                <thead>
                    <tr>
                    <th>Employee Id</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Qualification</th>
                    <th>Gender</th>
                    <th>Role</th>
                    <th>Activate</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map((employee) => (
                    <tr key={employee.employeeId}>
                        <td>{employee.employeeId}</td>
                        <td>{employee.employeeFirstName}</td>
                        <td>{employee.employeeLastName}</td>
                        <td>{employee.employeeQualification}</td>
                        <td>{employee.gender}</td>
                        <td>
                          {
                            !employee.isActive ? 
                            (
                              <FormControl fullWidth>
                            <InputLabel id="demo-simple-select-label">Role</InputLabel>
                            <Select
                              labelId="demo-simple-select-"
                              value={selectedRole}
                              label="Role"
                              onChange={handleInputChange}
                              required
                              name='role'>
                                {
                                  roles.length > 0 ? roles.map((r,index) => (
                                    <MenuItem value={r.roleId} key={index}>{r.roleame}</MenuItem>
                                  )):<p>No Roles</p>
                                }
                              
                              </Select>
                            </FormControl>
                            )
                            :
                            'Available'
                            }
                        </td>
                        <td>{employee.isActive ? <p className='text-success'>Active</p> : <button className='btn btn-outline-warning' onClick={() => handlesetActivateData(employee.employeeId)}>Activate</button>}</td>
                    </tr>
                    ))}
                </tbody>
                </table>
                :
                <Stack className="d-flex justify-content-center" style={{ opacity: '.7', margin:'auto',width:'30px', position:'relative', top:'200px' }}>
                <div className="spinner-border text-primary" role="status"></div>
                <span className="sr-only">Loading</span>
            </Stack>}
            <Modal
        open={open}
        onClose={() => setOpen(false)}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Stack alignItems="center" justifyContent="space-evenly" sx={style} className="rounded">
          <Typography id="text-response-message" variant="h6" className="text-success">
            Activate Employee as {activateData.role} ?
          </Typography>
          <Typography id="text-response-token" className="text-primary"></Typography>
          <button className="btn btn-outline-success" onClick={ActivateRequest}>
            Proceed
          </button>
        </Stack>
      </Modal>
        </div>
  );
};

export default EnableEmployeePage;
