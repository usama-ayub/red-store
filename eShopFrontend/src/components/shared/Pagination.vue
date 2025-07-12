<script setup lang="ts">
import { computed, ref } from 'vue';

const props = defineProps<{
  pageSize: number;
  totalCount: number;
  totalPages: number;
  modelValue: number; // current page
}>();
const emit = defineEmits<{
  (e: 'update:modelValue', value: number): void;
  (e: 'page-change', value: number): void;
}>();

const pages = computed(() => {
  return Array.from({ length: props.totalPages }, (_, i) => i + 1);
});

function changePage(page: number) {
  if (page >= 1 && page <= props.totalPages && page !== props.modelValue) {
    emit('update:modelValue', page);
    emit('page-change', page);
  }
}
</script>

<template>
  <div class="page-btn">
    <span v-for="page in pages" :key="page" :class="{ active: page === modelValue }" @click="changePage(page)">
      {{ page }}
    </span>

    <span @click="changePage(modelValue + 1)" v-if="modelValue < totalPages">
      &#8594;
    </span>
  </div>
</template>

<style scoped>
.page-btn {
  margin: 0 auto 80px;
}

.page-btn span {
  display: inline-block;
  border: 1px solid #ff523b;
  margin-left: 10px;
  width: 40px;
  height: 40px;
  text-align: center;
  line-height: 40px;
  cursor: pointer;
  transition: 0.2s;
}

.page-btn span:hover {
  background: #ff523b;
  color: #fff;
}

.page-btn .active {
  background: #ff523b;
  color: #fff;
}
</style>
