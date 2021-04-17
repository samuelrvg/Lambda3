<template>
  <b-card :sub-title="game.titulo">
    <input type="checkbox" :value="game.id" />
    <label>Selecionar game</label><br />
    <!-- <b-card-text> </b-card-text>
      <b-card-text></b-card-text> -->

    <!-- <a href="#" class="card-link">Card link</a>
      <b-link href="#" class="card-link">Another link</b-link> -->
  </b-card>
</template>
<script>
export default {
  props: {
    game: Object
    // checkedGames: []
  },
  data() {
    return {};
  }
};
</script>
