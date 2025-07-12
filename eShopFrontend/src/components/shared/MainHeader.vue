<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useAppStore } from '../../store/app';

const appStore = useAppStore();
const menuItems = ref<HTMLElement | null>(null);
const isOpen = ref(false);

function menuToggle() {
    isOpen.value = !isOpen.value;
    if (menuItems.value) {
        menuItems.value.style.maxHeight = isOpen.value ? '200px' : '0px';
    }
}

onMounted(() => {
    if (menuItems.value) {
        menuItems.value.style.maxHeight = '0px';
    }
});

</script>

<template>
    <div class="header">
        <div class="container">
            <div class="navbar">
                <div class="logo">
                    <router-link to="/">
                        <img src="/images/logo.png" alt="Logo" width="125px" />
                    </router-link>
                </div>
                <nav>
                    <ul ref="menuItems">
                        <template v-for="(item, index) in appStore.menuLinks" :key="index">
                            <li v-if="item.show" :class="{ 'header-link-color': !item.isRouting }">
                                <template v-if="item.isRouting">
                                    <router-link :to="item.href" :class="{ 'active-link': item.active }" exact
                                        @click.prevent="appStore.setActive(index)">
                                        {{ item.name }}
                                    </router-link>
                                </template>
                                <template v-if="!item.isRouting">
                                    {{ item.name }}
                                </template>
                            </li>
                        </template>
                    </ul>
                </nav>
                <img src="/images/cart.png" width="30px" height="30px" />
                <img src="/images/menu.png" class="menu-icon" @click="menuToggle" />
            </div>
            <div class="row">
                <div class="col-2">
                    <h1>
                        Give Your Workout<br />
                        A New Style!
                    </h1>
                    <p>
                        Success isn't always about greatness. It's about consistency.
                        Consistent<br />
                        hard work gains success. Greatness will come.
                    </p>
                    <a href="" class="btn">Explore Now &#8594;</a>
                </div>
                <div class="col-2">
                    <img src="/images/image1.png" />
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.header {
    background: radial-gradient(#fff, #ffd6d6);
}

.header .row {
    margin-top: 70px;
}
</style>
