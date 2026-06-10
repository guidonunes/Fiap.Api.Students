FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Fiap.Api.Students/Fiap.Api.Students.csproj", "Fiap.Api.Students/"]
RUN dotnet restore "Fiap.Api.Students/Fiap.Api.Students.csproj"
COPY . .
WORKDIR "/src/Fiap.Api.Students"
RUN dotnet build "./Fiap.Api.Students.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Fiap.Api.Students.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Api.Students.dll"]
