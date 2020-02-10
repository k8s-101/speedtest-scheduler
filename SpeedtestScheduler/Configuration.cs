using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SpeedtestScheduler
{
  public class Configuration
  {
    internal readonly string Channel;
    internal readonly string Address;
    internal readonly string ClientID;

    public Configuration()
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .AddJsonFile("appsettings.Development.json", optional: true)
          .AddEnvironmentVariables();

      var configuration = builder.Build();

      Channel = configuration["KubeMQ_Channel"];
      ClientID = configuration["KubeMQ_ClientID"];
      Address = configuration["KubeMQ_ServerAddress"];
    }

  }
}
