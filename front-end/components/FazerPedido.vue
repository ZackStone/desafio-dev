<template>
  <form v-show="isLoaded">
    <v-card v-show="!showCheckout">
      <v-card-title>
        Realizar Pedido
      </v-card-title>
      <v-card-text>
        <v-container fluid>
          <v-row>
            <v-col cols="6">
              <v-select
                v-model="model.loja"
                label="Loja"
                :items="items.lojas"
              >
              </v-select>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" large @click="fazerCheckout">Checkout</v-btn>
        <v-btn color="accent" large @click="clear">Limpar</v-btn>
      </v-card-actions>
    </v-card>
    {{ items.transacoes }}
    <v-card v-if="showCheckout">
      <v-card-title>
        Checkout
      </v-card-title>
      <v-card-text>
        <pedido v-model="model" />
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" large @click="submit">Finalizar Pedido</v-btn>
        <v-btn color="accent" large @click="showCheckout = false">Voltar</v-btn>
      </v-card-actions>
    </v-card>
  </form>
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required } from 'vuelidate/lib/validators'
import Pedido from '~/components/Pedido.vue'

export default {
  components: {
    Pedido
  },

  mixins: [validationMixin],

  validations: {
    model: {
      loja: { required }
    }
  },

  data: () => ({
    isLoaded: false,
    showCheckout: false,
    model: {
      loja: "",
      precoTotal: 0,
      tempoDePreparo: 0
    },
    items: {
      lojas: [],
      tamanhos: [],
      sabores: [],
      adicionais: [],
      transacoes: []
    }
  }),

  computed: {
  },

  beforeMount() {
    this.$nextTick(() => {
      this.$nuxt.$loading.start()
    })

    this.reqs = [
      this.getLojas()
    ]

    Promise.all(this.reqs).then((_) => {
      this.$nuxt.$loading.finish()
      this.isLoaded = true
    })
  },

  methods: {
    getLojas() {
      return this.$repositories.lojas
        .getAll()
        .then((data) => (this.items.lojas = data))
    },
    getItems(type) {
      return this.$repositories[type]
        .getAll()
        .then((data) => (this.items[type] = data))
    },
    errorsRadioGroup(field) {
      const errors = []
      if (!this.$v.model[field].$dirty) return errors
      !this.$v.model[field].required && errors.push('Campo obrigatório')
      return errors
    },
    getPayload() {
      return {
        tamanhoId: this.model.tamanho.id,
        saborId: this.model.sabor.id,
        adicionais:
          this.model.adicionais && this.model.adicionais.map((a) => a.id)
      }
    },
    async fazerCheckout() {
      // this.$v.$touch()
      // if (this.$v.$invalid) return

      this.$nuxt.$loading.start()

      const { data } = await this.$axios.get(
        '/api/Transacoes?nomeLoja=' + this.model.loja,
      )

      this.items.transacoes = data;

      this.$nuxt.$loading.finish()
    },
    async submit() {
      this.$v.$touch()
      if (this.$v.$invalid) return

      this.$nuxt.$loading.start()

      const pedido = await this.$repositories.pedidos.post(this.getPayload())

      this.$nuxt.$loading.finish()

      this.$router.push(`/pedidos/${pedido.id}`)
    },
    clear() {
      this.$v.model.$reset()
      this.model = {}
    }
  }
}
</script>
