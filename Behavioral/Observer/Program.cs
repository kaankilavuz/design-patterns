Stock appleStock = new Stock("AAPL", 150.00);

Investor investor1 = new Investor("John");
Investor investor2 = new Investor("Jane");

appleStock.RegisterObserver(investor1);
appleStock.RegisterObserver(investor2);


appleStock.SetPrice(155.00);
appleStock.SetPrice(160.00);

appleStock.RemoveObserver(investor1);
appleStock.SetPrice(165.00);

Console.ReadKey();

public interface IObserver
{
    void Update(string stockSymbol, double price);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class Stock : ISubject
{
    private List<IObserver> _observers;
    private string _symbol;
    private double _price;

    public Stock(string symbol, double price)
    {
        _symbol = symbol;
        _price = price;
        _observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_symbol, _price);
        }
    }

    public void SetPrice(double price)
    {
        _price = price;
        NotifyObservers();
    }
}

public class Investor : IObserver
{
    private string _name;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(string stockSymbol, double price)
    {
        Console.WriteLine($"Notified {_name} of {stockSymbol}'s change to {price}");
    }
}

