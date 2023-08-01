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

### Rodar front-end
- Navegar até a pasta front-end
- Instalar dependencias com `npm i`
- Executar `npm run dev`
- Acesso: http://localhost:3000/
