<script setup lang="ts">
import { onMounted, ref } from 'vue';
import Header from './shared/Header.vue';
import Pagination from './shared/Pagination.vue';
import DropDown from './shared/DropDown.vue';
import api from '../api/baseApi';
import type { IProduct } from '../interface/product';
// import { useToast } from '../composables/useToast';

// const $toast = useToast();

const currentPage = ref(1);
const totalItems = 55;
const pageSize = 10;
const totalPages = Math.ceil(totalItems / pageSize);
const products = ref<IProduct[]>([]);
const imageUrl = (imagePath:string) => import.meta.env.VITE_APP_URL + imagePath;
const getProduct = async () => {
  const { data } = await api.get('/Product');
  console.log(data.data)
  products.value = data.data.items;
}
const onPageChange = (page: number) => {
  console.log(page)
}
onMounted(() => {
  getProduct()
})

</script>

<template>
  <Header />
  <div class="small-container">
    <div class="row row-2">
      <h2>All Products</h2>
      <DropDown />
    </div>
    <div class="row">
      <!-- products -->

        <div class="col-4" v-for="(product, index) in products" :key="index">
    <img :src="imageUrl(product.images[0].url)" alt="Product Image" />
    <h4>{{ product.name }}</h4>
    <div class="rating">
      <i class="fa-solid fa-star"></i>
      <i class="fa-solid fa-star"></i>
      <i class="fa-solid fa-star"></i>
      <i class="fa-solid fa-star"></i>
      <i class="fa-regular fa-star"></i>
    </div>
    <p>${{ product.price }}</p>
  </div>

      <!-- <div class="col-4" v-for="(product, index) in products" :key="index">
        <img src="{{product.name}}" />
        <h4>{{product.images[0].url}}</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>${{product.price}}</p>
      </div> -->
      <!-- <div class="col-4">
        <img src="/images/product-2.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-3.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-4.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div> -->
    </div>
    <!-- <div class="row">
      <div class="col-4">
        <img src="/images/product-1.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-2.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-3.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-4.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
    </div>
    <div class="row">
      <div class="col-4">
        <img src="/images/product-1.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-2.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-3.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
      <div class="col-4">
        <img src="/images/product-4.jpg" />
        <h4>Red Printed T-Shirt</h4>
        <div class="rating">
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-solid fa-star"></i>
          <i class="fa-regular fa-star"></i>
        </div>
        <p>$50.00</p>
      </div>
    </div> -->
    <Pagination v-model="currentPage" :pageSize="pageSize" :totalCount="totalItems" :totalPages="totalPages"
      @page-change="onPageChange" />
  </div>

</template>

<style scoped></style>
