using System;
using System.Collections.Generic;
class Program
{
    // Метод фильтрации списка с использованием делегата-предиката
    static List<string> FilterData(List<string> source, Predicate<string> filterCondition)
    {
        List<string> filteredList = new List<string>();
        foreach (string item in source)
        {
            if (filterCondition(item))
            {
                filteredList.Add(item);
            }
        }
        return filteredList;
    }
    static void Main()
    {
        // Исходный список данных
        List<string> tasks = new List<string>
        {
            "Купить продукты на неделю",
            "Срочно отправить отчет по проекту",
            "Позвонить заказчику",
            "Проверить почтовый ящик",
            "Срочно исправить баг в коде"
        };
        Console.WriteLine("Полный список задач:");
        foreach (var task in tasks) Console.WriteLine($"- {task}");
        Console.WriteLine();
        // Использование делегата для фильтрации по ключевому слову "Срочно"
        Predicate<string> keywordFilter = s => s.Contains("Срочно", StringComparison.OrdinalIgnoreCase);
        List<string> urgentTasks = FilterData(tasks, keywordFilter);
        Console.WriteLine("Отфильтрованные задачи (содержат слово 'Срочно'):");
        foreach (var task in urgentTasks) Console.WriteLine($"- {task}");
        Console.WriteLine();
        // Использование делегата для фильтрации по длине строки (больше 25 символов)
        Predicate<string> lengthFilter = s => s.Length > 25;
        List<string> longTasks = FilterData(tasks, lengthFilter);
        Console.WriteLine("Отфильтрованные задачи (длина строки > 25 символов):");
        foreach (var task in longTasks) Console.WriteLine($"- {task}");
    }
}