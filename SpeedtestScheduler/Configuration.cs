using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SpeedtestScheduler
{
  public class Configuration
  {
    internal readonly string kubeMQAddress;
    internal readonly string Channel;
    internal readonly string ClientID;

    public Configuration()
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .AddJsonFile("appsettings.Development.json", optional: true)
          .AddEnvironmentVariables();

      var configuration = builder.Build();

      Channel = configuration["channel"];
      ClientID = configuration["clientID"];
      kubeMQAddress = configuration["kubeMQAddress"];
    }

  }
}
