# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore dependencies
COPY ["CalculatorAPI/CalculatorAPI.csproj", "CalculatorAPI/"]
COPY ["Calculator/Calculator.csproj", "Calculator/"]
RUN dotnet restore "CalculatorAPI/CalculatorAPI.csproj"

# Copy the entire project and build
COPY . .
WORKDIR "/src/CalculatorAPI"
RUN dotnet build "CalculatorAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CalculatorAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatorAPI.dll"]
