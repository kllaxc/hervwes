using System;
//созданный интерфейс для холста
interface ICanvasDrawing
{
    void DrawLine(int x1, int y1, int x2, int y2);
    void DrawCircle(int x, int y, int radius);
    void DrawRectangle(int x, int y, int width, int height);
}
class ScreenCanvas : ICanvasDrawing
{
    public void DrawLine(int x1, int y1, int x2, int y2) => Console.WriteLine($"Линия ({x1},{y1})-({x2},{y2})");
    public void DrawCircle(int x, int y, int radius) => Console.WriteLine($"Круг в точке ({x},{y}), радиус {radius}");
    public void DrawRectangle(int x, int y, int width, int height) => Console.WriteLine($"Прямоугольник ({x},{y}), размер {width}x{height}");
}
class Program
{
    static void Main()
    {
        ICanvasDrawing canvas = new ScreenCanvas();
        canvas.DrawLine(0, 0, 10, 10);
        canvas.DrawCircle(5, 5, 3);
    }
}