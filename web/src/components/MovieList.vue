<template>

<table>
    <tr v-for="(movie, index) in movies" v-bind:key="index">
        <td>{{movie.year}}</td>
        <td>{{movie.title}}</td>
        <button @click="deleteMovie(movie)">Usuń</button>
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
    },
    methods: {
        deleteMovie(movie) {
            if (!confirm(
                `Czy na pewno chcesz usunąc film ${movie.title} (${movie.year})?`
            )) return;
            this.movies = this.movies.filter((m) => m != movie )
        }
    }
}
</script>

<style>
</style>