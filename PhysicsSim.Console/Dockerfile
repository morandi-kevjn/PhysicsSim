FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY PhysicsSim.Core/*.csproj PhysicsSim.Core/
COPY PhysicsSim.Console/*.csproj PhysicsSim.Console/

COPY PhysicsSim.Core/ ./PhysicsSim.Core/
COPY PhysicsSim.Console/ ./PhysicsSim.Console/

WORKDIR /app/PhysicsSim.Console

RUN dotnet restore
RUN dotnet build -c Release
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "PhysicsSim.Console.dll"]