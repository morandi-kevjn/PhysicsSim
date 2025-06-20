FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the Web project and the Core library
COPY PhysicsSim.Web/ ./PhysicsSim.Web/
COPY PhysicsSim.Core/ ./PhysicsSim.Core/

# Restore and Publish Web Application
WORKDIR /src/PhysicsSim.Web
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "PhysicsSim.Web.dll"]