<template>

  <MatchingForm></MatchingForm>


</template>


<script lang="ts" setup>
import {onMounted, ref} from "vue";
import MatchingForm from "./components/MatchingForm.vue";

interface TestData {
  test: string;
}

const result = ref<TestData>({test: ""})
onMounted(async () => {
  result.value = await (await fetch("/api/hello")).json();
  console.log(result.value);
});

</script>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
