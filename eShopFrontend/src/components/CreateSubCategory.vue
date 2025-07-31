<script setup lang="ts">
import { computed, onMounted, reactive, ref } from 'vue';
import api from '../api/baseApi';

import Header from './shared/Header.vue';
import DropDown from './shared/DropDown.vue';

import type { ICategory } from '../interface/category';

const categories = ref<ICategory[]>([]);
const form = reactive<{name:string, categoryId:string}>({
    name: '',
    categoryId: '',
});


// Submit form
const submitForm = async () => {
    const formData = new FormData()
    formData.append('Name', form.name)
    formData.append('CategoryId', form.categoryId)

    const data = await api.post('/SubCategory',formData);
    console.log('Form submitted:', data);
    reset();
}

const reset = () => {
    form.categoryId = "";
    form.name = "";
}

const onCategoryChange = async (value: any) => {
    console.log('Selected Category Object:', value);
};

const getCategory = async () => {
    const { data } = await api.get('/Category');
    categories.value = data.data.items;
}

// const onTagChange = (value: string[]) => {
//     form.tags = value
//     console.log(form)
// }
onMounted(() => {
    getCategory();
})
</script>

<template>
    <Header />
    <div class="small-container">
        <div class="row">
            <form @submit.prevent="submitForm" @keydown.enter.prevent class="form">
                <!-- Title -->
                 <div class="input-container">
                     <input type="text" v-model="form.name" placeholder="Name" />
                 </div>

                <div class="select-wrapper">
                    <DropDown v-model="form.categoryId" :options="categories" :disabled="!categories.length" :placeholder="'Select Category'" @onChange="onCategoryChange($event)"/>
                </div>

                <button type="submit" class="btn">Submit</button>
            </form>

        </div>

    </div>

</template>

<style scoped>
.form {
    display: flex;
    flex-direction: column;
    gap: 15px;
    max-width: 600px;
    margin: auto;
}

.input-container {
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    padding: 5px;
    border: 1px solid #ccc;
    border-radius: 5px;
    max-width: 400px;
}

.input-container input {
    border: none;
    flex: 1;
    padding: 5px;
    min-width: 100px;
    outline: none;
}

.select-wrapper {
    display: flex;
    flex-direction: column;
}

.image-preview-wrapper {
    display: flex;
    flex-wrap: wrap;
    gap: 10px;
    margin-top: 10px;
}

.image-preview {
    width: 150px;
    border: 1px solid #ccc;
    padding: 10px;
    text-align: center;
}

.image-preview img {
    max-width: 100%;
    height: auto;
}

.image-preview label {
    display: block;
    margin-top: 5px;
}

.image-preview button {
    margin-top: 5px;
    background-color: #f44336;
    color: white;
    border: none;
    padding: 5px;
    cursor: pointer;
}

form .btn {
  width: 100%;
  border: none;
  cursor: pointer;
  margin: 10px 0;
}

form .btn:focus {
  outline: none;
}
</style>