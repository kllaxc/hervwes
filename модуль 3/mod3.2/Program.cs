using System;
// Класс уведомлений, управляющий событиями мобильного приложения
class NotificationSystem
{
    // События для разных типов уведомлений
    public event EventHandler<string> MessageReceived;
    public event EventHandler<string> CallIncoming;
    public event EventHandler<string> EmailReceived;
    // Методы для генерации (вызова) событий
    public void TriggerMessage(string message)
    {
        MessageReceived?.Invoke(this, message);
    }
    public void TriggerCall(string caller)
    {
        CallIncoming?.Invoke(this, caller);
    }
    public void TriggerEmail(string subject)
    {
        EmailReceived?.Invoke(this, subject);
    }
}
class Program
{
    // Обработчик для текстовых сообщений
    static void OnMessageReceived(object sender, string message)
    {
        Console.WriteLine($"[SMS] Новое сообщение: \"{message}\"");
    }
    // Обработчик для входящих вызовов
    static void OnCallIncoming(object sender, string caller)
    {
        Console.WriteLine($"[Звонок] Входящий вызов от абонента: {caller}");
    }
    // Обработчик для электронной почты
    static void OnEmailReceived(object sender, string subject)
    {
        Console.WriteLine($"[Email] Получено письмо с темой: \"{subject}\"");
    }
    static void Main()
    {
        // Создание системы уведомлений
        NotificationSystem notifications = new NotificationSystem();
        // Регистрация обработчиков событий (подписка)
        notifications.MessageReceived += OnMessageReceived;
        notifications.CallIncoming += OnCallIncoming;
        notifications.EmailReceived += OnEmailReceived;
        // Имитация возникновения событий в приложении
        Console.WriteLine("Симуляция работы мобильного приложения:\n");
        notifications.TriggerMessage("Привет! Как дела?");
        notifications.TriggerCall("Милана (куратор)");
        notifications.TriggerEmail("Важное обновление системы безопасности");
    }
}