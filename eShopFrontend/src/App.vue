<script setup lang="ts">
import { onMounted } from 'vue';
import Footer from './components/shared/Footer.vue';
import { useAuthStore } from './store/auth';
import { useAppStore } from './store/app';

const appStore = useAppStore();
const authStore = useAuthStore();

onMounted(() => {
  if (authStore.isAuthenticated) {
    appStore.setAuthantication();
  }
});
</script>

<template>
  <router-view />
  <Footer />
</template>

<style scoped></style>
