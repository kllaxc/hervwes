using System;
// Класс с двумя переменными, конструкторами и деструктором
class SampleClass
{
    private int firstValue;
    private int secondValue;
    // Конструктор по умолчанию, задающий значения по умолчанию
    public SampleClass()
    {
        firstValue = 0;
        secondValue = 0;
        Console.WriteLine("[Конструктор] Вызван конструктор по умолчанию.");
    }
    // Конструктор с входными параметрами
    public SampleClass(int val1, int val2)
    {
        firstValue = val1;
        secondValue = val2;
        Console.WriteLine($"[Конструктор] Вызван конструктор с параметрами: {firstValue}, {secondValue}.");
    }
    // Метод вывода значений полей
    public void DisplayValues()
    {
        Console.WriteLine($"Значения полей: firstValue = {firstValue}, secondValue = {secondValue}");
    }
    // Деструктор класса
    ~SampleClass()
    {
        Console.WriteLine($"[Деструктор] Объект с полями ({firstValue}, {secondValue}) удален из памяти.");
    }
}
class Program
{
    static void Main()
    {
        // Блок кода для демонстрации работы деструктора
        {
            // Создание объектов с помощью разных конструкторов
            SampleClass obj1 = new SampleClass();
            obj1.DisplayValues();

            SampleClass obj2 = new SampleClass(15, 30);
            obj2.DisplayValues();
        }
        // Принудительный вызов сборщика мусора для демонстрации срабатывания деструкторов
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Завершение работы программы.");
    }
}