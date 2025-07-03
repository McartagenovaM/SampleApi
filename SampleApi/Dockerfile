# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar dependencias
COPY SampleApi.csproj .
#restauro los nuget y dependencias
RUN dotnet restore
# Copiar el resto del código y compilar
COPY . .
# compilo el proyecto en modo release
RUN dotnet publish -c Release -o /app
# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Metadata básica
LABEL maintainer="Miguel.Cartagenova"
LABEL version="1.0.0"
LABEL description="SampleApi - API de ejemplo con servicios dummy y consulta externa"


# Comando de entrada
ENTRYPOINT ["dotnet", "SampleApi.dll"]

#docker build -t samplenetapi .
#docker run -it --name samplews -p 7241:7214 samplenetapi
