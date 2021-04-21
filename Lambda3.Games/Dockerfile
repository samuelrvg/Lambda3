
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Lambda3.Games.Api/Lambda3.Games.Api.csproj", "Lambda3.Games.Api/"]
COPY ["Lambda3.Games.Core/Lambda3.Games.Core.csproj", "Lambda3.Games.Core/"]
RUN dotnet restore "Lambda3.Games.Api/Lambda3.Games.Api.csproj"
COPY . .
WORKDIR "/src/Lambda3.Games.Api"
RUN dotnet build "Lambda3.Games.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lambda3.Games.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lambda3.Games.Api.dll"]