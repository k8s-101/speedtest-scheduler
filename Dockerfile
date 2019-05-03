FROM microsoft/dotnet:2.1-sdk AS build-stage
WORKDIR /SpeedtestScheduler

COPY /SpeedtestScheduler/SpeedtestScheduler.csproj ./
RUN dotnet restore

COPY /SpeedtestScheduler ./
RUN dotnet publish \
    --output ./PublishedApp \
    --configuration Release \
    --no-restore

FROM microsoft/dotnet:2.1-aspnetcore-runtime
LABEL repository="github.com/k8s-101/speedtest-scheduler"
WORKDIR /SpeedtestScheduler

COPY --from=build-stage /SpeedtestScheduler/PublishedApp ./
ENTRYPOINT ["dotnet", "SpeedtestScheduler.dll"]
