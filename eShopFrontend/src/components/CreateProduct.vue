<script setup lang="ts">
import { computed, onMounted, reactive, ref } from 'vue';
import api from '../api/baseApi';

import Header from './shared/Header.vue';
import DropDown from './shared/DropDown.vue';
import TagsInput from './shared/TagsInput.vue';

import type { ICProduct } from '../interface/product';
import type { ICategory } from '../interface/category';


const shops = ref<any[]>([]);
const categories = ref<ICategory[]>([]);
const subCategories = ref<any[]>([]);
const form = reactive<ICProduct>({
    name: '',
    categoryId: '',
    price: 0,
    subCategoryId: '',
    shopId: '',
    tags: [],
    fileInfo: []
});


const handleImageUpload = (e: Event) => {
    const target = e.target as HTMLInputElement
    const files = target.files
    if (!files) return

    Array.from(files).forEach(file => {
        const reader = new FileReader()
        reader.onload = (event) => {
            form.fileInfo.push({
                file,
                url: event.target?.result as string,
                main: false,
            })
        }
        reader.readAsDataURL(file)
    })
}

const setMainImage = (index: number) => {
    form.fileInfo.forEach((_f)=>{
             _f.main = false;
    });
    form.fileInfo[index].main = true;
}
const removeImage = (index: number) => {
    form.fileInfo.splice(index, 1)
}

// Submit form
const submitForm = async () => {
    const formData = new FormData()
    formData.append('Name', form.name)
    formData.append('CategoryId', form.categoryId)
    formData.append('SubCategoryId', form.subCategoryId)
    formData.append('ShopId', form.shopId)
    formData.append('Price', `${form.price}`)
    form.tags.forEach((tag,index)=>{
        formData.append(`Tags[${index}]`, tag)
    });
    form.fileInfo.forEach((value, index) => {
       formData.append(`FileInfo[${index}].file`, value.file)
       formData.append(`FileInfo[${index}].main`, `${value.main}`)
    });
    const data = await api.post('/Product',formData);
    console.log('Form submitted:', data);
    reset();
}

const reset = () => {
    form.categoryId = "";
    form.subCategoryId = "";
    form.shopId = "";
    form.name = "";
    form.tags = [];
    form.price = 1;
    form.fileInfo = [];
}

const onCategoryChange = async (value: any) => {
    const selectedId = value;
    console.log('Selected Category Object:', value);
    getSubCategory(selectedId);
};

const getCategory = async () => {
    const { data } = await api.get('/Category');
    categories.value = data.data.items;
}

const getSubCategory = async (id: string) => {
    const { data } = await api.get(`/SubCategory?categoryId=${id}`);
    subCategories.value = data.data.items;
}

// api.get('/some-endpoint', {
//   headers: {
//     'x-disable-loader': 'true',
//   },
// });
const getShop = async () => {
    const { data } = await api.get('/Shop');
    shops.value = data.data.items;
}
// const onTagChange = (value: string[]) => {
//     form.tags = value
//     console.log(form)
// }
onMounted(() => {
    getCategory();
    getShop();
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

                   <div class="input-container">
                     <input type="number" v-model="form.price" placeholder="Price" min="1" />
                 </div>

                <div class="select-wrapper">
                    <DropDown v-model="form.categoryId" :options="categories" :disabled="!categories.length" :placeholder="'Select Category'" @onChange="onCategoryChange($event)"/>
                </div>

                <div class="select-wrapper">
                     <DropDown v-model="form.subCategoryId" :options="subCategories" :disabled="!subCategories.length" :placeholder="'Select SubCategory'"/>
                </div>

                <div class="select-wrapper">
                   <DropDown v-model="form.shopId" :options="shops" :disabled="!shops.length" :placeholder="'Select Shop'"/>
                </div>

                <div class="select-wrapper">
                      <TagsInput  v-model="form.tags"  />
                </div>
                <!-- File Upload -->
                <input type="file" multiple accept="image/*" @change="handleImageUpload" />

                <!-- Image Preview -->
                <div class="image-preview-wrapper">
                    <div v-for="(fileInfo, index) in form.fileInfo" :key="index" class="image-preview">
                        <img :src="fileInfo.url" alt="Preview" />
                        <label>
                            <input type="checkbox" :checked="fileInfo.main" @change="setMainImage(index)" />
                            Main
                        </label>
                        <button type="button" @click="removeImage(index)">Remove</button>
                    </div>
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