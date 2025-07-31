<script setup lang="ts">
import { onMounted, ref } from 'vue';
import Header from './shared/Header.vue';
import Pagination from './shared/Pagination.vue';
import DropDown from './shared/DropDown.vue';
import api from '../api/baseApi';

const sortOptions = [
  { name: 'Short by price', id: 'Short by price' },
  { name: 'Short by popularity', id: 'Short by popularity' },
  { name: 'Short by rating', id: 'Short by rating' },
  { name: 'Short by sale', id: 'Short by sale' },
];
const currentPage = ref(1);
const totalItems = ref(1);
const pageSize = ref(1);
const totalPages = ref(1);
const shops = ref<any[]>([]);
const sortValue = ref<string>('');
const imageUrl = (imagePath: string) => import.meta.env.VITE_APP_URL + imagePath;
const getShop = async () => {
  const { data } = await api.get('/Shop');
  console.log(data.data)
  shops.value = data.data.items;
  currentPage.value = data.data.currentPage;
  totalItems.value = data.data.totalCount;
  pageSize.value = data.data.pageSize;
  totalPages.value = data.data.totalPages;
}
const onPageChange = (page: number) => {
  console.log(page)
}
const onSortChange = async (value: number | string | Array<number | string>) => {
  console.log(value)
};
onMounted(() => {
  getShop()
})
</script>

<template>
  <Header />
  <div class="small-container">
    <div class="row row-2">
      <h2>All Shops</h2>
      <DropDown v-model="sortValue" :options="sortOptions" :disabled="!sortOptions.length"
        :placeholder="'Default Sorting'" @onChange="onSortChange($event)" />
    </div>
    <div class="row">
      <div class="col-4" v-for="(shop, index) in shops" :key="index">
         <router-link :to="`/shop/${shop.id}`">
        <img :src="imageUrl(shop.images[0].url)" alt="Product Image" />
        <h4>{{ shop.name }}</h4>
        <p>{{ shop.latitude }}, {{ shop.longtitude }}</p>
        </router-link>
      </div>
    </div>
    <Pagination v-model="currentPage" :pageSize="pageSize" :totalCount="totalItems" :totalPages="totalPages"
      @page-change="onPageChange" />
  </div>

</template>

<style scoped></style>
