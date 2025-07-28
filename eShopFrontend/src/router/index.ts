import { createRouter, createWebHistory } from 'vue-router';
import Main from '../components/Main.vue';
import Product from '../components/Product.vue';
import ProductDetail from '../components/ProductDetail.vue';
import Account from '../components/Account.vue';
import Cart from '../components/Cart.vue';
import { useAuthStore } from '../store/auth';
import Shop from '../components/Shop.vue';
import CreateProduct from '../components/CreateProduct.vue';

const routes = [ 
   { path: '/',component: Main},
  { path: '/account', component: Account },
  { path: '/products', component: Product },
  { path: '/shops', component: Shop },
  { path: '/cart', component: Cart },
  // { path: '/product/:id', component: ProductDetail,  meta: { requiresAuth: true } },
  { path: '/create-product', component: CreateProduct,  meta: { requiresAuth: true } },
  { path: '/product/:id', component: ProductDetail },
  { path: '/:pathMatch(.*)*', redirect: '/' }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {
  const authStore = useAuthStore();
  console.log(authStore)
  if (to.meta.requiresAuth && !authStore.isAuthenticated) {
    next('/');
  } else {
    next();
  }
});

export default router;
