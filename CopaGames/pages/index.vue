<template>
  <div>
    <b-jumbotron header="Challenge Games" lead="Fase de seleção">
      <hr class="my-4" />
      <p>
        Selecione 8 games que você deseja que entrem na competição e depois o
        botão Gerar Meu Campeonato para prosseguir.
      </p>
    </b-jumbotron>
    <b-row class="mb-2">
      <b-col md="3"
        ><p class="font-weight-normal">
          Selecionados: {{ this.checkedGames.length }} games
        </p></b-col
      >
      <b-col md="3" offset-md="6">
        <b-button
          @click.prevent="gerarCampeonato()"
          :disabled="!(this.checkedGames.length === this.minimoParaIniciarJogo)"
          >Gerar Meu Campeonato</b-button
        >
      </b-col>
    </b-row>

    <div class="row mb-2">
      <div
        v-for="(game, index) in games"
        :key="index"
        class="col-12 col-md-4 col-lg-3 my-2"
      >
        <div class="h-100">
          <b-card :header="`${game.ano}`">
            <b-card-text class="text-truncate">
              {{ game.titulo }}
            </b-card-text>
            <div>
              <input type="checkbox" :value="game.id" v-model="checkedGames" />
              <label>Selecionar game</label><br />
            </div>
          </b-card>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import _ from "lodash";
export default {
  data() {
    return {
      games: [],
      checkedGames: [],
      minimoParaIniciarJogo: 8
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
      this.games = _.orderBy(data, "ano", "asc");
    },
    async gerarCampeonato() {
      var checkedGamesFilter = this.games.filter(e =>
        this.checkedGames.includes(e.id)
      );

      try {
        const data = await this.$axios.$post("game", checkedGamesFilter);

        this.$router.push({
          name: "result",
          params: {
            data: data.map(g => g.titulo)
          }
        });
      } catch (error) {
        if (!error.response) return;

        if (error.response.status === 400) {
          const [{ errorMessage }] = error.response.data;
          alert(errorMessage);
        }
      }
    }
  }
};
</script>
