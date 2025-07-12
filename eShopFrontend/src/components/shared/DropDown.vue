<script setup lang="ts">
import { ref } from 'vue';

</script>

<template>

    <select>
      <option>Default Sorting</option>
      <option>Short by price</option>
      <option>Short by popularity</option>
      <option>Short by rating</option>
      <option>Short by sale</option>
    </select>
    
</template>

<style scoped>
select {
  border: 1px solid #ff523b;
  padding: 5px;
}

select:focus {
  outline: none;
}
</style>
