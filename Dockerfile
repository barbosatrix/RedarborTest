# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar soluci�n y csproj primero (mejor cache)
COPY Redarbor.sln ./
COPY Redarbor.Api/Redarbor.Api.csproj Redarbor.Api/
COPY Redarbor.Domain/Redarbor.Domain.csproj Redarbor.Domain/
COPY Redarbor.Infrastructure/Redarbor.Infrastructure.csproj Redarbor.Infrastructure/
COPY Redarbor.Application/Redarbor.Application.csproj Redarbor.Application/
COPY Redarbor.UnitTests/Redarbor.UnitTests.csproj Redarbor.UnitTests/

RUN dotnet restore Redarbor.sln

# Copiar todo el repo
COPY . .
RUN dotnet publish Redarbor.Api/Redarbor.Api.csproj -c Release -o /app/publish

# Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Redarbor.Api.dll"]