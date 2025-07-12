<template>
  <div id="toast-container">
    <div
      v-for="(toast, index) in toasts"
      :key="index"
      :class="['toast', toast.type]"
    >
      {{ toast.message }}
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive } from 'vue';

interface ToastMessage {
  type: 'success' | 'error' | 'warning';
  message: string;
}

export default defineComponent({
  name: 'Toast',
  setup() {
    const toasts = reactive<ToastMessage[]>([]);

    const showToast = (type: ToastMessage['type'], message: string) => {
      toasts.push({ type, message });
      setTimeout(() => {
        toasts.shift();
      }, 5000);
    };

    return {
      toasts,
      showToast,
    };
  },
});
</script>

<style scoped>
#toast-container {
  position: fixed;
  /* top: 20px;
  right: 20px; */
    bottom: 20px;
  right: 20px;
  z-index: 9999;
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.toast {
  min-width: 250px;
  padding: 15px 20px;
  border-radius: 5px;
  color: white;
  font-weight: 500;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.2);
  animation: slideIn 0.3s ease-out, fadeOut 0.5s ease-in 4.5s forwards;
}

.toast.success {
  background-color: #28a745;
}

.toast.error {
  background-color: #dc3545;
}

.toast.warning {
  background-color: #ffc107;
  color: black;
}

@keyframes slideIn {
  from {
    opacity: 0;
    transform: translateX(100%);
  }
  to {
    opacity: 1;
    transform: translateX(0);
  }
}

@keyframes fadeOut {
  to {
    opacity: 0;
    transform: translateX(100%);
  }
}
</style>
