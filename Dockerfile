# Use the .NET Core 6.0 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory to the API folder
WORKDIR /GRANITO/API

# Copy the .csproj file for the API project
COPY API/Calculo.csproj .

# Restore the NuGet packages for the API project
RUN dotnet restore

# Copy the entire API folder to the container
COPY API .

# Build the API project
RUN dotnet build -c Release -o /app

# Switch to the Test folder
WORKDIR /GRANITO/Tests

# Copy the .csproj file for the Test project
COPY Tests/Tests.csproj .

# Restore the NuGet packages for the Test project
RUN dotnet restore

# Copy the entire Test folder to the container
COPY Tests .

# Build the Test project
RUN dotnet build -c Release -o /app

# Switch back to the API folder
WORKDIR /GRANITO/API

# Publish the API project
RUN dotnet publish -c Release -o /app

# Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory to the app folder
WORKDIR /app

# Copy the published output from the build stage to the app folder
COPY --from=build /app .

# Start the API on port 8080
EXPOSE 80
ENTRYPOINT ["dotnet", "Calculo.dll"]