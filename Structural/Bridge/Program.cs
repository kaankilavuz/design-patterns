IDrawingTool vectorTool = new VectorDrawingTool();
IDrawingTool rasterTool = new RasterDrawingTool();

Shape circle = new Circle(vectorTool);
Shape square = new Square(rasterTool);

circle.Draw();
square.Draw();


Console.ReadKey();


interface IDrawingTool
{
    void DrawShape(string shape);
}
class VectorDrawingTool : IDrawingTool
{
    public void DrawShape(string shape)
    {
        Console.WriteLine("Drawing " + shape + " using Vector Drawing Tool.");
    }
}
class RasterDrawingTool : IDrawingTool
{
    public void DrawShape(string shape)
    {
        Console.WriteLine("Drawing " + shape + " using Raster Drawing Tool.");
    }
}
abstract class Shape
{
    protected IDrawingTool drawingTool;

    protected Shape(IDrawingTool drawingTool)
    {
        this.drawingTool = drawingTool;
    }

    public abstract void Draw();
}
class Circle : Shape
{
    public Circle(IDrawingTool drawingTool) : base(drawingTool) { }

    public override void Draw()
    {
        drawingTool.DrawShape("Circle");
    }
}

class Square : Shape
{
    public Square(IDrawingTool drawingTool) : base(drawingTool) { }

    public override void Draw()
    {
        drawingTool.DrawShape("Square");
    }
}