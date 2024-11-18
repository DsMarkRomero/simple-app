# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo csproj y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Generar la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar la salida del build
COPY --from=build /app/out .

# Exponer el puerto 80
EXPOSE 80

# Definir el punto de entrada
ENTRYPOINT ["dotnet", "PrimeNumberApi2.dll"]
