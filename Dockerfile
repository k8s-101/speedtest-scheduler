
FROM microsoft/dotnet:2.1
WORKDIR /src
COPY SpeedtestScheduler/SpeedtestScheduler.csproj SpeedtestScheduler/
RUN dotnet restore SpeedtestScheduler/SpeedtestScheduler.csproj

COPY . .

WORKDIR /src/SpeedtestScheduler
RUN dotnet build SpeedtestScheduler.csproj -c Release -o /app

ENTRYPOINT ["dotnet", "/app/SpeedtestScheduler.dll"]
