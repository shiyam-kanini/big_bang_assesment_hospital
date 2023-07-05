import React, { useEffect, useState } from 'react';
import { getAllReports } from '../../services/labreportservices';
import { Stack } from '@mui/material';


const width = window.screen.width - 16;
const height = window.screen.height - 220;

const LabReportResponse = () => {
  const [labReports, setLabReports] = useState([]);



  useEffect(() => {
    const fetchLabReports = async () => {
      try {
        const data = await getAllReports();
        console.log(data)
        setLabReports(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchLabReports();
  }, []);

  return (
    <div style={{height:`${height}px`}}>
      <h1>Lab Report</h1>
        {
            labReports.length > 0 ? 
            <table className='table table-striped'>
            <thead>
              <tr>
                <th>Lab Report ID</th>
                <th>Patient</th>
                <th>Issuer</th>
                <th>Issued</th>
              </tr>
            </thead>
            <tbody>
              {labReports.map((report) => (
                <tr key={report.labReportId}>
                  <td>{report.labReportId}</td>
                  <td>{report.patient.patientId}</td>
                  <td>{report.issuer != null ? report.issuer.employeeId : 'Not Available'}</td>
                  <td className='text-success'>{report.issued ? 'Yes' : <button className='btn btn-link'>Issue</button>}</td>
                </tr>
              ))}
            </tbody>
          </table>
          : 
          <Stack direction={'column'} alignItems={'center'}>
                <div className="spinner-border text-primary" role="status">
                </div>
                <span className="sr-only">Loading...</span>
            </Stack>
        }
    </div>
  );
};

export default LabReportResponse;
