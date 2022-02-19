FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotnetApiStarter.Application.Api/DotnetApiStarter.Application.Api.csproj", "DotnetApiStarter.Application.Api/"]
RUN dotnet restore "DotnetApiStarter.Application.Api/DotnetApiStarter.Application.Api.csproj"
COPY . .
WORKDIR "/src/DotnetApiStarter.Application.Api"
RUN dotnet build "DotnetApiStarter.Application.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetApiStarter.Application.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetApiStarter.Application.Api.dll"]
