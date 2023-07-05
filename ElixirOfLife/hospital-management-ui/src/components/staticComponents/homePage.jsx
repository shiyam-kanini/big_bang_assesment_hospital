import React from 'react';
import hospitalImage from 'E:/big_bang_assesment_hospital/ElixirOfLife/hospital-management-ui/src/assets/img/hospital.jpg';
const height = window.screen.height - 100;


const HomePage = () => {
  return (
    <div className="container" style={{height : `${height}px`, position :'relative',top:'50px'}}>
      <header>
      </header>
      <main>
        <section className="row">
          <div className="col-md-6">
            <img src={hospitalImage} alt="Hospital" className="img-fluid" />
          </div>
          <div className="col-md-6">
            <h2>About Us</h2>
            <p>
              Elixir of Life Hospital is dedicated to providing exceptional healthcare services to our patients. We strive to offer comprehensive medical care, advanced treatments, and compassionate support for individuals and families.
            </p>
          </div>
        </section>
        <section>
          <h2 className="text-center my-4 basic">Our Services</h2>
          <div className="row">
            <div className="col-md-6">
              <div className="card" >
                <div className="card-body" >
                  <h5 className="card-title" >Emergency Care</h5>
                  <p className="card-text">24/7 emergency medical care.</p>
                </div>
              </div>
            </div>
            <div className="col-md-6">
              <div className="card">
                <div className="card-body">
                  <h5 className="card-title">General Surgery</h5>
                  <p className="card-text">Expert surgical procedures.</p>
                </div>
              </div>
            </div>
            <div className="col-md-6">
              <div className="card">
                <div className="card-body">
                  <h5 className="card-title">Scanning Laboratories</h5>
                  <p className="card-text">High tech tools for scanning and imaging.</p>
                </div>
              </div>
            </div>
            <div className="col-md-6">
              <div className="card">
                <div className="card-body">
                  <h5 className="card-title">Internal Medics</h5>
                  <p className="card-text">Large inventory for drugs.</p>
                </div>
              </div>
            </div>
          </div>
        </section>
        
      </main>
      
    </div>
  );
};

export default HomePage;
