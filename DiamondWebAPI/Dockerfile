#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DiamondWebAPI/DiamondWebAPI.csproj", "DiamondWebAPI/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataBase/DataBase.csproj", "DataBase/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "DiamondWebAPI/DiamondWebAPI.csproj"
COPY . .
WORKDIR "/src/DiamondWebAPI"
RUN dotnet build "DiamondWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiamondWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiamondWebAPI.dll"]