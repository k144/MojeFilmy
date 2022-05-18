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
export default {
  name: 'MovieList',
  data() {
    return {
      movies: [
        {title: "Drive", year: 2011},
        {title: "2001: Odyseja kosmiczna", year: 1968},
        {title: "Batman", year: 2022},
        {title: "Batman", year: 1989},
      ],
      newMovie: {title: '', year: null}
    }
  },
  methods: {
    deleteMovie(movie) {
      if (!confirm(
        `Czy na pewno chcesz usunąc film ${movie.title} (${movie.year})?`
      )) return;
      this.movies = this.movies.filter((m) => m != movie )
    },
    addMovie() {
      this.$emit('openModal', "add")
    },
    editMovie(movie) {
      this.$emit('openModal', "edit")
      console.log(movie)
    },
    previewMovie(movie) {
      this.$emit('openModal', "preview")
      console.log(movie)
    },
  },
}
</script>

<style>
</style>