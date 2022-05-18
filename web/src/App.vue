<template>

<div id="app">

  <MovieList @openModal="openModal" />
  <MovieModal v-show="modalIsOpen" :mode="modalMode" @closeModal="closeModal" />

</div>

</template>

<script>
import MovieList from "./components/MovieList.vue";
import MovieModal from "./components/MovieModal.vue";

export default {
  name: "app",
  data () {
    return {
      modalIsOpen: false,
      modalMode: "add",
    }
  },
  components: {
    MovieList,
    MovieModal,
  },
  methods: {
    openModal(mode) {
      console.log(mode)
      this.modalIsOpen = true
    },
    closeModal() {
      this.modalIsOpen = false;
    }
  }
}
</script>

<style>
@import "https://cdn.jsdelivr.net/npm/bulma@0.9.4/css/bulma.min.css";
</style>
