#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StockApi.UI/StockApi.UI.csproj", "StockApi.UI/"]
RUN dotnet restore "StockApi.UI/StockApi.UI.csproj"
COPY . .
WORKDIR "/src/StockApi.UI"
RUN dotnet build "StockApi.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockApi.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockApi.UI.dll"]