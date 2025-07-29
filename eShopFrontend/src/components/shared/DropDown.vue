<script setup lang="ts">
import { ref } from 'vue';

const props = defineProps<{
  placeholder: string;
  options: Array<any>;
  disabled: boolean;
  modelValue: string | number;
  filter?: boolean;
  multiSelection?:boolean;
}>();

const emit = defineEmits<{
  (e: 'update:modelValue', value: number | string | Array<number | string>): void;
  (e: 'onChange', value: number | string | Array<number | string>): void;
}>();
 
 const onChange = (event: Event)=>{
   const selectedId = (event.target as HTMLSelectElement).value;
     emit('onChange', selectedId);
     emit('update:modelValue', selectedId);
 }
</script>

<template>

  <select v-model="props.modelValue" :disabled="props.disabled" @change="onChange($event)">
    <option disabled value="">{{ props.placeholder }}</option>
    <option v-for="option in props.options" :key="option.id" :value="option.id">
      {{ option.name }}
    </option>
  </select>

</template>

<style scoped>
select {
  /* border: 1px solid #ff523b;
  padding: 5px; */

   display: flex;
    flex-wrap: wrap;
    align-items: center;
    padding: 5px;
    border: 1px solid #ff523b;
    border-radius: 5px;
    max-width: 400px;
}

select:focus {
  outline: none;
}
</style>
