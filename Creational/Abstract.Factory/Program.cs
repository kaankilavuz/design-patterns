IGUIFactory factory;
string os = "mac";

switch (os)
{
    case "mac":
        factory = new MacFactory();
        break;
    case "windows":
        factory = new WindowsFactory();
        break;
    default:
        throw new ArgumentException("Unknown OS type.");
}

Application app = new Application(factory);
app.Paint();

Console.ReadKey();

interface IButton
{
    void Paint();
}

interface ICheckbox
{
    void Paint();
}


class WindowsButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Windows button");
    }
}

class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Mac button");
    }
}

class WindowsCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Windows checkbox");
    }
}

class MacCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Mac checkbox");
    }
}

interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

class WindowsFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

class Application
{
    private readonly IButton _button;
    private readonly ICheckbox _checkbox;

    public Application(IGUIFactory factory)
    {
        _button = factory.CreateButton();
        _checkbox = factory.CreateCheckbox();
    }

    public void Paint()
    {
        _button.Paint();
        _checkbox.Paint();
    }
}




