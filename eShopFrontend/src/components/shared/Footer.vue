<script setup lang="ts">
import { ref } from 'vue'
</script>

<template>
  <div class="footer">
    <div class="container">
      <div class="row">
        <div class="footer-col-1">
          <h3>Download Our App</h3>
          <p>Download Our App For Android and Ios Mobile Phone</p>
          <div class="app-logo">
            <img src="/images/app-store.png" />
            <img src="/images/play-store.png" />
          </div>
        </div>
        <div class="footer-col-2">
          <img src="/images/logo-white.png" />
          <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloribus dolorum quibusdam iure aliquam quod
            saepe temporibus.</p>
        </div>
        <div class="footer-col-3">
          <h3>Useful Links</h3>
          <ul>
            <li>Coupons</li>
            <li>Blog Post</li>
            <li>Return Policy</li>
            <li>Join Affiliate</li>
          </ul>
        </div>
        <div class="footer-col-4">
          <h3>Follow Us</h3>
          <ul>
            <li>FaceBook</li>
            <li>Twitter</li>
            <li>Instagram</li>
            <li>YouTube</li>
          </ul>
        </div>
      </div>
      <hr>
      <p class="copy-right">Copyright 2025 - RedStore</p>
    </div>
  </div>
</template>

<style scoped>
.footer {
  background: #000;
  color: #8a8a8a;
  font-size: 14px;
  padding: 60px 0 20px;
}

.footer p {
  color: #8a8a8a;
}

.footer h3 {
  color: #fff;
  margin-bottom: 20px;
}

.footer-col-1,
.footer-col-2,
.footer-col-3,
.footer-col-4 {
  min-width: 250px;
  margin-bottom: 20px;
}

.footer-col-1 {
  flex-basis: 30%;
}

.footer-col-2 {
  flex: 1;
  text-align: center;
}

.footer-col-2 img {
  width: 180px;
  margin-bottom: 20px;
}

.footer-col-3,
.footer-col- {
  flex-basis: 12%;
  text-align: center;
}

ul {
  list-style-type: none;
}

.app-logo {
  margin-top: 20px;
}

.app-logo img {
  width: 140px;
}

.footer hr {
  border: none;
  background: #b5b5b5;
  height: 1px;
  margin: 20px 0;
}

.copy-right {
  text-align: center;
}
</style>
