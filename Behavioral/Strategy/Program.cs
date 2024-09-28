ShoppingCart cart = new ShoppingCart();
cart.AddItem("Book");
cart.AddItem("Pen");
cart.AddItem("Laptop");

cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9876-5432", "John Doe"));
cart.Checkout();

cart.SetPaymentStrategy(new PayPalPayment("john.doe@example.com"));
cart.Checkout();

Console.ReadKey();

public interface IPaymentStrategy
{
    void Pay(double amount);
}


public class CreditCardPayment : IPaymentStrategy
{
    private string _cardNumber;
    private string _cardHolderName;

    public CreditCardPayment(string cardNumber, string cardHolderName)
    {
        _cardNumber = cardNumber;
        _cardHolderName = cardHolderName;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"{amount} paid with credit card.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private string _email;

    public PayPalPayment(string email)
    {
        _email = email;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"{amount} paid using PayPal.");
    }
}

public class ShoppingCart
{
    private List<string> _items;
    private IPaymentStrategy _paymentStrategy;

    public ShoppingCart()
    {
        _items = new List<string>();
    }

    public void AddItem(string item)
    {
        _items.Add(item);
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout()
    {
        double amount = _items.Count * 20.0;
        _paymentStrategy.Pay(amount);
    }
}

