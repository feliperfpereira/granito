# Use the .NET Core 6.0 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory to the API folder
WORKDIR /GRANITO/API/Calculo

# Copy the .csproj files for the API project and the Juros project
COPY Calculo.csproj .

# Restore the NuGet packages for both projects
RUN dotnet restore Calculo.csproj

# Copy the entire API folder to the container
COPY . .

# Build the Calculo project
RUN dotnet build -c Release Calculo.csproj


# Publish both projects
RUN dotnet publish Calculo.csproj -c Release -o /app/calculo

# Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory to the app folder
WORKDIR /app

# Copy the published output from the build stage to the app folder
COPY --from=build /app/calculo ./calculo

# Start both projects on ports 80 and 81 respectively
EXPOSE 80
CMD ["dotnet", "calculo/Calculo.dll"] 

