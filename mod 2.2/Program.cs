using System;
abstract class Shape
{
    // Виртуальный метод для вычисления площади
    public abstract double Area();
    // Виртуальный метод для вычисления периметра
    public abstract double Perimeter();
}
// Производный класс Круг
class Circle : Shape
{
    private double radius;
    // Конструктор круга
    public Circle(double r)
    {
        radius = r;
    }
    // Переопределение метода вычисления площади круга
    public override double Area()
    {
        return Math.PI * radius * radius;
    }
    // Переопределение метода вычисления периметра (длины окружности)
    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}
// Производный класс Прямоугольник
class Rectangle : Shape
{
    private double width;
    private double height;
    // Конструктор прямоугольника
    public Rectangle(double w, double h)
    {
        width = w;
        height = h;
    }
    // Переопределение метода вычисления площади прямоугольника
    public override double Area()
    {
        return width * height;
    }
    // Переопределение метода вычисления периметра прямоугольника
    public override double Perimeter()
    {
        return 2 * (width + height);
    }
}
class Program
{
    static void Main()
    {
        // Создание массива фигур с использованием базового типа
        Shape[] shapes = new Shape[]
        {
            new Circle(5),
            new Rectangle(4, 64)
        };
        // Цикл по всем фигурам для вывода их характеристик
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Тип фигуры: {shape.GetType().Name}");
            Console.WriteLine($"Площадь: {shape.Area():F2}");
            Console.WriteLine($"Периметр: {shape.Perimeter():F2}");
            Console.WriteLine();
        }
    }
}