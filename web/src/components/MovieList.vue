<template>
<div class="container has-text-centered pt-6">
    <button class="button" @click="addMovie">Dodaj film</button>
  <table class="table mx-auto has-text-left">
    <thead>
      <tr>
        <th>Rok</th>
        <th>Tytuł</th>
      </tr>
    </thead>
    <tr v-for="(movie, index) in movies" v-bind:key="index">
      <td>{{movie.year}}</td>
      <td>{{movie.title}}</td>
      <button class="button" @click="deleteMovie(movie)">Usuń</button>
      <button class="button" @click="editMovie(movie)">Edytuj</button>
      <button class="button" @click="previewMovie(movie)">Podgląd</button>
    </tr>
  </table>
</div>

</template>

<script>

// import Movie from "../classes/movie.js";
import Config from "../config.js";
const axios = require('axios');


export default {
  name: 'MovieList',
  data() {
    return {
      movies: [
        // new Movie("Drive", 2011),
        // new Movie("2001: Odyseja kosmiczna", 1968),
        // new Movie("Batman", 2022),
        // new Movie("Batman", 1989),
      ],
    }
  },
  methods: {
    async deleteMovie(movie) {
      if (!confirm(
        `Czy na pewno chcesz usunąc film ${movie.title} (${movie.year})?`
      )) return;
      await axios.delete(Config.api + "/" + movie.id)
      await this.updateList();
      //this.movies = this.movies.filter((m) => m != movie )
    },
    addMovie() {
      this.$emit('openModal', "add")
      this.updateList();
    },
    editMovie(movie) {
      this.$emit('openModal', "edit", movie)
      this.updateList();
    },
    previewMovie(movie) {
      this.$emit('openModal', "preview", movie)
      this.updateList();
    },
    async updateList() {
      let get = await axios.get(Config.api);
      this.movies = get.data;
      console.log(get.data);
    
  }
  },
  mounted: function() {
    this.updateList();
  }
}
</script>

<style>
</style>