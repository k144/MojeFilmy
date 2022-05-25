<template>
  <div class="container has-text-centered pt-6" v-show="movies.length > 0">
    <table class="table mx-auto has-text-left">
      <thead>
        <tr>
          <th>Rok</th>
          <th>Tytuł</th>
          <th></th>
        </tr>
      </thead>
      <tr v-for="(movie, index) in movies" v-bind:key="index">
        <td class="is-vcentered">{{ movie.year }}</td>
        <td class="is-vcentered">{{ movie.title }}</td>
        <td>
          <button class="button is-text" @click="deleteMovie(movie)">
            <div class="icon">
              <font-awesome-icon icon="fa-solid fa-trash" />
            </div>
          </button>
          <button class="button is-text" @click="editMovie(movie)">
            <div class="icon">
              <font-awesome-icon icon="fa-solid fa-pen" />
            </div>
          </button>
          <button class="button is-text" @click="previewMovie(movie)">
            <div class="icon">
              <font-awesome-icon icon="fa-solid fa-eye" />
            </div>
          </button>
        </td>
      </tr>
    </table>
    <button class="button is-primary my-3" @click="addMovie">Dodaj film</button>
  </div>
</template>

<script>
import Config from "../config.js";
const axios = require("axios");

export default {
  name: "MovieList",
  data() {
    return {
      movies: [],
    };
  },
  methods: {
    async deleteMovie(movie) {
      if (
        !confirm(
          `Czy na pewno chcesz usunąc film ${movie.title} (${movie.year})?`
        )
      ) {
        return;
      }
      await axios.delete(Config.api + "/" + movie.id);
      await this.updateList();
    },
    addMovie() {
      this.$emit("openModal", "add");
      this.updateList();
    },
    editMovie(movie) {
      this.$emit("openModal", "edit", movie);
      this.updateList();
    },
    previewMovie(movie) {
      this.$emit("openModal", "preview", movie);
      this.updateList();
    },
    async updateList() {
      try {
        let get = await axios.get(Config.api);
        this.movies = get.data;
      } catch (err) {
        this.$emit("error", `${err.message} - problem z połączeniem z API`);
      }
    },
  },
  mounted: function () {
    this.updateList();
  },
};
</script>

<style>
</style>