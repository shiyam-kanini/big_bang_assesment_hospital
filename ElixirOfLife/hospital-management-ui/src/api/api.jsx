import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:5000'
  });

  api.interceptors.request.use((config) => {
    const token = localStorage.getItem('token'); // Retrieve the JWT token from localStorage or any other source
    if (token) {
      config.headers.Authorization = `Bearer ${token}`; // Add the JWT token to the authorization header
    }
    return config;
  });
  export default api;