
IGraphic button1 = new Button();
IGraphic button2 = new Button();
IGraphic textBox = new TextBox();

Panel panel = new Panel();
panel.Add(button1);
panel.Add(button2);
panel.Add(textBox);

panel.Render();

Console.ReadKey();


interface IGraphic
{
    void Render();
}
class Button : IGraphic
{
    public void Render()
    {
        Console.WriteLine("Rendering Button");
    }
}
class TextBox : IGraphic
{
    public void Render()
    {
        Console.WriteLine("Rendering TextBox");
    }
}

class Panel : IGraphic
{
    private readonly List<IGraphic> _children = new List<IGraphic>();

    public void Add(IGraphic graphic)
    {
        _children.Add(graphic);
    }

    public void Remove(IGraphic graphic)
    {
        _children.Remove(graphic);
    }

    public void Render()
    {
        Console.WriteLine("Rendering Panel");
        foreach (var child in _children)
        {
            child.Render();
        }
    }
}