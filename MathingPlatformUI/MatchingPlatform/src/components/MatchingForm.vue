<script lang="ts">
import {ref, Component} from 'vue'

export default {
  data: () => ({
    firstName: '',
    rules: [
      (value: string) => {
        if (value) return true
        return 'You must enter a first name.'
      },
    ],
  }),
}

</script>

<template>
  <div>
    <v-sheet width="300" class="mx-auto">
      <v-form @submit.prevent>
        <v-text-field
            v-model="firstName"
            :rules="rules"
            label="First name"
        ></v-text-field>
        <v-btn type="submit" block class="mt-2">Submit</v-btn>
      </v-form>
    </v-sheet>
  </div>
</template>

<style scoped>
</style>
