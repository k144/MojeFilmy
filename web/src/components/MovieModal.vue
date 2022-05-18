<template>
<div>
  <button @click="close">X</button>
  <p>Tryb: {{mode}}</p>
  Tytuł: <input type="text" v-model="movie.title">
  <br>
  Rok: <input type="number" v-model="movie.year">
  <br>
  <p>{{movie.date}}</p>
  <button v-show='mode != "preview"'>{{getButtonText()}}</button>


</div>

</template>

<script>

const buttonText = new Map([
  ['add', 'Dodaj film'],
  ['edit', 'Wprowadź zmiany'],
])

export default {
	name: 'MovieModal',
	data() {
		return {
      movie: {title: '', year: undefined}
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
  },
  watch: {
    selectedMovie (m) {
      this.movie = m
    }
  }
}
</script>

<style>
</style>