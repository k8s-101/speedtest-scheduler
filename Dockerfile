FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY */*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./SpeedtestScheduler ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:runtime
WORKDIR /app
COPY ./SpeedtestScheduler/appsettings.json ./
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SpeedtestScheduler.dll"]