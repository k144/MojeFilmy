<template>
<div>
  <button @click="addMovie">Dodaj film</button>
  <table>
    <tr v-for="(movie, index) in movies" v-bind:key="index">
      <td>{{movie.year}}</td>
      <td>{{movie.title}}</td>
      <button @click="deleteMovie(movie)">Usuń</button>
      <button @click="editMovie(movie)">Edytuj</button>
      <button @click="previewMovie(movie)">Podgląd</button>
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
    deleteMovie(movie) {
      if (!confirm(
        `Czy na pewno chcesz usunąc film ${movie.title} (${movie.year})?`
      )) return;
      axios.delete(Config.api + "/" + movie.id)
      //this.movies = this.movies.filter((m) => m != movie )
    },
    addMovie() {
      this.$emit('openModal', "add")
    },
    editMovie(movie) {
      this.$emit('openModal', "edit", movie)
    },
    previewMovie(movie) {
      this.$emit('openModal', "preview", movie)
    },
  },
  mounted: async function() {
    let get = await axios.get(Config.api);
    this.movies = get.data;
    
  }
}
</script>

<style>
</style>