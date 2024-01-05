FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
FROM build AS publish
RUN dotnet tool install --global dotnet-ef
RUN dotnet ef migrations add InitialCreate -s src/Presentation/API -p src/Infrastructure
RUN dotnet ef database update -s src/Presentation/API -p src/Infrastructure

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
USER $APP_UID
COPY --from=publish /App/out .
ENTRYPOINT ["dotnet", "API.dll"]
