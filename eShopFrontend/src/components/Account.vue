<script setup lang="ts">
import { onMounted, reactive, ref } from 'vue';
import Header from './shared/Header.vue';
import { useAuthStore } from '../store/auth';
import { useRouter } from 'vue-router';
import { useAppStore } from '../store/app';

const router = useRouter();

const appStore = useAppStore();
const authStore = useAuthStore();

const loginPayload = reactive({
  password: '',
  email: ''
});

const registerPayload = reactive({
  username: '',
  password: '',
  email: ''
});

const loginErrors = reactive({
  email: '',
  password: '',
});

const validateLogin = () => {
  let isValid = true;
  loginErrors.email = '';
  loginErrors.password = '';

  if (!loginPayload.email) {
    loginErrors.email = 'Email is required.';
    isValid = false;
  } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(loginPayload.email)) {
    loginErrors.email = 'Email is not valid.';
    isValid = false;
  }

  // Password validation
  if (!loginPayload.password) {
    loginErrors.password = 'Password is required.';
    isValid = false;
  } else if (loginPayload.password.length < 6) {
    loginErrors.password = 'Password must be at least 6 characters.';
    isValid = false;
  }

  return isValid;
};

const handleRegister = async () => {
  try {
    if (!validateLogin()) {
      return;
    }
    console.log(registerPayload)
    // await authStore.login(username.value, password.value);
    // Redirect to a different page
  } catch (error) {
    alert('Login failed. Please check your credentials.');
  }
};

const handleLogin = async () => {
  if (!validateLogin()) {
    return;
  }
  const result = await authStore.login(loginPayload.email, loginPayload.password);
  if (authStore.isAuthenticated) {
    appStore.setAuthantication();
    router.push('/products');
  }
  // Redirect to a different page
};

const loginForm = ref<HTMLElement | null>(null);
const registerForm = ref<HTMLElement | null>(null);
const indicator = ref<HTMLElement | null>(null);


function switchToLogin() {
  loginForm.value!.style.transform = 'translateX(300px)';
  registerForm.value!.style.transform = 'translateX(300px)';
  indicator.value!.style.transform = 'translateX(0px)';
};

function switchToRegister() {
  loginForm.value!.style.transform = 'translateX(0px)';
  registerForm.value!.style.transform = 'translateX(0px)';
  indicator.value!.style.transform = 'translateX(100px)';
};
onMounted(() => {
  switchToLogin();
});
</script>

<template>
  <Header />
  <div class="account-page">
    <div class="container">
      <div class="row">
        <div class="col-2">
          <img src="/images/image1.png" width="100%" />
        </div>

        <div class="col-2">
          <div class="form-container">
            <div class="form-btn">
              <span @click="switchToLogin">Login</span>
              <span @click="switchToRegister">Register</span>
              <hr id="Indicator" ref="indicator">
            </div>
            <form @submit.prevent="handleLogin" id="LoginForm" ref="loginForm">
              <div>
                <input v-model="loginPayload.email" type="email" id="email" placeholder="Email" />
                <p v-if="loginErrors.email" class="error">{{ loginErrors.email }}</p>
              </div>
              <div>
                <input v-model="loginPayload.password" type="password" id="password" placeholder="Password" />
                <p v-if="loginErrors.password" class="error">{{ loginErrors.password }}</p>
              </div>
              <button type="submit" class="btn">Login</button>
              <a href="">Forgot Password</a>
            </form>

            <form @submit.prevent="handleRegister" id="RegisterForm" ref="registerForm">
              <input v-model="registerPayload.username" type="text" id="username" placeholder="Username" />
              <input v-model="registerPayload.email" type="email" id="email" placeholder="Email" />
              <input v-model="registerPayload.password" type="password" id="password" placeholder="Password" />
              <button type="submit" class="btn">Register</button>
            </form>

          </div>
        </div>

      </div>
    </div>
  </div>

</template>



<style scoped>
#Indicator {
  width: 100px;
  border: none;
  background: #ff523b;
  height: 3px;
  margin-top: 8px;
  transform: translateX(100px);
  transition: transform 1s;
}

.account-page {
  padding: 50px 0;
  background: radial-gradient(#fff, #ffd6d6);
}

.form-container {
  background: #fff;
  width: 300px;
  height: 400px;
  position: relative;
  text-align: center;
  padding: 20px 0;
  margin: auto;
  box-shadow: 0 0 20px 0px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.form-container span {
  font-weight: bold;
  padding: 0 10px;
  color: #555;
  cursor: pointer;
  width: 100px;
  display: inline-block;
}

.form-btn {
  display: inline-block;
}

.form-container form {
  /* max-width: 300px; */
  width: 100%;
  padding: 0 20px;
  position: absolute;
  top: 100px;
  transition: transform 1s;
}

form div {
  width: 100%;
  height: 30px;
  margin: 10px 0 25px 0;
}

div input {
  width: 100%;
  height: 30px;
  padding: 0 10px;
  border: 1px solid #ccc;
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

form a {
  font-size: 12px;
}

#LoginForm {
  left: -300px;
}

#RegisterForm {
  left: 0;
}

.error {
  color: red;
  font-size: 0.85rem;
  margin-top: 2px;
  text-align: start;
}
</style>
