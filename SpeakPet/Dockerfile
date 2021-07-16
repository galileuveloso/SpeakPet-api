#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ARG HTTP_PORT
ARG HTTPS_PORT
WORKDIR /app
EXPOSE ${HTTP_PORT} ${HTTPS_PORT}

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SpeakPet/SpeakPet.csproj", "SpeakPet/"]
COPY ["SpeakPet.Services/SpeakPet.Servicos.csproj", "SpeakPet.Services/"]
COPY ["SpeakPet.DAO/SpeakPet.DAO.csproj", "SpeakPet.DAO/"]
COPY ["SpeakPet.Dominio/SpeakPet.Dominio.csproj", "SpeakPet.Dominio/"]
RUN dotnet restore "SpeakPet/SpeakPet.csproj"
COPY . .
WORKDIR "/src/SpeakPet"
RUN dotnet build "SpeakPet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpeakPet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpeakPet.dll"]
