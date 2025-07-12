import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import { createPinia } from 'pinia';
import router from './router';
import toastPlugin from './plugins/toastPlugin';

const app = createApp(App);
app.use(toastPlugin);
app.use(createPinia());
app.use(router);

app.mount('#app')
