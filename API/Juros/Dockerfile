# Use the .NET Core 6.0 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory to the API folder
WORKDIR /GRANITO/API/Juros

# Copy the .csproj files for the API project and the Juros project
COPY Juros.csproj .

# Restore the NuGet packages for both projects
RUN dotnet restore Juros.csproj

# Copy the entire API folder to the container
COPY . .

# Build the Juros project
RUN dotnet build -c Release Juros.csproj

# Publish both projects
RUN dotnet publish Juros.csproj -c Release -o /app/juros

# Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory to the app folder
WORKDIR /app

# Copy the published output from the build stage to the app folder
COPY --from=build /app/juros ./juros

# Start both projects on ports 80 and 81 respectively
EXPOSE 80
CMD ["dotnet", "juros/Juros.dll"]

