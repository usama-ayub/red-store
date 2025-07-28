import axios from 'axios';
import { toast } from '../utils/toastController';

const BASE_URL = import.meta.env.VITE_API_URL;

const api = axios.create({
  baseURL: BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('auth-token');
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

api.interceptors.response.use(
    (response) => {
    if (response.status >= 200 && response.status < 300) {
      const {data} = response
      toast('success', data.message);
    }
    return response;
  },
  (error) => {
    const { code, data, response, message } = error;
    if (response && response.status === 401) {
      toast('error', data.message);
    } else if (code == 'ERR_NETWORK') {
      toast('error', message);
    }
    return Promise.reject(error);
  }
);

export default api;
