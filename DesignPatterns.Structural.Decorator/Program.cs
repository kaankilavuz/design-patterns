namespace DesignPatterns.Structural.Decorator;

class Program
{
    static void Main(string[] args)
    {

        ICoffe withMilk = new CoffeWithMilk(new SimpleCoffe());
        withMilk.GetDescription();


        ICoffe withSugar = new CoffeWithSugar(new SimpleCoffe());
        withSugar.GetCost();

        Console.ReadKey();
    }

    interface ICoffe
    {
        string GetDescription();
        int GetCost();
    }

    class SimpleCoffe : ICoffe
    {
        public int GetCost()
        {
            return 1;
        }

        public string GetDescription()
        {
            return "simple coffe";
        }
    }

    class CoffeWithMilk : ICoffe
    {
        readonly ICoffe _coffe;

        public CoffeWithMilk(ICoffe coffe)
        {
            _coffe = coffe;
        }
        public int GetCost()
        {
            return _coffe.GetCost() + 1;
        }

        public string GetDescription()
        {
            return _coffe.GetDescription() + " with milk";
        }
    }


    class CoffeWithSugar : ICoffe
    {
        readonly ICoffe _coffe;

        public CoffeWithSugar(ICoffe coffe)
        {
            _coffe = coffe;
        }

        public int GetCost()
        {
            return _coffe.GetCost() + 2;
        }

        public string GetDescription()
        {
            return _coffe.GetDescription() + " with sugar";
        }
    }

}
