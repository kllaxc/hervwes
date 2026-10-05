using System;
// Интерфейс
interface IDrawable
{
    void Draw();
}
// Класс Круг
class Circle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Отрисовка фигуры: Круг.");
    }
}
// Класс Прямоугольник
class Rectangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Отрисовка фигуры: Прямоугольник.");
    }
}
// Класс Треугольник
class Triangle : IDrawable
{
    public void Draw()
    {
        Console.WriteLine("Отрисовка фигуры: Треугольник.");
    }
}
class Program
{
    static void Main()
    {
        // Создание массива объектов  IDrawable
        IDrawable[] drawables = new IDrawable[]
        {
            new Circle(),
            new Rectangle(),
            new Triangle()
        };
         // Вызов метода Draw 
        foreach (IDrawable item in drawables)
        {
            item.Draw();
        }
    }
}
