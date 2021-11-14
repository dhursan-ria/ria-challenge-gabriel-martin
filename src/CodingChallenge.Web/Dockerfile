FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CodingChallenge.Web/CodingChallenge.Web.csproj", "CodingChallenge.Web/"]
RUN dotnet restore "CodingChallenge.Web/CodingChallenge.Web.csproj"
COPY . .
WORKDIR "/src/CodingChallenge.Web"
RUN dotnet build "CodingChallenge.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodingChallenge.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodingChallenge.Web.dll"]
