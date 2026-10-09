using System;
// Объявление делегата для вычисления площади
delegate double CalculateAreaDelegate();
// Базовый класс геометрической фигуры
abstract class Shape
{
    public abstract double Area();
}
// Производный класс Круг
class Circle : Shape
{
    private double radius;
    public Circle(double r)
    {
        radius = r;
    }
    public override double Area()
    {
        return Math.PI * radius * radius;
    }
}
// Производный класс Прямоугольник
class Rectangle : Shape
{
    private double width;
    private double height;
    public Rectangle(double w, double h)
    {
        width = w;
        height = h;
    }
    public override double Area()
    {
        return width * height;
    }
}
// Производный класс Треугольник
class Triangle : Shape
{
    private double baseSide;
    private double height;
    public Triangle(double b, double h)
    {
        baseSide = b;
        height = h;
    }
    public override double Area()
    {
        return 0.5 * baseSide * height;
    }
}
class Program
{
    static void Main()
    {
        // Создание объектов различных фигур
        Shape circle = new Circle(5.0);
        Shape rectangle = new Rectangle(4.0, 6.0);
        Shape triangle = new Triangle(3.0, 8.0);
        // Использование делегата для динамического вызова метода Area
        CalculateAreaDelegate areaDelegate;
        // Вычисление площади круга через делегат
        areaDelegate = circle.Area;
        Console.WriteLine($"Площадь круга: {areaDelegate():F2}");
        // Вычисление площади прямоугольника через делегат
        areaDelegate = rectangle.Area;
        Console.WriteLine($"Площадь прямоугольника: {areaDelegate():F2}");
        // Вычисление площади треугольника через делегат
        areaDelegate = triangle.Area;
        Console.WriteLine($"Площадь треугольника: {areaDelegate():F2}");
    }
}