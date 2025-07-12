<script setup lang="ts">
import { ref } from 'vue';
import Header from './shared/Header.vue';
import Pagination from './shared/Pagination.vue';
import DropDown from './shared/DropDown.vue';

const currentPage = ref(1);
const totalItems = 55;
const pageSize = 10;
const totalPages = Math.ceil(totalItems / pageSize);
const onPageChange = (page: number) => {
  console.log(page)
}
</script>

<template>
  <Header />
  <div class="small-container">
    <div class="row row-2">
      <h2>All Shops</h2>
      <DropDown />
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
    </div>
    <Pagination v-model="currentPage" :pageSize="pageSize" :totalCount="totalItems" :totalPages="totalPages"
      @page-change="onPageChange" />
  </div>

</template>

<style scoped></style>
