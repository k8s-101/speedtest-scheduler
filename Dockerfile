FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-stage
WORKDIR /SpeedtestScheduler

COPY /SpeedtestScheduler/SpeedtestScheduler.csproj ./
RUN dotnet restore

COPY /SpeedtestScheduler ./
RUN dotnet publish \
    --output /PublishedApp \
    --configuration Release

FROM mcr.microsoft.com/dotnet/core/runtime:3.1
LABEL repository="github.com/k8s-101/speedtest-scheduler"
WORKDIR /SpeedtestScheduler

COPY --from=build-stage /PublishedApp .
ENTRYPOINT ["dotnet", "SpeedtestScheduler.dll"]
