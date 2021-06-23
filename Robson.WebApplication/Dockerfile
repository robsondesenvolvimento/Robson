#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Robson.WebApplication/Robson.WebApplication.csproj", "Robson.WebApplication/"]
COPY ["Robson.Services.Common/Robson.Services.Common.csproj", "Robson.Services.Common/"]
COPY ["Robson.Common/Robson.Common.csproj", "Robson.Common/"]
RUN dotnet restore "Robson.WebApplication/Robson.WebApplication.csproj"
COPY . .
WORKDIR "/src/Robson.WebApplication"
RUN dotnet build "Robson.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Robson.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Robson.WebApplication.dll"]