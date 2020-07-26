#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LojaEmpresaPequena.Services/LojaEmpresaPequena.Services.csproj", "LojaEmpresaPequena.Services/"]
COPY ["LojaEmpresaPequena.Application/LojaEmpresaPequena.Application.csproj", "LojaEmpresaPequena.Application/"]
COPY ["LojaEmpresaPequena.Domain/LojaEmpresaPequena.Domain.csproj", "LojaEmpresaPequena.Domain/"]
COPY ["LojaEmpresaPequena.Context/LojaEmpresaPequena.Context.csproj", "LojaEmpresaPequena.Context/"]
COPY ["LojaEmpresaPequena.Ioc/LojaEmpresaPequena.Ioc.csproj", "LojaEmpresaPequena.Ioc/"]
RUN dotnet restore "LojaEmpresaPequena.Services/LojaEmpresaPequena.Services.csproj"
COPY . .
WORKDIR "/src/LojaEmpresaPequena.Services"
RUN dotnet build "LojaEmpresaPequena.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaEmpresaPequena.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaEmpresaPequena.Services.dll"]