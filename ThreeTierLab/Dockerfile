#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ThreeTierLab/ThreeTierLab.csproj", "ThreeTierLab/"]
RUN dotnet restore "ThreeTierLab/ThreeTierLab.csproj"
COPY . .
WORKDIR "/src/ThreeTierLab"
RUN dotnet build "ThreeTierLab.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ThreeTierLab.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThreeTierLab.dll"]