type ToastType = 'success' | 'error' | 'warning';

let toastFn: ((type: ToastType, message: string) => void) | null = null;

export function setToastHandler(fn: typeof toastFn) {
  toastFn = fn;
}

export function toast(type: ToastType, message: string) {
  if (toastFn) {
    toastFn(type, message);
  } else {
    console.warn('[toastController] Toast handler not initialized');
  }
}