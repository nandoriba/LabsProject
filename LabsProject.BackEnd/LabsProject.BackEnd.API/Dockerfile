#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LabsProject.BackEnd.API/LabsProject.BackEnd.API.csproj", "LabsProject.BackEnd.API/"]
COPY ["LabsProject.BackEnd.Infrastructure/LabsProject.BackEnd.Infrastructure.csproj", "LabsProject.BackEnd.Infrastructure/"]
COPY ["LabsProject.BackEnd.Domain/LabsProject.BackEnd.Domain.csproj", "LabsProject.BackEnd.Domain/"]
RUN dotnet restore "LabsProject.BackEnd.API/LabsProject.BackEnd.API.csproj"
COPY . .
WORKDIR "/src/LabsProject.BackEnd.API"
RUN dotnet build "LabsProject.BackEnd.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LabsProject.BackEnd.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabsProject.BackEnd.API.dll"]