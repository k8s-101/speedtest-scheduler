using System;
using KubeMQ.SDK.csharp.Tools;
using KubeMQ.SDK.csharp.Events.LowLevel;

namespace SpeedtestScheduler
{
  public class KubeMqClient
  {
    private readonly string _channel;
    private readonly string _address;
    private readonly string _clientID;
    public KubeMqClient(string address, string channel, string clientId)
    {
      _address = address;
      _channel = channel;
      _clientID = clientId;
    }

    public void SendStartLoggingEvent()
    {
      Console.WriteLine($"Sending event to KubeMQ at {_address}");

      var sender = new Sender(_address);
      var @event = CreateNewEvent();
      sender.SendEvent(@event);

      Console.WriteLine("Event sendt!");
    }

    protected Event CreateNewEvent()
    {
      Event @event = new Event()
      {
        Metadata = "StartToLogg",
        Body = Converter.ToByteArray($"Event created by speedtest-scheduler on time {DateTime.UtcNow}"),
        Store = false,
        Channel = _channel,
        ClientID = _clientID,
        ReturnResult = false
      };
      return @event;
    }
  }
}