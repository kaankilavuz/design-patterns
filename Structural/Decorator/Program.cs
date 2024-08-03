
Beverage beverage = new Espresso();
Console.WriteLine($"{beverage.Description} ${beverage.Cost()}");

Beverage beverage2 = new HouseBlend();
beverage2 = new Milk(beverage2);
beverage2 = new Sugar(beverage2);
Console.WriteLine($"{beverage2.Description} ${beverage2.Cost()}");

Beverage beverage3 = new Espresso();
beverage3 = new Sugar(beverage3);
Console.WriteLine($"{beverage3.Description} ${beverage3.Cost()}");


Console.ReadKey();


abstract class Beverage
{
    public virtual string Description { get; protected set; } = "Unknown Beverage";

    public abstract double Cost();
}

class Espresso : Beverage
{
    public Espresso()
    {
        Description = "Espresso";
    }

    public override double Cost()
    {
        return 1.99;
    }
}

class HouseBlend : Beverage
{
    public HouseBlend()
    {
        Description = "House Blend Coffee";
    }

    public override double Cost()
    {
        return 0.89;
    }
}

abstract class CondimentDecorator : Beverage
{
    protected Beverage Beverage;

    public CondimentDecorator(Beverage beverage)
    {
        Beverage = beverage;
    }

    public abstract override string Description { get; }
}

class Milk : CondimentDecorator
{
    public Milk(Beverage beverage) : base(beverage) { }

    public override string Description => Beverage.Description + ", Milk";

    public override double Cost()
    {
        return Beverage.Cost() + 0.10;
    }
}

class Sugar : CondimentDecorator
{
    public Sugar(Beverage beverage) : base(beverage) { }

    public override string Description => Beverage.Description + ", Sugar";

    public override double Cost()
    {
        return Beverage.Cost() + 0.15;
    }
}