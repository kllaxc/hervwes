using System;
class Program
{
    static void Main()
    {
        string[] cities = { "Минск", "Орша", "Витебск", "Браслав", "Глубокое" };
        Console.WriteLine("Список доступных городов: " + string.Join(", ", cities));
        Console.Write("Введите название города для поиска: ");
        string searchCity = Console.ReadLine();
        int index = Array.FindIndex(cities, c => c.Equals(searchCity, StringComparison.OrdinalIgnoreCase));
        if (index != -1)
        {
            Console.WriteLine($"Город найден! Его индекс в массиве: {index}");
        }
        else { Console.WriteLine(
        {
            Console.WriteLine("Такого города нет в массиве.");
        }
    }
}
