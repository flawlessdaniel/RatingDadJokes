#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RatingDadJokesAPI/RatingDadJokesAPI.csproj", "RatingDadJokesAPI/"]
COPY ["RatingDadJokes.Cache.Redis/RatingDadJokes.Cache.Redis.csproj", "RatingDadJokes.Cache.Redis/"]
COPY ["RatingDadJokes.Cache/RatingDadJokes.Cache.csproj", "RatingDadJokes.Cache/"]
COPY ["RatingDadJokes.Core/RatingDadJokes.Core.csproj", "RatingDadJokes.Core/"]
COPY ["RatingDadJokes.Data.Service/RatingDadJokes.Data.Service.csproj", "RatingDadJokes.Data.Service/"]
COPY ["RatingDadJokes.Data/RatingDadJokes.Data.csproj", "RatingDadJokes.Data/"]
COPY ["RatingDadJokes.ExternalData.DadJokesIo/RatingDadJokes.ExternalData.DadJokesIo.csproj", "RatingDadJokes.ExternalData.DadJokesIo/"]
COPY ["RatingDadJokes.ExternalData/RatingDadJokes.ExternalData.csproj", "RatingDadJokes.ExternalData/"]
COPY ["RatingDadJokes.Shared.Discovery/RatingDadJokes.Shared.Discovery.csproj", "RatingDadJokes.Shared.Discovery/"]
COPY ["RatingDadJokes.Shared.Secrets/RatingDadJokes.Shared.Secrets.csproj", "RatingDadJokes.Shared.Secrets/"]
RUN dotnet restore "RatingDadJokesAPI/RatingDadJokesAPI.csproj"
COPY . .
WORKDIR "/src/RatingDadJokesAPI"
RUN dotnet build "RatingDadJokesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RatingDadJokesAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RatingDadJokesAPI.dll"]