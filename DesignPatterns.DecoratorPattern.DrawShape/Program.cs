using System.Drawing;

Console.WriteLine("Circle");
Circle circle = new Circle();
circle.Draw(new Size(5, 10), 100);

Console.WriteLine("CircleEdgeColorized");
ColorizedBorderDecorator colorizedBorderDecorator = new ColorizedBorderDecorator(circle);
colorizedBorderDecorator.Draw(new Size(2,3), 100);

Console.WriteLine("CircleInsideColorized");
ColorizedInsideDecorator colorizedInsideDecorator = new ColorizedInsideDecorator(circle);
colorizedInsideDecorator.Draw(new Size(2, 3), 100);

Console.WriteLine("CircleBothColorized");
ColorizedBothInsideAndBorderDecorator colorizedBothInsideAndBorderDecorator = new ColorizedBothInsideAndBorderDecorator(circle);
colorizedBothInsideAndBorderDecorator.Draw(new Size(2, 3), 100);

/*
Sadece dairenin kenarları renklendirilebilsin,
Sadece daireyi içi renklendirilebilsin,
Yanları ve iç kısmı aynı anda renklendirilebilsin.
 */

// Component
interface IShape
{
    void Draw(Size size, int location);
}

//Concerete Component
class Circle : IShape
{
    public void Draw(Size size, int location)
    {
        Console.WriteLine("Daire çiziliyor.");
    }
}
//Decorator
class Decorator : IShape
{
    readonly IShape _shape;

    public Decorator(IShape shape)
    {
        _shape = shape;
    }

    virtual public void Draw(Size size, int location)
    {
        _shape.Draw(size, location);
    }

}
//ConcreteDecorator
class ColorizedBorderDecorator : Decorator
{
    readonly IShape _shape;

    public ColorizedBorderDecorator(IShape shape) : base(shape)
    {
        _shape = shape;
    }

    public override void Draw(Size size, int location)
    {
        base.Draw(size, location);
        Console.WriteLine("Dairenin kenarları renklendirildi.");
    }
}
//ConcreteDecorator
class ColorizedInsideDecorator : Decorator
{
    readonly IShape _shape;

    public ColorizedInsideDecorator(IShape shape) : base(shape)
    {
        _shape
    }

    public override void Draw(Size size, int location)
    {
        base.Draw(size, location);
        Console.WriteLine("Dairenin içerisi renklendirildi");
    }
}
//ConcreteDecorator
class ColorizedBothInsideAndBorderDecorator : Decorator
{
    readonly IShape _shape;

    public ColorizedBothInsideAndBorderDecorator(IShape shape) : base(shape)
    {
        _shape = shape;
    }

    public override void Draw(Size size, int location)
    {
        base.Draw(size, location);
        Console.WriteLine("Dairenin hem içi hem de dışı renklendirildi.");
    }
}