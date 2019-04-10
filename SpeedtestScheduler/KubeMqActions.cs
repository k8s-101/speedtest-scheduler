using System;
using KubeMQ.SDK.csharp.Tools;
using KubeMQ.SDK.csharp.Events.LowLevel;

namespace SpeedtestScheduler
{
  public class KubeMqActions
  {
    private Sender sender;
    public KubeMqActions(string serverAddress)
    {
      sender = new Sender(serverAddress);
    }

    public void SendStartLoggingEvent()
    {
      var @event = CreateNewEvent();
      sender.SendEvent(@event);
    }

    protected Event CreateNewEvent()
    {
      Event @event = new Event()
      {
        Metadata = "StartToLogg",
        Body = Converter.ToByteArray($"Event Created on time {DateTime.UtcNow}"),
        Store = false,
        Channel = "Speedtest",
        ClientID = "speedtest-scheduler",
        ReturnResult = false
      };
      return @event;
    }
  }
}