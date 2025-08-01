import axios from 'axios';
import { toast } from '../utils/toastController';
import { useLoaderStore } from '../store/loader';
import { storeToRefs } from 'pinia';

const BASE_URL = import.meta.env.VITE_API_URL;

const api = axios.create({
  baseURL: BASE_URL,
});

api.interceptors.request.use(
  (config) => {
    const loader = useLoaderStore();
    if (!config.headers['x-disable-loader']) {
      loader.startLoading();
    }
    const token = localStorage.getItem('auth-token');
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    const loader = useLoaderStore();
    loader.stopLoading();
    return Promise.reject(error);
  }
);

api.interceptors.response.use(
  (response) => {
    const loader = useLoaderStore();
    loader.stopLoading();

    if (response.status >= 200 && response.status < 300) {
      const { data } = response
      toast('success', data.message);
    }
    return response;
  },
  (error) => {
    const loader = useLoaderStore();
    loader.stopLoading();
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
