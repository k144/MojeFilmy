<template>
  <div class="columns is-centered" v-show="msg && !hide">
    <div class="column is-half">
      <div class="message is-danger my-6">
          <div class="message-header">
            <p>Błąd</p>
            <button @click="hide=true" class="delete" aria-label="delete"></button>
          </div>
          <div class="message-body">
            <p>{{msg}}</p>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ErrorMessage",
  props: ["msg"],
  data() {
    return {
      hide: false
    }
  }
}
</script>

<style>
</style>