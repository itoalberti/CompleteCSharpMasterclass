EventPublisher publisher = new EventPublisher();
EventSubscriber subscriber = new EventSubscriber();
publisher.OnNotify += subscriber.OnEventRaised;
publisher.RaiseEvent("TEST");

Console.WriteLine($"Type in a temperature:");
double temperature = double.Parse(Console.ReadLine());
TemperatureMonitor monitor = new TemperatureMonitor();
TemperatureAlert alert = new TemperatureAlert();
monitor.OnTemperatureChange += alert.OnTemperatureChange;
monitor.Temperature = temperature;

public delegate void Notify(string msg);

public class EventPublisher
{
    public event Notify OnNotify;

    public void RaiseEvent(string msg) => OnNotify?.Invoke(msg);
}

public class EventSubscriber
{
    public void OnEventRaised(string msg) => Console.WriteLine($"Event received: {msg}");
}

public delegate void TemperatureChangeHandler(string msg);

public class TemperatureMonitor
{
    public event TemperatureChangeHandler OnTemperatureChange;
    private double _temp;
    public double Temperature
    {
        get { return _temp; }
        set
        {
            _temp = value;
            if (_temp > 30)
                // Raise event
                RaiseTemperatureChangeEvent("======Temperature is above 30°C======");
        }
    }

    protected virtual void RaiseTemperatureChangeEvent(string msg) =>
        OnTemperatureChange?.Invoke(msg);
}

public class TemperatureAlert
{
    public void OnTemperatureChange(string msg) => Console.WriteLine($"ALERT: {msg}");
}
