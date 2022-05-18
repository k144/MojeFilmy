<template>

<div id="app">

  <MovieList />
  <MovieModal />

</div>

</template>

<script>
import MovieList from "./components/MovieList.vue";
import MovieModal from "./components/MovieModal.vue";

export default {
  name: "app",
  components: {
    MovieList,
    MovieModal,
  }
}
</script>

<style>
@import "https://cdn.jsdelivr.net/npm/bulma@0.9.4/css/bulma.min.css";
</style>
