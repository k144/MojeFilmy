<template>
<div class="modal">
  <div class="modal-background" @click="close"></div>
  <form class="modal-content box" @submit.prevent="submit">

  <div v-show='mode == "edit"' class="content has-text-centered my-5">
    <p class="is-size-4">Edytujesz film {{movieOriginal.title}} ({{movieOriginal.year}})</p>
  </div>

    <div class="columns my-3 mx-2">

      <div class="field column is-half form-group" :class="{ 'form-group--error': $v.title.$error }">
        <label class="label">{{mode=="edit" ? "Nowy tytuł" : "Tytuł"}}</label>
        <div class="control">
          <input class="input form-control" :class="$v.title.$dirty && (!$v.title.required || !$v.title.maxLength) ? 'is-danger' : ''" :disabled='mode == "preview"' type="text" v-model="title">
        </div>
        <div class="help is-danger" v-if="!$v.title.required && $v.title.$dirty">Pole obowiązkowe</div>
        <div class="help is-danger" v-if="!$v.title.maxLength && $v.title.$dirty">Tytuł filmu może mieć maksymalnie {{$v.title.$params.maxLength.max}} znaków</div>
      </div>

      <div class="field column is-half form-group" :class="{ 'form-group--error': $v.year.$error }">
        <label class="label">{{mode=="edit" ? "Nowy rok wydania" : "Rok wydania"}}</label>
        <div class="control">
          <input class="input" :class="$v.year.$dirty && (!$v.year.required || !$v.year.between) ? 'is-danger' : ''" :disabled='mode == "preview"' type="number" v-model="year">
        </div>
        <div class="help is-danger" v-if="!$v.year.required && $v.year.$dirty">Pole obowiązkowe</div>
        <div class="help is-danger" v-if="!$v.year.between && $v.year.$dirty">Rok wydania musi być w zakresie od {{$v.year.$params.between.min}} do {{$v.year.$params.between.max}}</div>
      </div>

    </div>

    <div class="columns is-centered" v-show='mode != "preview"'>
      <div class="control column has-text-centered">
        <button class="button m-2" @click="close" >Anuluj</button>
        <input type="submit" class="button is-primary m-2" :value="getButtonText()">
      </div>
    </div>
    

      <button class="modal-close is-large" @click="close"></button>
  </form>

</div>

</template>

<script>

import Movie from "../classes/movie.js";
import Config from "../config.js";
import { required, maxLength, between } from 'vuelidate/lib/validators'
const axios = require('axios');

const buttonText = new Map([
  ['add', 'Dodaj film'],
  ['edit', 'Wprowadź zmiany'],
])

export default {
	name: 'MovieModal',
	data() {
		return {
      title: "",
      year: 0,
      id: 0,
      movieOriginal: new Movie
		}
	},
  validations: {
    title: {
      required,
      maxLength: maxLength(200)
    },
    year : {
      required,
      between: between(1900, 2100)
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
    async submit() {
      this.$v.$touch();
      if (this.$v.$invalid) {
        return;
      }
      let data = JSON.stringify(new Movie(this.title, this.year));
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
            Config.api + "/" + this.id,
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
      this.title = m.title
      this.year = m.year
      this.id = m.id
      this.movieOriginal = { ...m }
    }
  }
}
</script>

<style>
</style>