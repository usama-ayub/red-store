<script setup lang="ts">

import { useLoaderStore } from '../../store/loader';

const loader = useLoaderStore();
</script>

<template>
    <transition name="fade">
        <div v-if="loader.loading" class="loader-overlay">
            <div class="loader-spinner"></div>
        </div>
    </transition>
</template>

<style scoped>
.loader-overlay {
    position: fixed;
    inset: 0;
    background: rgba(0, 0, 0, 0.3);
    z-index: 9999;
    display: flex;
    align-items: center;
    justify-content: center;
}

.loader-spinner {
    width: 60px;
    height: 60px;
    border: 6px solid #fff;
    border-top: 6px solid #ff523b;
    border-radius: 50%;
    animation: spin 1s linear infinite;
}

.fade-enter-active,
.fade-leave-active {
    transition: opacity 0.3s ease;
}

.fade-enter-from,
.fade-leave-to {
    opacity: 0;
}

@keyframes spin {
    to {
        transform: rotate(360deg);
    }
}
</style>