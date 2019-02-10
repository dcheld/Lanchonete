FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["../Pedido.API/Pedido.API.csproj", "../Pedido.API/"]
RUN dotnet restore "../Pedido.API/Pedido.API.csproj"
COPY . .
WORKDIR "/src/../Pedido.API"
RUN dotnet build "Pedido.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pedido.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pedido.API.dll"]