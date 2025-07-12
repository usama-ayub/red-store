<script setup lang="ts">
import { ref } from 'vue';
import Header from './shared/Header.vue';


</script>

<template>
<Header/>
  <div class="small-container cart-page">
    <table>
      <tr>
        <th>Product</th>
        <th>Quantity</th>
        <th>Sub Total</th>
      </tr>
      <tr>
        <td>
          <div class="cart-info">
            <img src="/images/buy-1.jpg" alt="">
            <div>
              <p>Product Name</p>
              <small>Price: $50.00</small><br />
              <a href="">Remove</a>
            </div>
          </div>
        </td>
        <td><input type="number" value="1"></td>
        <td>$50.00</td>
      </tr>
      <tr>
        <td>
          <div class="cart-info">
            <img src="/images/buy-2.jpg" alt="">
            <div>
              <p>Product Name</p>
              <small>Price: $50.00</small><br />
              <a href="">Remove</a>
            </div>
          </div>
        </td>
        <td><input type="number" value="1"></td>
        <td>$50.00</td>
      </tr>
      <tr>
        <td>
          <div class="cart-info">
            <img src="/images/buy-3.jpg" alt="">
            <div>
              <p>Product Name</p>
              <small>Price: $50.00</small><br />
              <a href="">Remove</a>
            </div>
          </div>
        </td>
        <td><input type="number" value="1"></td>
        <td>$50.00</td>
      </tr>
      <tr>
        <td>
          <div class="cart-info">
            <img src="/images/buy-1.jpg" alt="">
            <div>
              <p>Product Name</p>
              <small>Price: $50.00</small><br />
              <a href="">Remove</a>
            </div>
          </div>
        </td>
        <td><input type="number" value="1"></td>
        <td>$50.00</td>
      </tr>
      <tr>
        <td>
          <div class="cart-info">
            <img src="/images/buy-2.jpg" alt="">
            <div>
              <p>Product Name</p>
              <small>Price: $50.00</small><br />
              <a href="">Remove</a>
            </div>
          </div>
        </td>
        <td><input type="number" value="1"></td>
        <td>$50.00</td>
      </tr>
      <tr>
        <td>
          <div class="cart-info">
            <img src="/images/buy-3.jpg" alt="">
            <div>
              <p>Product Name</p>
              <small>Price: $50.00</small><br />
              <a href="">Remove</a>
            </div>
          </div>
        </td>
        <td><input type="number" value="1"></td>
        <td>$50.00</td>
      </tr>
    </table>

    <div class="totla-price">
      <table>
        <tr>
          <td>Sub Total</td>
          <td>$200</td>
        </tr>
        <tr>
          <td>Tax</td>
          <td>$10</td>
        </tr>
        <tr>
          <td>Total</td>
          <td>$210</td>
        </tr>
      </table>
    </div>

  </div>

</template>

<style scoped>
.cart-page {
  margin: 80px auto;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th {
  text-align: left;
  padding: 5px;
  color: #fff;
  background: #ff523b;
  font-weight: normal;
}

td {
  padding: 10px 5px;
}

td input {
  width: 45px;
  height: 30px;
  padding: 5px;
}

td a {
  color: #ff523b;
  font-size: 12px;
}

td img {
  width: 80px;
  height: 80px;
  margin-right: 10px;
}
.cart-info {
  display: flex;
  flex-wrap: wrap;
}

.totla-price{
  display: flex;
  justify-content: flex-end;
}
.totla-price table{
  border-top: 3px solid #ff523b;
  width: 100%;
  max-width: 430px;
}
td:last-child{
  text-align: right;
}
th:last-child{
  text-align: right;
}
@media only screen and (max-width:600px) {
  .cart-info p{
display: none;
  }
}
</style>
