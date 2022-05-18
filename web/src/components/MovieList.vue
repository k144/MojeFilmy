<template>

<table>
    <tr v-for="(movie, index) in movies" v-bind:key="index">
        <td>{{movie.year}}</td>
        <td>{{movie.title}}</td>
    </tr>
</table>

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
            ]
        }
    }
}
</script>

<style>
</style>