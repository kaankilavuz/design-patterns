ShapeFactory shapeFactory = new ShapeFactory();
string[] colors = { "Red", "Green", "Blue", "White", "Black" };

for (int i = 0; i < 20; i++)
{
    Circle circle = (Circle)shapeFactory.GetCircle(GetRandomColor());
    circle.Draw(GetRandomX(), GetRandomY());
}


Console.ReadKey();


string GetRandomColor()
{
    Random random = new Random();
    return colors[random.Next(colors.Length)];
}

int GetRandomX()
{
    Random random = new Random();
    return random.Next(100);
}

int GetRandomY()
{
    Random random = new Random();
    return random.Next(100);
}

interface IShape
{
    void Draw(int x, int y);
}

class Circle : IShape
{
    private string _color;
    private int _radius;

    public Circle(string color)
    {
        _color = color;
        _radius = 5;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing Circle [Color: {_color}, Radius: {_radius}, X: {x}, Y: {y}]");
    }
}

class ShapeFactory
{
    private Dictionary<string, IShape> _circleMap = new Dictionary<string, IShape>();

    public IShape GetCircle(string color)
    {
        if (!_circleMap.ContainsKey(color))
        {
            _circleMap[color] = new Circle(color);
            Console.WriteLine($"Creating circle of color : {color}");
        }
        return _circleMap[color];
    }
}

