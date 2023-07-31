<template>
  <form v-show="isLoaded">
    <v-card>
      <v-card-title>
        Pesquisar transações por loja
      </v-card-title>
      <v-card-text>
        <v-container fluid>
          <v-row>
            <v-col cols="6">
              <v-select
                v-model="model.loja"
                label="Loja"
                :items="items.lojas"
                :error-messages="validationErrorsLoja"
              >
              </v-select>
            </v-col>
            <v-col cols="6">
              Saldo: {{ $n(saldo,'currency') }}
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" large @click="fazerCheckout">Pesquisar</v-btn>
        <v-btn color="accent" large @click="clear">Limpar</v-btn>
      </v-card-actions>
      <v-simple-table>
        <thead>
          <tr>
            <th>Data/Hora</th>
            <th>Tipo</th>
            <th>Valor</th>
            <th>CPF</th>
            <th>Cartão</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="item in transacoes"
            :key="item.id"
          >
            <td>{{ $d(new Date(item.dataHora), 'short') }}</td>
            <td>{{ item.tipoTransacao.descricao }}</td>
            <td>{{ `(${item.tipoTransacao.naturezaTransacao.sinal}) ${$n(item.valor,'currency')}` }}</td>
            <td>{{ item.cpf }}</td>
            <td>{{ item.cartao }}</td>
          </tr>
        </tbody>
      </v-simple-table>
    </v-card>
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
      loja: { required }
    }
  },

  data: () => ({
    isLoaded: false,
    showCheckout: false,
    model: {
      loja: ""
    },
    items: {
      lojas: []
    },
    transacoes: [],
    saldo: 0
  }),

  computed: {
    validationErrorsLoja() {
      return this.getValidationErrors('loja')
    }
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
    getValidationErrors(field) {
      const errors = []
      if (!this.$v.model[field].$dirty) return errors
      !this.$v.model[field].required && errors.push('Campo obrigatório')
      return errors
    },
    getLojas() {
      return this.$repositories.lojas
        .getAll()
        .then((data) => (this.items.lojas = data))
    },
    async fazerCheckout() {
      this.$v.$touch()
      if (this.$v.$invalid) return

      this.$nuxt.$loading.start()

      const { data } = await this.$axios.get(
        '/api/Transacoes?nomeLoja=' + this.model.loja,
      )

      this.transacoes = data.transacoes
      this.saldo = data.saldo

      this.$nuxt.$loading.finish()
    },
    clear() {
      this.$v.model.$reset()
      this.model = {}
      this.transacoes = []
      this.saldo = 0
    }
  }
}
</script>
