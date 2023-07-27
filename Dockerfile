FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Evice.Authentication.Api/Evice.Authentication.Api.csproj", "src/Evice.Authentication.Api/"]
COPY ["src/Evice.Authentication.Application/Evice.Authentication.Application.csproj", "src/Evice.Authentication.Application/"]
COPY ["src/Evice.Authentication.Domain/Evice.Authentication.Domain.csproj", "src/Evice.Authentication.Domain/"]
COPY ["src/Evice.Authentication.Infrastructure/Evice.Authentication.Infrastructure.csproj", "src/Evice.Authentication.Infrastructure/"]
COPY ["src/Evice.Authentication.Infrastructure.IoC/Evice.Authentication.Infrastructure.IoC.csproj", "src/Evice.Authentication.Infrastructure.IoC/"]
RUN dotnet restore "src/Evice.Authentication.Api/Evice.Authentication.Api.csproj"
COPY . .
WORKDIR "/src/src/Evice.Authentication.Api"
RUN dotnet build "Evice.Authentication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Evice.Authentication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Evice.Authentication.Api.dll"]