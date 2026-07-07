EventPublisher publisher = new EventPublisher();
EventSubscriber subscriber = new EventSubscriber();
publisher.OnNotify += subscriber.OnEventRaised;
publisher.RaiseEvent("TESTING THE OCCURRENCE OF AN EVENT");

Console.WriteLine($"Type in the temperature");
decimal t = decimal.Parse(Console.ReadLine());
TemperatureMonitor monitor = new TemperatureMonitor();
TemperatureAlert alert = new TemperatureAlert();
monitor.OnTemperatureChange += alert.OnTemperatureChange;
monitor.Threshold = 50;
monitor.Temperature = t;

public delegate void Notify(string msg);
public delegate void TemperatureChangeHandler(string msg);

public class EventPublisher
{
    public event Notify OnNotify;

    public void RaiseEvent(string msg) => OnNotify?.Invoke(msg);
}

public class EventSubscriber
{
    public void OnEventRaised(string msg) => Console.WriteLine($"Event raised: {msg}");
}

public class TemperatureMonitor
{
    public event TemperatureChangeHandler OnTemperatureChange;

    protected virtual void RaiseTemperatureChangeEvent(string msg) =>
        OnTemperatureChange?.Invoke(msg);

    private decimal _temperature;
    private decimal _threshold;
    public decimal Temperature
    {
        get { return _temperature; }
        set
        {
            _temperature = value;
            if (_temperature > Threshold)
                RaiseTemperatureChangeEvent($"Temperature is above {Threshold}°C!");
        }
    }
    public decimal Threshold
    {
        get { return _threshold; }
        set { _threshold = value; }
    }
}

public class TemperatureAlert
{
    public void OnTemperatureChange(string msg) =>
        Console.WriteLine($"⚠️ TEMPERATURE ALERT: {msg}");
}
