# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

EXPOSE 80

# Copy csproj and restore as distinct layers
COPY API.Cosmere.sln ./
COPY src/API/API.Cosmere.csproj ./src/API/
COPY src/Data/Data.csproj ./src/Data/
COPY tests/API.Cosmere.Tests.csproj ./tests/
COPY src/Repository/Repository.csproj ./src/Repository/
RUN dotnet restore

# Copy everything else and build
COPY ./src ./src
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "API.Cosmere.dll"]
