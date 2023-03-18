<template>
  <div>
    <v-sheet class="mx-auto" min-width="400px">
      <v-form @submit.prevent>
        <v-combobox
            v-model="problemSelected"
            :items="problemData"
            label="Problem type"
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
            v-if="false"
            v-model="matchingName"
            :rules="this.rules"
            label="Matching name"
        ></v-text-field>

        <v-btn block class="mt-2" type="submit" @click="onSubmit">Submit</v-btn>
      </v-form>
    </v-sheet>
  </div>
</template>

<script lang="ts">
import {defineComponent} from 'vue'
import axios from "axios";


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
    algSelected: {} as Item,
    problemData: problem_data,
    inputFile: null as any,
    rules: [
      (value: string) => {
        if (value) return true
        return 'You must enter a first name.'
      },
    ],
  }),
  computed: {
    algsList() {
      return this.problemSelected.algs;
    },
  },
  mounted() {
    // get supported problems algs;
    this.problemSelected = this.problemData[0];
  },
  methods: {
    onSubmit() {
      var formData = new FormData();
      let file = new File(this.$data.inputFile, this.$data.inputFile[0].name);

      formData.append("file", file, this.$data.inputFile[0].name);
      formData.append("matchingName", this.$data.matchingName);
      formData.append("problemType", this.$data.problemSelected.value);
      formData.append("algType", this.$data.algSelected.value);

      console.log(formData);

      //TODO реализовать системные параметры
      axios.post(`http://localhost:5126/ImportMatching/upload`,
          formData, {
            headers: {
              'Content-Type': 'multipart/form-data',
            }
          }
      )
          .then(response => console.log(response))
          .catch(error => console.log(error));
    },
  },
  watch: {
    'problemSelected'(newVal) {
      this.algSelected = newVal.algs[0];
    }
  }
})

</script>
<style scoped>
</style>
