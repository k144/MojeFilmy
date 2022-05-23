<template>
<div class="modal">
  <div class="modal-background" @click="close"></div>
  <div class="modal-content box">

  <div v-show='mode == "edit"' class="content has-text-centered my-5">
    <p class="is-size-4">Edytujesz film {{movieOriginal.title}} ({{movieOriginal.year}})</p>
  </div>

    <div class="columns">

      <div class="field column is-half">
        <label class="label">{{mode=="edit" ? "Nowy tytuł" : "Tytuł"}}</label>
        <div class="control">
          <input class="input" :disabled='mode == "preview"' type="text" v-model="movie.title">
        </div>
      </div>

      <div class="field column is-half">
        <label class="label">{{mode=="edit" ? "Nowy rok wydania" : "Rok wydania"}}</label>
        <div class="control">
          <input class="input" :disabled='mode == "preview"' type="number" v-model="movie.year">
        </div>
      </div>

    </div>

    <div class="columns is-centered" v-show='mode != "preview"'>
      <div class="control column has-text-centered">
        <button class="button m-2" @click="close" >Anuluj</button>
        <button class="button is-primary m-2" @click="send" >{{getButtonText()}}</button>
      </div>
    </div>
    

      <button class="modal-close is-large" @click="close"></button>
  </div>

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
      movie: new Movie,
      movieOriginal: new Movie
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
      this.close();
    },
  },
  watch: {
    selectedMovie (m) {
      this.movie = m
      this.movieOriginal = { ...m }
    }
  }
}
</script>

<style>
</style>