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

## Problemas com compatibilidade de final de arquivo entre Win/Linux
- Executar `git config --global core.autocrlf true`
