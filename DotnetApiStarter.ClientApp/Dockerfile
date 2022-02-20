FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["DotnetApiStarter.ClientApp/DotnetApiStarter.ClientApp.csproj", "DotnetApiStarter.ClientApp/"]
RUN dotnet restore "DotnetApiStarter.ClientApp/DotnetApiStarter.ClientApp.csproj"
COPY . .
WORKDIR "/src/DotnetApiStarter.ClientApp"
RUN dotnet build "DotnetApiStarter.ClientApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetApiStarter.ClientApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetApiStarter.ClientApp.dll"]
