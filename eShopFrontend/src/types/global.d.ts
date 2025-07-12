import { ComponentCustomProperties } from 'vue';

declare module '@vue/runtime-core' {
  interface ComponentCustomProperties {
    $toast: (type: 'success' | 'error' | 'warning', message: string) => void;
  }
}