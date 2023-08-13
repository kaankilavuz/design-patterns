namespace DesignPatterns.Structural.Bridge;

class Program
{
    static void Main(string[] args)
    {
        IDrawImplementor penImplementor = new PenImplementor();
        IDrawImplementor brushImplementor = new BrushImplementor();

        Drawing redPenDrawing = new RedDrawing(penImplementor);
        Drawing blueBrushDrawing = new BlueDrawing(brushImplementor);

        redPenDrawing.Draw();
        blueBrushDrawing.Draw();

        Console.ReadKey();
    }

    interface IDrawImplementor
    {
        void Draw();
    }

    class PenImplementor : IDrawImplementor
    {
        public void Draw()
        {
            Console.WriteLine("drawing with a pen");
        }
    }

    class BrushImplementor : IDrawImplementor
    {
        public void Draw()
        {
            Console.WriteLine("drawing with a brush");
        }
    }

    abstract class Drawing
    {
        protected IDrawImplementor drawImplmentor;

        public Drawing(IDrawImplementor drawImplementor)
        {
            this.drawImplmentor = drawImplementor;
        }

        public abstract void Draw();
    }

    class RedDrawing : Drawing
    {
        public RedDrawing(IDrawImplementor drawImplementor) : base(drawImplementor)
        {

        }

        public override void Draw()
        {
            Console.WriteLine("Red");
            drawImplmentor.Draw();
        }
    }

    class BlueDrawing : Drawing
    {
        public BlueDrawing(IDrawImplementor drawImplementor) : base(drawImplementor)
        {

        }

        public override void Draw()
        {
            Console.WriteLine("Blue");
            drawImplmentor.Draw();
        }
    }
}
