#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LabProject.BackEnd.Api/LabProject.BackEnd.Api.csproj", "LabProject.BackEnd.Api/"]
RUN dotnet restore "LabProject.BackEnd.Api/LabProject.BackEnd.Api.csproj"
COPY . .
WORKDIR "/src/LabProject.BackEnd.Api"
RUN dotnet build "LabProject.BackEnd.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LabProject.BackEnd.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabProject.BackEnd.Api.dll"]