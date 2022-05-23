<template>

<div id="app">

  <section class="hero is-black">
  <div class="hero-body has-text-centered">
    <p class="title">
      Moje Filmy
    </p>
    <p class="subtitle">
      Zadanie rekrutacyje dla SoftwareStudio
    </p>
  </div>
</section>
  
  <section class="section">
    <MovieList @openModal="openModal" ref="list" />
  </section>

  <MovieModal :class='{ "is-active": modalIsOpen }' :mode="modalMode" :selected-movie="selectedMovie" @closeModal="closeModal" />

  <footer class="footer">
    <div class="content has-text-centered">
      <p><a href="https://jakubnowak.xyz">Jakub Nowak</a></p>
      <p><a href="mailto:jakubnowak712@gmail.com">jakubnowak712@gmail.com</a></p>
      <p>maj 2022</p>
    </div>
  </footer>
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
