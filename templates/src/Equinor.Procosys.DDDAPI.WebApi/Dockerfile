FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copy solution and project files separately and restore NuGet packages to create layers
COPY *.sln .
COPY Equinor.Procosys.DDDAPI.Command/*.csproj ./Equinor.Procosys.DDDAPI.Command/
COPY tests/Equinor.Procosys.DDDAPI.Command.Tests/*.csproj ./tests/Equinor.Procosys.DDDAPI.Command.Tests/
COPY Equinor.Procosys.DDDAPI.Domain/*.csproj ./Equinor.Procosys.DDDAPI.Domain/
COPY tests/Equinor.Procosys.DDDAPI.Domain.Tests/*.csproj ./tests/Equinor.Procosys.DDDAPI.Domain.Tests/
COPY Equinor.Procosys.DDDAPI.Infrastructure/*.csproj ./Equinor.Procosys.DDDAPI.Infrastructure/
COPY tests/Equinor.Procosys.DDDAPI.Infrastructure.Tests/*.csproj ./tests/Equinor.Procosys.DDDAPI.Infrastructure.Tests/
COPY Equinor.Procosys.DDDAPI.MainApi/*.csproj ./Equinor.Procosys.DDDAPI.MainApi/
COPY tests/Equinor.Procosys.DDDAPI.MainApi.Tests/*.csproj ./tests/Equinor.Procosys.DDDAPI.MainApi.Tests/
COPY Equinor.Procosys.DDDAPI.Query/*.csproj ./Equinor.Procosys.DDDAPI.Query/
COPY tests/Equinor.Procosys.DDDAPI.Query.Tests/*.csproj ./tests/Equinor.Procosys.DDDAPI.Query.Tests/
COPY Equinor.Procosys.DDDAPI.WebApi/*.csproj ./Equinor.Procosys.DDDAPI.WebApi/
COPY tests/Equinor.Procosys.DDDAPI.WebApi.Tests/*.csproj ./tests/Equinor.Procosys.DDDAPI.WebApi.Tests/

# Restore NuGet packages
RUN dotnet restore

# Copy full solution
COPY . .

# Build
RUN dotnet build -c Release --no-restore

# Test runner target
FROM build AS testrunner
WORKDIR /src
RUN dotnet test -c Release --no-build --no-restore
#CMD ["dotnet", "test", "-c Release", "--no-build", "--no-restore"]

# Publish the application
FROM build AS publish
WORKDIR "/src/Equinor.Procosys.DDDAPI.WebApi"
RUN dotnet publish "Equinor.Procosys.DDDAPI.WebApi.csproj" -c Release --no-restore -o /app/publish

# Create a runtime image and copy the application over
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Equinor.Procosys.DDDAPI.WebApi.dll"]