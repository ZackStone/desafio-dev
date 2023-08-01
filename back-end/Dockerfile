# Imagem para o build usando o sdk
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app

# Seta caminho do .csproj
ARG PROJ_PATH="./1 - Application/DesafioCnab.Application"
ARG CSPROJ=${PROJ_PATH}/DesafioCnab.Application.csproj

# Copia o código fonte e roda o build
COPY . ./
RUN dotnet publish "${CSPROJ}" -c Release -o /app/out

# Imagem para a execução usando o runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app

RUN apk add --no-cache icu-libs tzdata
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ENV ASPNETCORE_URLS=http://+:80

# Copia os arquivos do build e inicia a aplicação
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "DesafioCnab.Application.dll"]
