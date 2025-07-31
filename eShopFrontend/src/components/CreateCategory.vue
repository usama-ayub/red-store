<script setup lang="ts">
import { onMounted, reactive } from 'vue';
import api from '../api/baseApi';

import Header from './shared/Header.vue';


const form = reactive<{
    name: string;
    fileInfo: Array<{ file: File; url: string }>;
}>({
    name: '',
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
            })
        }
        reader.readAsDataURL(file)
    })
}

const removeImage = (index: number) => {
    form.fileInfo.splice(index, 1)
}

// Submit form
const submitForm = async () => {
    const formData = new FormData()
    formData.append('Name', form.name)
    form.fileInfo.forEach((value) => {
        formData.append(`File`, value.file);
    });

    const data = await api.post('/Category', formData);
    console.log('Form submitted:', data);
    reset();
}

const reset = () => {
    form.name = "";
    form.fileInfo = [];
}

onMounted(() => { })
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

                <input type="file" multiple accept="image/*" @change="handleImageUpload" />
                <div class="image-preview-wrapper">
                    <div v-for="(fileInfo, index) in form.fileInfo" :key="index" class="image-preview">
                        <img :src="fileInfo.url" alt="Preview" />
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