<template>
  <v-layout>
    <v-flex class="text-center">
      <upload-de-arquivo />
    </v-flex>
  </v-layout>
</template>

<script>
import UploadDeArquivo from '~/components/UploadDeArquivo.vue'

export default {
  components: {
    UploadDeArquivo
  }
}
</script>
