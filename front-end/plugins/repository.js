import createRepository from '~/api/Repository.js'

export default (ctx, inject) => {
  const repositoryWithAxios = createRepository(ctx.$axios)

  const repositories = {
    //pedidos: repositoryWithAxios('pedidos')
  }

  inject('repositories', repositories)
}
