FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /src
WORKDIR /src/Home.WebApi
RUN dotnet publish "Home.WebApi.csproj" -c Release -o /app/build /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS final

ENV ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV NUGET_PACKAGES=/root/.nuget/fallbackpackages
ENV NUGET_FALLBACK_PACKAGES=/root/.nuget/fallbackpackages 

WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "Home.WebApi.dll"]