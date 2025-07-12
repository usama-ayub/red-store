import { getCurrentInstance } from 'vue';

export function useToast() {
  const { proxy } = getCurrentInstance()!;
  return proxy!.$toast as (type: 'success' | 'error' | 'warning', message: string) => void;
}