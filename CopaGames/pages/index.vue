<template>
  <div>
    <b-row class="mb-2">
      <b-col md="3"
        ><p>Selecionados {{ selecionados }}</p></b-col
      >
      <b-col md="3" offset-md="6">
        <b-button @click.prevent="submit()">Gerar Meu Campeonato</b-button>
      </b-col>
    </b-row>

    <div class="row">
      <div
        v-for="(game, index) in games"
        :key="index"
        class="col-md-3 col-6 my-1"
      >
        <div class="h-100">
          <!-- <card :game="game" :checkedGames="checkedGames"></card> -->
          <b-card :sub-title="game.titulo">
            <input type="checkbox" :value="game.id" v-model="checkedGames" />
            <label>Selecionar game</label><br />
          </b-card>
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
      this.games = data;
    },
    async submit() {
      var filterGamesChecked = this.games.filter(e =>
        this.checkedGames.includes(e.id)
      );

      const data = await this.$axios.$post("games", filterGamesChecked);
      // console.log("vencedores", data);
    }
  }
};
</script>
