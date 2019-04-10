using System;

namespace SpeedtestScheduler
{
  class Program
  {

    static void Main(string[] args)
    {
      {
        Console.WriteLine("Starting Speedtest-scheduler...");
        SendCommand("localhost:50000");
        Console.WriteLine("Speedtest-scheduler done");
      }
    }

    static void SendCommand(string mqAddress)
    {
      try
      {
        Console.WriteLine("Sending start-logging event to KubeMQ");
        KubeMqActions kubeMqActions = new KubeMqActions(mqAddress);
        kubeMqActions.SendStartLoggingEvent();
        Console.WriteLine("start-logging sent to KubeMQ");

      }
      catch (System.Exception ex)
      {
        Console.WriteLine("Error: Unable to send command", ex);
        Environment.Exit(1);
      }
    }
  }
}
