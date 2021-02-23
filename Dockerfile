FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 5002
ENV ASPNETCORE_URLS=http://*:5002

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src

COPY ["/MetWorkingMatch.Presentation/*.csproj", "./MetWorkingMatch.Presentation/"]
COPY ["/MetWorkingMatch.Application/*.csproj", "./MetWorkingMatch.Application/"]
COPY ["/MetWorkingMatch.Domain/*.csproj", "./MetWorkingMatch.Domain/"]
COPY ["/MetWorkingMatch.Infra/*.csproj", "./MetWorkingMatch.Infra/"]

RUN dotnet restore "MetWorkingMatch.Presentation/MetWorkingMatch.Presentation.csproj"
COPY . .

WORKDIR "/src/MetWorkingMatch.Presentation"
RUN dotnet build "MetWorkingMatch.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetWorkingMatch.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MetWorkingMatch.Presentation.dll","--environment=Production"]