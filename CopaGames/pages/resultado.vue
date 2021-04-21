<template>
  <div>
    <b-card-group deck class="mb-3">
      <b-card border-variant="success" header="1º Lugar" align="center">
        <b-card-text>{{ primeiroLugar }}</b-card-text>
      </b-card>
    </b-card-group>
    <b-card-group deck>
      <b-card
        border-variant="danger"
        header="2º Lugar"
        header-border-variant="danger"
        header-text-variant="danger"
        align="center"
      >
        <b-card-text>{{ segundoLugar }}</b-card-text>
      </b-card>
    </b-card-group>
  </div>
</template>

<script>
export default {
  data() {
    return {
      primeiroLugar: "Não definido!",
      segundoLugar: "Não definido!"
    };
  },
  mounted() {
    if (this.$route.params.data) {
      this.primeiroLugar = this.$route.params.data[0];
      this.segundoLugar = this.$route.params.data[1];
    }
  }
};
</script>
