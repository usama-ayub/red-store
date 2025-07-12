<script setup lang="ts">
import { ref } from 'vue';
import MainHeader from './shared/MainHeader.vue';

const BASE_URL = import.meta.env.VITE_API_URL;
console.log(BASE_URL)
const count = ref(0)
console.log(count)
</script>

<template>
  <MainHeader />
  <div class="categories">
    <div class="small-container">
      <div class="row">
        <div class="col-3">
          <img src="/images/category-1.jpg" />
        </div>
        <div class="col-3">
          <img src="/images/category-2.jpg" />
        </div>
        <div class="col-3">
          <img src="/images/category-3.jpg" />
        </div>
      </div>
    </div>
  </div>
  <!-- Features Product -->
  <div class="small-container">
    <h2 class="feature-product-title">Featured Products</h2>
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
    <h2 class="feature-product-title">Latest Products</h2>
    <div class="row">
      <div class="col-4">
        <img src="/images/product-5.jpg" />
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
        <img src="/images/product-6.jpg" />
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
        <img src="/images/product-7.jpg" />
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
        <img src="/images/product-8.jpg" />
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
        <img src="/images/product-9.jpg" />
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
        <img src="/images/product-10.jpg" />
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
        <img src="/images/product-11.jpg" />
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
        <img src="/images/product-12.jpg" />
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
  <!-- Offer -->
  <div class="offer">
    <div class="small-container">
      <div class="row">
        <div class="col-2">
          <img class="offer-img" src="/images/exclusive.png" alt="">
        </div>
        <div class="col-2">
          <p>Exclusive Available on RedStore</p>
          <h1>Smart Band 4</h1>
          <small>Success isn't always about greatness. It's about consistency. Consistent hard work gains success.
            Greatness will come.</small><br />
          <a href="" class="btn">Buy Now &#8594;</a>
        </div>
      </div>
    </div>
  </div>
  <!-- testimonial -->
  <div class="testimonial">
    <div class="small-container">
      <div class="row">
        <div class="col-3">
          <i class="fa fa-quote-left testimonial-quote-icon"></i>
          <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Tenetur incidunt, minima enim mollitia fugiat,
            provident eum amet aperiam perspiciatis autem facere, atque corporis repudiandae cum. Optio numquam quam
            voluptatem quaerat.</p>
          <div class="rating">
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-regular fa-star"></i>
          </div>
          <img src="/images/user-1.png" alt="">
          <h3>Sean Parker</h3>
        </div>
        <div class="col-3">
          <i class="fa fa-quote-left testimonial-quote-icon"></i>
          <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Tenetur incidunt, minima enim mollitia fugiat,
            provident eum amet aperiam perspiciatis autem facere, atque corporis repudiandae cum. Optio numquam quam
            voluptatem quaerat.</p>
          <div class="rating">
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-regular fa-star"></i>
          </div>
          <img src="/images/user-2.png" alt="">
          <h3>Sean Parker</h3>
        </div>
        <div class="col-3">
          <i class="fa fa-quote-left testimonial-quote-icon"></i>
          <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Tenetur incidunt, minima enim mollitia fugiat,
            provident eum amet aperiam perspiciatis autem facere, atque corporis repudiandae cum. Optio numquam quam
            voluptatem quaerat.</p>
          <div class="rating">
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-regular fa-star"></i>
          </div>
          <img src="/images/user-3.png" alt="">
          <h3>Sean Parker</h3>
        </div>
      </div>
    </div>
  </div>
  <!-- Brands -->
  <div class="brands">
    <div class="small-container">
      <div class="row">
        <div class="col-5">
          <img src="/images/logo-godrej.png" />
        </div>
        <div class="col-5">
          <img src="/images/logo-oppo.png" />
        </div>
        <div class="col-5">
          <img src="/images/logo-paypal.png" />
        </div>
        <div class="col-5">
          <img src="/images/logo-philips.png" />
        </div>
        <div class="col-5">
          <img src="/images/logo-coca-cola.png" />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* Offer */
.offer {
  background: radial-gradient(#fff, #ffd6d6);
  margin-top: 80px;
  padding: 30px 0;
}

.col-2 .offer-img {
  padding: 50px;
}

/* Brand */
.brands {
  margin: 100px auto;
}

.col-5 {
  width: 160px;
}

.col-5 img {
  width: 100%;
  cursor: pointer;
  filter: grayscale(100%);
}

.col-5 img:hover {
  filter: grayscale(0);
}

/* Testimonial */
.testimonial {
  padding-top: 100px;
}

.testimonial .col-3 {
  text-align: center;
  padding: 40px 20px;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.1);
  cursor: pointer;
  transition: transform 0.5s;
}

.testimonial .col-3 img {
  width: 50px;
  margin-top: 20px;
  border-radius: 50%;
}

.testimonial .col-3:hover {
  transform: translateY(-10px);
}

.testimonial .testimonial-quote-icon {
  font-size: 34px;
  color: #ff523b;
}

.testimonial .col-3 p {
  font-size: 12px;
  margin: 12px 0;
  color: #777;
}

.testimonial .col-3 h3 {
  font-weight: 600;
  color: #555;
  font-size: 16px;
}
</style>
