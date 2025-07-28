<script setup lang="ts">
import { onMounted, ref } from 'vue';

const tags = ref<string[]>([]);
const newTag = ref<string>('');

const props = defineProps<{
  modelValue: Array<string>; // current page
}>();

const emit = defineEmits<{
  (e: 'onChange', value: string[]): void;
   (e: 'update:modelValue', value: Array<string>): void;
}>();


const addTag = () => {
    const tag = newTag.value.trim();
    if (tag && tags.value.indexOf(tag) === -1) {
        tags.value.push(tag);
    }
    newTag.value = '';
    emit('onChange', tags.value);
    emit('update:modelValue', tags.value);
};

const removeTag = (index: number) => {
    tags.value.splice(index, 1);
    emit('onChange', tags.value);
    emit('update:modelValue', tags.value);
};
onMounted(() => {
    tags.value = props.modelValue;
})
</script>

<template>

    <div class="tags-input">
        <div class="tag" v-for="(tag, index) in tags" :key="index">
            {{ tag }}
            <span class="remove-tag" @click="removeTag(index)">×</span>
        </div>
        <input type="text" v-model="newTag" @keyup.enter="addTag" placeholder="Add a tag" />
    </div>

</template>

<style scoped>
.tags-input {
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    padding: 5px;
    border: 1px solid #ccc;
    border-radius: 5px;
    max-width: 400px;
}

.tags-input input {
    border: none;
    flex: 1;
    padding: 5px;
    min-width: 100px;
    outline: none;
}

.tag {
    background-color: #ff523b4f;
    color: #ff523b;
    padding: 5px 10px;
    margin: 3px;
    border-radius: 20px;
    display: flex;
    align-items: center;
    font-size: 14px;
}

.remove-tag {
    margin-left: 8px;
    cursor: pointer;
    font-weight: bold;
}
</style>
