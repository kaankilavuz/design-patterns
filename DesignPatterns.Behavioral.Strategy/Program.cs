namespace DesignPatterns.Behavioral.Strategy;

class Program
{
    static void Main(string[] args)
    {
        ShoppingCart cart = new ShoppingCart();
        cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456", "12/25"));
        cart.Checkout(150.0);

        cart.SetPaymentStrategy(new PayPalPayment("example@example.com"));
        cart.Checkout(75.0);

        cart.SetPaymentStrategy(new BankTransferPayment("123456789"));
        cart.Checkout(200.0);

        Console.ReadKey();
    }

    interface IPaymentStrategy
    {
        void PaymentProcess(double amount);
    }

    class CreditCardPayment : IPaymentStrategy
    {
        private string cardNumber;
        private string expiryDate;

        public CreditCardPayment(string cardNumber, string expiryDate)
        {
            this.cardNumber = cardNumber;
            this.expiryDate = expiryDate;
        }

        public void PaymentProcess(double amount)
        {
            Console.WriteLine($"Paid {amount} with credit card {cardNumber}");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        private string email;

        public PayPalPayment(string email)
        {
            this.email = email;
        }

        public void PaymentProcess(double amount)
        {
            Console.WriteLine($"Paid {amount} with PayPal account {email}");
        }
    }

    public class BankTransferPayment : IPaymentStrategy
    {
        private string accountNumber;

        public BankTransferPayment(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        public void PaymentProcess(double amount)
        {
            Console.WriteLine($"Paid {amount} via bank transfer to account {accountNumber}");
        }
    }

    class ShoppingCart
    {
        private IPaymentStrategy paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            paymentStrategy = strategy;
        }

        public void Checkout(double totalAmount)
        {
            paymentStrategy.PaymentProcess(totalAmount);
        }
    }
}
