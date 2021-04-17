<template>
  <div>
    <b-card-group deck class="mb-3">
      <b-card border-variant="dark" header="1º Lugar" align="center">
        <b-card-text>Game 1</b-card-text>
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
        <b-card-text>Game 2</b-card-text>
      </b-card>
    </b-card-group>
  </div>
</template>

<script>
export default {
  data() {
    return {
      vencedores: []
    };
  },
  mounted() {}
};
</script>
