<template>
  <div>
    <v-sheet class="mx-auto" min-width="400px">
      <v-form @submit.prevent>
        <v-combobox
            v-model="problemSelected"
            :items="problemData"
            label="Problem type"
            @select="problemOnChange"
        ></v-combobox>

        <v-combobox
            v-model="algSelected"
            :items="algsList"
            label="Alg type"
        ></v-combobox>

        <v-file-input
            v-model="inputFile"
            accept=".xlsx"
            label="matching data file"
            outlined
        ></v-file-input>
        
        <v-text-field
            v-model="matchingName"
            :rules="this.rules"
            label="Matching name"
        ></v-text-field>
        
        <v-btn block class="mt-2" @click="onSubmit" type="submit">Submit</v-btn>
      </v-form>
    </v-sheet>
  </div>
</template>

<script lang="ts">
import {defineComponent} from 'vue'


interface Item {
  title: string;
  value: string;
}

interface Problem extends Item {
  algs: Item[];
}

const problem_data: Problem[] = [
  {
    title: 'Stable marriage problem',
    value: 'SMP',
    algs: [
      {title: 'Male-Oriented SPA', value: 'MSPA'},
      {title: 'Female-Oriented  SPA', value: 'FSPA'},
    ]
  },
  {
    title: 'Hospitals-Residents problem',
    value: 'HR',
    algs: [
      {title: 'Resident-oriented Gale/Shapley algorithm', value: 'RGS'},
      {title: 'Hospitals-oriented Gale/Shapley algorithm', value: 'HGS'},
    ]
  }
];


export default defineComponent({
  data: () => ({
    matchingName: '',
    problemSelected: {} as Problem,
    algSelected: {} as Item | null,
    problemData: problem_data,
    inputFile: null,
    rules: [
      (value: string) => {
        if (value) return true
        return 'You must enter a first name.'
      },
    ],
  }),
  mounted() {
    // get supported problems algs;
    this.problemSelected = this.problemData[0];
  },
  methods: {
    problemOnChange() {
      this.algSelected = this.problemSelected.algs[1];
    },
    onSubmit() {

    }
  },
  computed: {
    algsList() {
      return this.problemSelected.algs;
    },
  }
})

</script>
<style scoped>
</style>
