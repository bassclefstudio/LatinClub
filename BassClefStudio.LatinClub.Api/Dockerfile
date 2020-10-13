#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BassClefStudio.LatinClub.Api/BassClefStudio.LatinClub.Api.csproj", "BassClefStudio.LatinClub.Api/"]
RUN dotnet restore "BassClefStudio.LatinClub.Api/BassClefStudio.LatinClub.Api.csproj"
COPY . .
WORKDIR "/src/BassClefStudio.LatinClub.Api"
RUN dotnet build "BassClefStudio.LatinClub.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BassClefStudio.LatinClub.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BassClefStudio.LatinClub.Api.dll"]