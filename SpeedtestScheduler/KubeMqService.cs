using System;
using KubeMQ.SDK.csharp.Tools;
using KubeMQ.SDK.csharp.Events.LowLevel;

namespace SpeedtestScheduler
{
  public class KubeMqService
  {
    private Sender sender;
    private Configuration config;
    public KubeMqService(Configuration config)
    {
      this.config = config;
      sender = new Sender(config.kubeMQAddress);
    }

    public void SendStartLoggingEvent()
    {
      Console.WriteLine($"Sending start-logging event to KubeMQ at {config.kubeMQAddress}");

      var @event = CreateNewEvent();
      sender.SendEvent(@event);

      Console.WriteLine("Event sendt!");

    }

    protected Event CreateNewEvent()
    {
      Event @event = new Event()
      {
        Metadata = "StartToLogg",
        Body = Converter.ToByteArray($"Event Created on time {DateTime.UtcNow}"),
        Store = false,
        Channel = this.config.Channel,
        ClientID = this.config.ClientID,
        ReturnResult = false
      };
      return @event;
    }
  }
}