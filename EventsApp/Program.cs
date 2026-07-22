public delegate void Notify(string msg);
public delegate void T_ChangeHandler(string msg);

public class EventPublisher
{
    public event Notify OnNotify;

    public void RaiseEvent(string msg) => OnNotify?.Invoke(msg);
}

public class EventSubscriber
{
    public void OnEventRaised(string msg) => Console.WriteLine($"EVENT RAISED: {msg}");
}

public class T_Monitor
{
    private decimal _t;
    private decimal _threshold;

    public decimal Threshold
    {
        get { return _threshold; }
        set { _threshold = value; }
    }
    public decimal T
    {
        get { return _t; }
		set
		{
			_t = value;
			if (_t > Threshold)
			{
				// RAISE EVENT
			}
		}

				protected void RaiseT_ChangeEvent(string msg)=>Console.WriteLine($"TEMPERATURE CHANGE EVENT: {msg}");
    }
}
