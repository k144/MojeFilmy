<template>
<div>
  <p>{{mode}}</p>
  <button @click="close">X</button>

</div>

</template>

<script>

export default {
	name: 'MovieModal',
	data() {
		return {
		}
	},
  props: ["mode"],
  methods: {
    close() {
      this.$emit("closeModal")
    }
  }
}
</script>

<style>
</style>