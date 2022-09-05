#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Meal Planner API/Meal Planner API.csproj", "Meal Planner API/"]
RUN dotnet restore "Meal Planner API/Meal Planner API.csproj"
COPY . .
WORKDIR "/src/Meal Planner API"
RUN dotnet build "Meal Planner API.csproj" -c DockerDebug -o /app/build

FROM build AS publish
RUN dotnet publish "Meal Planner API.csproj" -c DockerDebug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meal Planner API.dll"]