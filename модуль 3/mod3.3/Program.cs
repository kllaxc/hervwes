using System;
// Объявление делегата для выполнения задачи
delegate void TaskActionDelegate(string taskName);
// Класс задачи
class TaskItem
{
    public string Title { get; set; }
    public TaskActionDelegate Action { get; set; }
    public TaskItem(string title, TaskActionDelegate action)
    {
        Title = title;
        Action = action;
    }
    // Выполнение назначенной для задачи функции
    public void Execute()
    {
        Console.WriteLine($"Выполнение задачи: \"{Title}\"");
        Action?.Invoke(Title);
        Console.WriteLine();
    }
}
class Program
{
    // Метод для действия: отправка уведомления
    static void SendNotification(string taskName)
    {
        Console.WriteLine($"  -> [Уведомление] Задача \"{taskName}\" требует вашего внимания.");
    }
    // Метод для действия: запись в журнал
    static void WriteToLog(string taskName)
    {
        Console.WriteLine($"  -> [Журнал] Произведена запись о выполнении задачи: \"{taskName}\".");
    }
    static void Main()
    {
        // Создание задач с выбором различных делегатов выполнения
        TaskItem task1 = new TaskItem("Сделать резервную копию базы данных", WriteToLog);
        TaskItem task2 = new TaskItem("Проверить почту от клиента", SendNotification);
        // Запуск выполнения задач
        task1.Execute();
        task2.Execute();
    }
}
