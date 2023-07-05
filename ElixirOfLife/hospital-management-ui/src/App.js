import React,{lazy} from 'react'
import './App.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import '../node_modules/bootstrap/dist/js/bootstrap.bundle'
import { Routes,Route } from 'react-router-dom';
import Navbar from './components/navbarComponent/navbar';
import Footer from './components/staticComponents/footer';
import EmployeeRegistration from './components/registercomponents/registerEmployeeComponent'
import PatientRegistration from './components/registercomponents/registerPatientComponent';
import PatientLogin from './components/logincomponents/patientLoginComponent';
import EmployeeLogin from './components/logincomponents/employeeLoginComponent';
import RoomsPage from './components/roomComponent/roomsPage';
import AuthorizeRoom from './components/roomComponent/roomAuthorizePage';
import RequestSessionComponent from './components/doctorsessionComponents/requestSessionComponent';
import LabReportRequest from './components/labReportComponent/labReportRequest';
import LabReportResponse from './components/labReportComponent/labReportResponse';
import EnableEmployeePage from './components/adminComponents/enableEmployeePage';
import Unauthorized from './components/unauthorizedComponent/unauthorizedPage';
import RequireAuth from './components/auth/authrequire';
import DoctorPrescriptionPage from './components/doctorsessionComponents/doctorPrescriptionPage';
import EmployeeProfile from './components/profileComponent/doctorProfile';


const HomePage = lazy(() => import('./components/staticComponents/homePage'))
function App() {
  return (
    
    <div>
      <Navbar></Navbar>
        <div>
          <Routes>
            <Route path='/' element={
                  <React.Suspense
                    fallback={
                      <div className='d-flex justify-content-center' style={{ opacity: '.7' }} direction={'column'}>
                        <div className='spinner-border text-primary' role='status'></div>
                        <span className='sr-only'>Loading</span>
                      </div>
                    }
                  >
                    <HomePage />
                  </React.Suspense>} />
                  <Route element={<RequireAuth allowedRoles={['ROLEID002']}/>}>
                    
                  </Route>
                  <Route element={<RequireAuth allowedRoles={['ROLEID001','ROLEID002','ROLEID003', 'ROLEID004', "Patient"]}/>}>
                      <Route path='/labReportComponent/labReportResponse' element={<LabReportResponse></LabReportResponse>}></Route>
                      </Route>
                  <Route element={<RequireAuth allowedRoles={["Patient"]}/>}>
                      <Route path='/roomComponent/roomsPage' element={<RoomsPage></RoomsPage>}></Route>
                      <Route path='/doctorsessionComponents/requestSessionComponent' element={<RequestSessionComponent></RequestSessionComponent>}></Route>
                      <Route path='/labReportComponent/labReportRequest' element={<LabReportRequest></LabReportRequest>}></Route>
                  </Route>
                  <Route element={<RequireAuth allowedRoles={['ROLEID001']}/>}>
                      <Route path='/roomComponent/roomsAuthorizePage' element={<AuthorizeRoom></AuthorizeRoom>}></Route>
                      <Route path='/adminComponents/enableEmployeePage' element={<EnableEmployeePage></EnableEmployeePage>}></Route>
                  </Route>
                  <Route element={<RequireAuth allowedRoles={['ROLEID002']}/>}>
                      <Route path='/doctorsessionComponents/doctorPrescriptionPage' element={<DoctorPrescriptionPage></DoctorPrescriptionPage>}></Route>
                  </Route>
                  <Route path='/profileComponent/doctorProfile' element={<EmployeeProfile></EmployeeProfile>}></Route>


                  <Route path='/registerComponents/registerEmployeeComponent' element={<EmployeeRegistration></EmployeeRegistration>}></Route>
                  <Route path='/registerComponents/registerPatientComponent' element={<PatientRegistration></PatientRegistration>}></Route>
                  <Route path='/loginComponents/employeeLoginComponent' element={<EmployeeLogin></EmployeeLogin>}></Route>
                  <Route path='/loginComponents/patientLoginComponent' element={<PatientLogin></PatientLogin>}></Route>
                  <Route path='/unauthorizedComponent/unauthorizedPage' element={<Unauthorized></Unauthorized>}></Route>
         </Routes>
        </div>
        <Footer></Footer>
    </div>
  );
}

export default App;
