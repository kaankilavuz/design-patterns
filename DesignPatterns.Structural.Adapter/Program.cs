namespace DesignPatterns.Structural.Adapter;

class Program
{
    static void Main(string[] args)
    {
        ITarget requestAdaptor = new Adapter();
        requestAdaptor.Request();

        Console.ReadKey();
    }

    interface ITarget
    {
        void Request();
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Specific request");
        }
    }

    class Adapter : ITarget
    {
        readonly Adaptee adaptee;

        public Adapter()
        {
            adaptee = new Adaptee();    
        }

        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}
