<template>

<div id="app" class="container">
  <MovieList @openModal="openModal" ref="list" />
  <MovieModal :class='{ "is-active": modalIsOpen }' :mode="modalMode" :selected-movie="selectedMovie" @closeModal="closeModal" />
</div>

</template>

<script>
import MovieList from "./components/MovieList.vue";
import MovieModal from "./components/MovieModal.vue";
import Movie from "./classes/movie.js";

export default {
  name: "app",
  data () {
    return {
      modalIsOpen: false,
      modalMode: undefined,
      selectedMovie: new Movie,
    }
  },
  components: {
    MovieList,
    MovieModal,
  },
  methods: {
    openModal(mode, movie = new Movie) {
      this.modalMode = mode
      this.selectedMovie = movie;
      this.modalIsOpen = true
    },
    closeModal() {
      this.modalIsOpen = false;
      this.$refs.list.updateList();
    }
  },
}
</script>

<style>
@import "https://cdn.jsdelivr.net/npm/bulma@0.9.4/css/bulma.min.css";
</style>
