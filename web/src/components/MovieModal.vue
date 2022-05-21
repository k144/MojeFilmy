<template>
<div>
  <button @click="close">X</button>
  <p>Tryb: {{mode}}</p>
  Tytuł: <input type="text" v-model="movie.title">
  <br>
  Rok: <input type="number" v-model="movie.year">
  <br>
  <p>{{movie.date}}</p>
  <button @click="send" v-show='mode != "preview"'>{{getButtonText()}}</button>


</div>

</template>

<script>

import Movie from "../classes/movie.js";
import Config from "../config.js";
const axios = require('axios');

const buttonText = new Map([
  ['add', 'Dodaj film'],
  ['edit', 'Wprowadź zmiany'],
])

export default {
	name: 'MovieModal',
	data() {
		return {
      movie: new Movie
		}
	},
  props: ["mode", "selectedMovie"],
  methods: {
    close() {
      this.$emit("closeModal")
    },
    getButtonText() {
      console.log(this.mode)
      return buttonText.get(this.mode)
    },
    async send() {
      let data = JSON.stringify(this.movie);
      switch (this.mode) {
        case "add":
          await axios.post(
            Config.api,
            data,
            {headers: {"Content-Type": "application/json"}}
          )
          break;
        case "edit":
          await axios.put(
            Config.api + "/" + this.movie.id,
            data,
            {headers: {"Content-Type": "application/json"}}
          )
          break;
      }
    },
  },
  watch: {
    selectedMovie (m) {
      this.movie = m
    }
  }
}
</script>

<style>
</style>