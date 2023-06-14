FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Frontendv2/Frontendv2.csproj", "Frontendv2/"]
RUN dotnet restore "Frontendv2/Frontendv2.csproj"
COPY . .
WORKDIR "/src/Frontendv2"
RUN dotnet build "Frontendv2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Frontendv2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frontendv2.dll"]
