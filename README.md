# desafio-cnab

## Executar projeto

### Rodar back-end
- Navegar até a pasta back-end
- Executar `docker-compose up -d`
- Acesso: http://localhost:5000/swagger/index.html

### Preparar BD
- Conectar no banco que subiu com o Docker
  - Server `localhost,5433` / Usuário `sa` / Senha `SQLServer@123`
- Rodar o script setup-database.sql

#### Como executar no Ubuntu
- Abrir o terminal e executar o comando abaixo
  - `sqlcmd -S localhost,5433 -i ./sql-server/setup-database.sql -U sa -P SQLServer@123`

### Rodar front-end
- Navegar até a pasta front-end
- Instalar dependencias com `npm i -d`
- Executar `npm run dev`
- Acesso: http://localhost:3000/

#### Problemas ao rodar front-end
- Conferir se o node.js é >= v14
- Limpar cache
  - `npm cache clean --force`
  - Apagar a pasta node_modules `rm -rf node_modules`
  - Apagar o arquivo `package-lock.json`
  - `npm i -d`
  - `npm run dev`

## Cobertura de testes do back-end
- Instalar o pacote a seguir: `dotnet tool install -g dotnet-reportgenerator-globaltool`
- Instalar a seguinte extesão no VisualStudio: `Run Coverlet Report`
- Rodar: acessar pelo menu "Tools" > "Run code coverage"
- Passo a passo de como rodar manualmente (sem VisualStudio, em Ubuntu, por exemplo): https://renatogroffe.medium.com/net-5-cobertura-de-testes-com-coverlet-7cbec2f052d9

## Problemas com compatibilidade de final de arquivo entre Win/Linux
- Executar `git config --global core.autocrlf true`