<template>
  <form v-show="isLoaded">
    <v-card>
      <v-card-title>
        Upload de arquivo
      </v-card-title>
      <v-card-text>
        <v-container fluid>
          <v-row>
            <v-file-input 
              label="File input"               
              :error-messages="validationErrors"
              v-model="model.file"
              :clearable="true"
              ></v-file-input>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>        
        <!-- <input type="file" @change="uploadFile" ref="file" :error-messages="validationErrors"> -->
        <v-btn color="primary" large @click="submitFile">Enviar</v-btn>
        <v-btn color="accent" large @click="clear">Limpar</v-btn>
      </v-card-actions>
    </v-card>
    <v-alert style="margin-top: 10px;"
      v-model="showAlert"
      border="left"
      type="success"
      outlined
      transition="scroll-y-transition"
      dismissible
      prominent>
      Upload realizado com sucesso!
    </v-alert>
  </form>
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required } from 'vuelidate/lib/validators'

export default {
  components: {
  },

  mixins: [validationMixin],

  validations: {
    model: {
      file: { required }
    }
  },

  data: () => ({
    isLoaded: false,
    model: {
      file: null
    },
    showAlert: false
  }),

  computed: {
    validationErrors() {
      return this.getValidationErrors('file')
    }
  },

  beforeMount() {
    this.$nextTick(() => {
      this.$nuxt.$loading.start()
    })

    this.reqs = [
    ]

    Promise.all(this.reqs).then((_) => {
      this.$nuxt.$loading.finish()
      this.isLoaded = true
    })
  },

  methods: {
    async submitFile() {
      this.$v.$touch()
      if (this.$v.$invalid) return

      this.$nuxt.$loading.start()

      await this.enviarArquivo()
      
      this.clear()
      this.$nuxt.$loading.finish()
      this.showAlert = true
    },
    async enviarArquivo() {
      const formData = new FormData();
      formData.append('formFile', this.model.file);
      const headers = { 'Content-Type': 'multipart/form-data' };

      const { data } = await this.$axios.post(
        '/api/ArquivoCnab/upload',
        formData,
        { headers }
      )

      return data
    },
    getValidationErrors(field) {
      const errors = []
      if (!this.$v.model[field].$dirty) return errors
      !this.$v.model[field].required && errors.push('Campo obrigatório')
      return errors
    },
    clear() {
      this.$v.model.$reset()
      this.model.file = null
      this.showAlert = false
    }
  }
}
</script>
