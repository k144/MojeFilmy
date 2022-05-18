<template>
<div>
  <p>Tryb: {{mode}}</p>
  Tytuł: <input type="text" v-bind="movie.title">
  <br>
  Rok: <input type="number" v-bind="movie.date">
  <br>
  <button v-show='mode != "preview"'>{{getButtonText()}}</button>

  <button @click="close">X</button>

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
      movie: {title: '', date: undefined}
		}
	},
  props: ["mode"],
  methods: {
    close() {
      this.$emit("closeModal")
    },
    getButtonText() {
      console.log(this.mode)
      return buttonText.get(this.mode)
    }
  }
}
</script>

<style>
</style>