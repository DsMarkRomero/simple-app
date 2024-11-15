# Use the official .NET image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Install SQL Server tools
RUN apt-get update && apt-get install -y curl
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/debian/11/prod.list > /etc/apt/sources.list.d/mssql-release.list
RUN apt-get update && ACCEPT_EULA=Y apt-get install -y mssql-tools
RUN echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc

WORKDIR /app
COPY --from=build /app/out .
COPY PrimeNumberDB.sql .
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

# Expose port 80
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["./entrypoint.sh"]