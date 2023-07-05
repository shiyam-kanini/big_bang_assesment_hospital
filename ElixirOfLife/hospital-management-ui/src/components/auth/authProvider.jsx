import { createContext, useState, useEffect } from 'react';

const AuthContext = createContext({});

export const Authprovider = ({ children }) => {
  const [auth, setAuth] = useState({
    loginLog: {
      sessionId: localStorage.getItem('sessionId'),
      loginId: localStorage.getItem('loginId'),
      token: localStorage.getItem('token'),
      isLoggedIn: localStorage.getItem('isLoggedIn') === 'true',
      role: localStorage.getItem('role'),
    },
  });

  useEffect(() => {
    const storedAuth = JSON.parse(localStorage.getItem('auth'));
    if (storedAuth) {
      setAuth(storedAuth);
    }
  }, []);

  const updateAuth = (sId, loginid, jwttoken, isloggedin, r) => {
    const newAuth = {
      loginLog: {
        sessionId: sId,
        loginId: loginid,
        token: jwttoken,
        isLoggedIn: isloggedin,
        role: r,
      },
    };

    window.localStorage.setItem('sessionId', sId);
    window.localStorage.setItem('loginId', loginid);
    window.localStorage.setItem('token', jwttoken);
    window.localStorage.setItem('isLoggedIn', isloggedin);
    window.localStorage.setItem('role', r);
    window.localStorage.setItem('auth', JSON.stringify(newAuth));

    setAuth(newAuth);
  };

  return (
    <AuthContext.Provider value={{ auth, updateAuth }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
