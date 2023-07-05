import React from 'react';

const Footer = () => {
  return (
    <footer  style={{backgroundColor:'rgba(78, 141, 199,.5)', height:'150px', position:'absolute',width:'100%'}}>
        <section >
          <h2 className="text-center">Contact Us</h2>
          <p className="text-center">
            Phone: +1 (123) 456-7890<br />
            Email: info@elixiroflifehospital.com
          </p>
        </section>
        <footer className="text-center my-4">
        <p>&copy; {new Date().getFullYear()} Elixir of Life Hospital. All rights reserved.</p>
      </footer>
    </footer>
  );
};

export default Footer;
