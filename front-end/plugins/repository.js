import createRepository from '~/api/Repository.js'

export default (ctx, inject) => {
  const repositoryWithAxios = createRepository(ctx.$axios)

  const repositories = {
    lojas: repositoryWithAxios('lojas')
  }

  inject('repositories', repositories)
}
