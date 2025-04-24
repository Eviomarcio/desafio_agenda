# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# RUN apt-get update && apt-get install -y postgresql-client

RUN apt-get update && \
    apt-get install -y postgresql-client && \
    dotnet tool install --global dotnet-ef

# Adiciona tools ao PATH
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /src

COPY ["Agenda.API/Agenda.API.csproj", "Agenda.API/"]
COPY ["Agenda.Application/Agenda.Application.csproj", "Agenda.Application/"]
COPY ["Agenda.Domain/Agenda.Domain.csproj", "Agenda.Domain/"]
COPY ["Agenda.Infrastructure/Agenda.Infrastructure.csproj", "Agenda.Infrastructure/"]
COPY ["Agenda.Tests/Agenda.Tests.csproj", "Agenda.Tests/"]

RUN dotnet restore "Agenda.API/Agenda.API.csproj"

COPY . .

COPY wait-for-postgres.sh ./wait-for-postgres.sh
RUN chmod +x ./wait-for-postgres.sh

WORKDIR "/src/Agenda.API"
RUN dotnet publish "Agenda.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "Agenda.API.dll"]
