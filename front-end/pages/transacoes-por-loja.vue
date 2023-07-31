<template>
  <v-layout>
    <v-flex class="text-center">
      <transacoes-por-loja />
    </v-flex>
  </v-layout>
</template>

<script>
import TransacoesPorLoja from '~/components/TransacoesPorLoja.vue'

export default {
  components: {
    TransacoesPorLoja
  }
}
</script>
