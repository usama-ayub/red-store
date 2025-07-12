// src/store/auth.ts
import { defineStore } from 'pinia';
import api from '../api/baseApi';

interface AuthState {
  username: string;
  token: string;
}

export const useAuthStore = defineStore('auth', {
  state: (): AuthState => ({
    username: 'string',
    token: localStorage.getItem('auth-token') || '',
  }),

  getters: {
    isAuthenticated: (state) => !!state.token,
  },

  actions: {
    async login(email: string, password: string) {
      const response = await api.post('/User/login', { email, password });
      this.token = response.data.data.token;
      this.username = response.data.data.userName;
      localStorage.setItem('auth-token', this.token);
      return response.data;
    },

    async register(username: string, email: string, password: string) {
      const response = await api.post('/register', { username, email, password });
      this.token = response.data.data.token;
      this.username = response.data.data.userName;
      localStorage.setItem('auth-token', this.token);
    },

    logout() {
      this.token = '';
      this.username = '';
      localStorage.removeItem('auth-token');
    },
  },
});
