

IPizzaBuilder margheritaPizzaBuilder = new MargheritaPizzaBuilder();
PizzaDirector director = new PizzaDirector(margheritaPizzaBuilder);

director.MakePizza();
Pizza pizza = margheritaPizzaBuilder.GetPizza();

Console.WriteLine(pizza);

Console.ReadKey();


class Pizza
{
    public string Dough { get; set; } = string.Empty;
    public string Sauce { get; set; } = string.Empty;
    public string Topping { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Pizza with {Dough} dough, {Sauce} sauce, and {Topping} topping.";
    }
}


interface IPizzaBuilder
{
    void BuildDough();
    void BuildSauce();
    void BuildTopping();
    Pizza GetPizza();
}


class MargheritaPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void BuildDough()
    {
        _pizza.Dough = "Thin crust";
    }

    public void BuildSauce()
    {
        _pizza.Sauce = "Tomato";
    }

    public void BuildTopping()
    {
        _pizza.Topping = "Mozzarella cheese";
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}

class PizzaDirector
{
    private readonly IPizzaBuilder _pizzaBuilder;

    public PizzaDirector(IPizzaBuilder pizzaBuilder)
    {
        _pizzaBuilder = pizzaBuilder;
    }

    public void MakePizza()
    {
        _pizzaBuilder.BuildDough();
        _pizzaBuilder.BuildSauce();
        _pizzaBuilder.BuildTopping();
    }
}

