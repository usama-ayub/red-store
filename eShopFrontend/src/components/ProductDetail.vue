<script setup lang="ts">
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import Header from './shared/Header.vue';

const route = useRoute();
const productId = route.params.id;
console.log(productId)
const productImg = ref('/images/gallery-1.jpg')
const thumbnails = [
  '/images/gallery-1.jpg',
  '/images/gallery-2.jpg',
  '/images/gallery-3.jpg',
  '/images/gallery-4.jpg'
]

function changeImage(img: string) {
  productImg.value = img
}

</script>

<template>
  <Header/>
  <div class="small-container single-product">
    <div class="row">
      <div class="col-2">
        <img :src="productImg" width="100%" />
        <div class="small-img-row">
          <div class="small-img-col" v-for="(thumb, index) in thumbnails" :key="index">
            <img :src="thumb" width="100%" class="small-img" @click="changeImage(thumb)" />
          </div>
        </div>
      </div>
      <div class="col-2">
        <p>Home / T-Shirt</p>
        <h1>Read Print T-Shirt By HRX</h1>
        <h4>$50.00</h4>
        <select>
          <option>Select Size</option>
          <option>XXl</option>
          <option>XL</option>
          <option>Large</option>
          <option>Medium</option>
          <option>Size</option>
        </select>
        <input type="Number" value="1">
        <a href="" class="btn">Add To Cart</a>
        <h3>Product Details <i class="fa fa-indent"></i></h3>
        <br />
        <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quia asperiores, iusto iste assumenda fugiat
          suscipit expedita numquam totam qui repellendus, minus, illum vero aliquam nisi? Commodi expedita minus quis
          quisquam!</p>
      </div>
    </div>
  </div>
  <div class="small-container">
    <div class="row row-2">
      <h2>Related Products</h2>
      <!-- <p>View More</p> -->
       <router-link class="active" to="/product">View More</router-link>
    </div>
  </div>
  <div class="small-container">
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
  </div>

</template>

<style scoped>
.single-product {
  margin-top: 80px;
}

.single-product .col-2 img {
  padding: 0;
}

.single-product .col-2 {
  padding: 20px;
}

.single-product h {
  margin: 20px 0;
  font-size: 22px;
  font-weight: bold;
}

.single-product select {
  display: block;
  padding: 10px;
  margin-top: 20px;
}

.single-product input {
  width: 50px;
  height: 40px;
  padding-left: 10px;
  font-size: 20px;
  margin-right: 10px;
  border: 1px solid #ff523b;
}

.single-product input:focus {
  outline: none;
}

.single-product i {
  color: #ff523b;
  margin-left: 10px;
}

.small-img-row {
  display: flex;
  justify-content: space-between;
}

.small-img-col {
  flex-basis: 24%;
  cursor: pointer;
}
/* .row-2 p {
  color: #ff523b;
} */
@media only screen and (max-width:600px) {
  .single-product .row {
    text-align: left;
  }
.single-product h1 {
    font-size: 26px;
    line-height: 32px;
  }
  .single-product .col-2 {
    padding: 20px 0;
  }
}
</style>
