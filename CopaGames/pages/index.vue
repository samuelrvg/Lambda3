<template>
  <div>
    <b-row class="mb-2">
      <b-col md="3"
        ><p class="font-weight-normal">
          Selecionados: {{ selecionados }} games
        </p></b-col
      >
      <b-col md="3" offset-md="6">
        <b-button @click.prevent="submit()">Gerar Meu Campeonato</b-button>
      </b-col>
    </b-row>

    <div class="row mb-2">
      <div
        v-for="(game, index) in games"
        :key="index"
        class="col-md-3 col-6 my-2"
      >
        <div class="h-100">
          <!-- <card :game="game" :checkedGames="checkedGames"></card> -->
          <b-card :header="game.ano">
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
import card from "../components/card";
export default {
  components: {
    card
  },
  data() {
    return {
      games: [],
      selecionados: 0,
      checkedGames: []
    };
  },
  async mounted() {
    await this.asyncData();
  },
  watch: {
    checkedGames() {
      if (this.checkedGames.length <= 8) {
        this.selecionados = this.checkedGames.length;
      } else {
        alert("Os 8 games já foram selecionados!");
      }
      // console.log("checked");
    }
  },
  methods: {
    async asyncData() {
      const data = await this.$axios.$get(
        "https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games"
      );
      this.games = _.orderBy(data, "ano", "asc");
    },
    async submit() {
      var filterGamesChecked = this.games.filter(e =>
        this.checkedGames.includes(e.id)
      );

      try {
        const data = await this.$axios.$post("game", filterGamesChecked);

        this.$router.push({
          name: "resultado",
          params: {
            data: data.map(g => g.titulo)
          }
        });
      } catch (error) {
        console.log("err", error);
        alert("Ocorreu um erro!!!");
      }
    }
  }
};
</script>
