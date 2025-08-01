import { defineStore } from 'pinia';

export const useLoaderStore = defineStore('loader', {
  state: () => ({
    loading: false,
    count: 0, // for concurrent requests
  }),
  actions: {
    startLoading() {
      this.count++;
      this.loading = true;
    },
    stopLoading() {
      this.count = Math.max(0, this.count - 1);
      this.loading = this.count > 0;
    },
    reset() {
      this.count = 0;
      this.loading = false;
    },
  },
});