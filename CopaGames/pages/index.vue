<template>
  <div class="container">
    <!-- <div v-for="(game, index) in games" :key="index">
      <div class="row">
        <div class="col-md-3 mb-2"><card :game="game"></card></div>
      </div>
    </div> -->

    <b-row class="mb-2">
      <b-col md="3"
        ><p>Selecionados {{ selecionados }}</p></b-col
      >
      <b-col md="3" offset-md="6">
        <b-button>Gerar Meu Campeonato</b-button></b-col
      >
    </b-row>

    <div class="row">
      <div
        v-for="(game, index) in games"
        :key="index"
        class="col-md-3 col-6 my-1"
      >
        <div class="h-100">
          <card :game="game"></card>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import card from "../components/card";
export default {
  components: {
    card
  },
  data() {
    return {
      games: [],
      selecionados: 5
    };
  },
  async mounted() {
    await this.asyncData();
  },
  methods: {
    async asyncData() {
      const data = await this.$axios.$get(
        "https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games"
      );
      this.games = data;
    }
  }
};
</script>
