import type { App } from 'vue';
import { createApp } from 'vue';
import Toast from '../components/shared/Toast.vue';
import { setToastHandler } from '../utils/toastController';

export default {
  install(app: App) {
    const toastApp = createApp(Toast);
    const toastRoot = document.createElement('div');
    document.body.appendChild(toastRoot);
    const toastInstance = toastApp.mount(toastRoot) as any;
    const show = (type: 'success' | 'error' | 'warning', message: string) => {
      toastInstance.showToast(type, message);
    };
    
    setToastHandler(show);
    app.config.globalProperties.$toast = show;
  },
};