// Create an advanced stock price monitoring system in C# that demonstrates the use of delegates and events with dynamic thresholds. The program should:
// 1) Define a delegate StockPriceChangedHandler that takes a string message as a parameter.

// 2) Create a class Stock with:
//      An event OnStockPriceChanged of type StockPriceChangedHandler.
//      A private field _price of type decimal.
//      A private field _threshold of type decimal.
//      A property Price with a getter and setter. The setter should raise the event if the price drops below the threshold.
//      A property Threshold with a getter and setter to dynamically set the alert threshold.
//      A method RaiseStockPriceChangedEvent that raises the event with the appropriate message.
// 3) Define a subscriber class StockAlert with a method OnStockPriceChanged that prints the alert message to the console.

// In the Program class:
// 1) Instantiate the Stock and StockAlert classes.
// 2) Subscribe the StockAlert method to the Stock event.
// 3) Set a dynamic threshold and simulate stock price changes to trigger the alert.

// Alert!
// The result of execution should show stock price alerts based on the dynamically set threshold printed to the console.
// Example:
// For a threshold of 120 and stock prices of 150, 130, 110, the output should be:
// 		scssCopy code(No alert for 150)
// 		(No alert for 130)
// 		Stock Alert: Stock price is below threshold!

// TRAIN OF THOUGHT
// 1 - Create the delegate (contract that both the event and the methods will use)
// 2 - Create the sender class (Stock)
// 2.1 - Declare private fields (_price and _threshold)
// 2.2 - Declare the delegate event (OnPriceChanged)
// 2.3 - Create the helper method to raise the event (RaisePriceChangedEvent)
// 2.4 - Declare the public fields derived from the private fields (Price and Threshold)
// 2.5 - Infuse the conditions that will trigger the event using the helper method
// 3 - Create the subscriber class (StockAlert)
// 3.1 - Create the method that will receive the event (OnPRiceChanged). Make sure its type matches exactly the delegate event
// 4 - Instantiate the objects (myStock and myAlert)
// 5 - Subscribe the alert's method to the event

Stock myStock = new Stock();
StockAlert myAlert = new StockAlert();
myStock.OnPriceChanged += myAlert.OnPriceChanged;
myStock.Threshold = 100m;
Console.WriteLine($"Stock price = 50");
myStock.Price = 50m;
Console.WriteLine($"Stock price = 120");
myStock.Price = 120m;
Console.WriteLine($"Stock price = 9999");
myStock.Price = 9999m;

public delegate void StockPriceChangeHandler(string msg);

public class Stock
{
    public event StockPriceChangeHandler OnPriceChanged;

    protected void RaisePriceChangedEvent(string msg) => OnPriceChanged?.Invoke(msg);

    private decimal _price;
    private decimal _threshold;
    public decimal Price
    {
        get { return _price; }
        set
        {
            _price = value;
            if (_price < Threshold)
                RaisePriceChangedEvent("Stock price fell below the threshold!");
            if (_price > 2 * Threshold)
                RaisePriceChangedEvent("Stock price is above 2x the threshold!");
        }
    }
    public decimal Threshold
    {
        get { return _threshold; }
        set { _threshold = value; }
    }
}

public class StockAlert
{
    public void OnPriceChanged(string msg) => Console.WriteLine($"STOCK PRICE ALERT: {msg}");
}
