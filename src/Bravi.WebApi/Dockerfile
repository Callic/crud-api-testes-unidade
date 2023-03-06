#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#ENV ASPNETCORE_URLS=http://+:5020;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bravi.WebApi/Bravi.WebApi.csproj", "src/Bravi.WebApi/"]
COPY ["Bravi.Application/Bravi.Application.csproj", "src/Bravi.Application/"]
COPY ["Bravi.Infra/Bravi.Infra.csproj", "src/Bravi.Infra/"]
COPY ["Bravi.Domain/Bravi.Domain.csproj", "src/Bravi.Domain/"]
RUN dotnet restore "src/Bravi.WebApi/Bravi.WebApi.csproj"
COPY . .
WORKDIR "Bravi.WebApi"
RUN dotnet build "Bravi.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bravi.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bravi.WebApi.dll"]