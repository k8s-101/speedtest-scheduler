using System;

namespace SpeedtestScheduler
{
  class Program
  {

    static void Main(string[] args)
    {
      {
        Console.WriteLine("Starting Speedtest-scheduler...");
        SendCommand();
        Console.WriteLine("Speedtest-scheduler done");
      }
    }

    static void SendCommand()
    {
      try
      {
        var config = new Configuration();
        KubeMqClient kubeMqActions = new KubeMqClient(config.Address, config.Channel, config.ClientID);
        kubeMqActions.SendStartLoggingEvent();
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"Error: Unable to send command {ex}");
        Environment.Exit(1);
      }
    }
  }
}
