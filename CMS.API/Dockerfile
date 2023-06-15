# The build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app --configuration Release

# The runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/published-app /app
COPY --from=build /app/server.db /app

ENV ASPNETCORE_ENVIRONMENT=production

# Expose port 80 for browser access
EXPOSE 5000

ENTRYPOINT [ "dotnet", "/app/CMS.API.dll", "--urls", "http://+:5000" ]