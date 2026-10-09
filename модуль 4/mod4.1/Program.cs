using System;
//созданный интерфейс для геометрических фигур
interface IFigure
{
    double CalculateArea();
    double CalculatePerimeter();
}
class Circle : IFigure
{
    private double radius;
    public Circle(double r) { radius = r; }
    public double CalculateArea() => Math.PI * radius * radius;
    public double CalculatePerimeter() => 2 * Math.PI * radius;
}
class Rectangle : IFigure
{
    private double width, height;
    public Rectangle(double w, double h) { width = w; height = h; }
    public double CalculateArea() => width * height;
    public double CalculatePerimeter() => 2 * (width + height);
}
class Triangle : IFigure
{
    private double a, b, c;
    public Triangle(double sideA, double sideB, double sideC) { a = sideA; b = sideB; c = sideC; }
    public double CalculateArea()
    {
        double s = CalculatePerimeter() / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
    public double CalculatePerimeter() => a + b + c;
}
class Program
{
    static void Main()
    {
        IFigure[] figures = { new Circle(5), new Rectangle(4, 6), new Triangle(3, 4, 5) };
        foreach (var fig in figures)
        {
            Console.WriteLine($"Фигура: {fig.GetType().Name}");
            Console.WriteLine($"Площадь: {fig.CalculateArea():F2}");
            Console.WriteLine($"Периметр: {fig.CalculatePerimeter():F2}\n");
        }
    }
}
