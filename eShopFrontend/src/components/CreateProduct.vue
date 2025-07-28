<script setup lang="ts">
import { onMounted, reactive, ref } from 'vue';
import Header from './shared/Header.vue';
import Pagination from './shared/Pagination.vue';
import DropDown from './shared/DropDown.vue';
import api from '../api/baseApi';
import type { ICProduct, IProduct } from '../interface/product';
import type { ICategory } from '../interface/category';
import TagsInput from './shared/TagsInput.vue';
// import { useToast } from '../composables/useToast';

// const $toast = useToast();

// const router = useRouter();

// const appStore = useAppStore();
// const authStore = useAuthStore();
const shops = ref<any[]>([]);
const categories = ref<ICategory[]>([]);
const subCategories = ref<any[]>([]);
const payload = reactive<ICProduct>({
    name: '',
    categoryId: '',
    price: 0,
    subCategoryId: '',
    shopId: '',
    tags: [],
    fileInfo: []
});

const handleLogin = async () => {
    console.log(payload)
 };

const onCategoryChange = async (value: any) => {
    const selectedId = value;
    console.log('Selected Category Object:', value);
    getSubCategory(selectedId);
};

const getCategory = async () => {
    const { data } = await api.get('/Category');
    console.log(data.data)
    categories.value = data.data.items;
    console.log(categories)
}

const getSubCategory = async (id:string) => {
    const { data } = await api.get(`/SubCategory?categoryId=${id}`);
    console.log(data.data)
    subCategories.value = data.data.items;
}

const getShop = async () => {
    const { data } = await api.get('/Shop');
    console.log(data.data)
    shops.value = data.data.items;
}
const onTagChange = (value: string[]) => {
    payload.tags = value
    console.log(payload)
}
onMounted(() => {
    getCategory();
    getShop();
})
</script>

<template>
    <Header />
    <div class="small-container">
        <div class="row">

            <div class="col-4">
                <form @submit.prevent="handleLogin">
                    <div>
                        <input v-model="payload.name" type="text" id="name" placeholder="name" />
                        <!-- <p v-if="loginErrors.email" class="error">{{ loginErrors.email }}</p> -->
                    </div>
                    <div>
                         <DropDown v-model="payload.categoryId" :options="categories" :disabled="!categories.length" :placeholder="'Select Category'" @onChange="onCategoryChange($event)"/>
                        <!-- <p v-if="loginErrors.password" class="error">{{ loginErrors.password }}</p> -->
                    </div>
                    <div>
                        <DropDown v-model="payload.subCategoryId" :options="subCategories" :disabled="!subCategories.length" :placeholder="'Select SubCategory'"/>
                        <!-- <p v-if="loginErrors.password" class="error">{{ loginErrors.password }}</p> -->
                    </div>
                    <div>
                         <DropDown v-model="payload.shopId" :options="shops" :disabled="!shops.length" :placeholder="'Select Shop'"/>
                        <!-- <p v-if="loginErrors.password" class="error">{{ loginErrors.password }}</p> -->
                    </div>
                    <div>
                         <TagsInput  v-model="payload.tags"  />
                        <!-- <p v-if="loginErrors.password" class="error">{{ loginErrors.password }}</p> -->
                    </div>
                    <button type="submit" class="btn">Login</button>
                </form>
            </div>

        </div>

    </div>

</template>

<style scoped></style>