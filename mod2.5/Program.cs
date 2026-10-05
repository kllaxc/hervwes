using System;
// Класс датчика температуры
class TemperatureSensor
{
    private int temperature;
    // Объявление события изменения температуры с использованием стандартного делегата EventHandler
    public event EventHandler<int> TemperatureChanged;
    // Свойство температуры с генерацией события при изменении значения
    public int Temperature
    {
        get { return temperature; }
        set
        {
            if (temperature != value)
            {
                temperature = value;
                // Вызов события при изменении температуры
                OnTemperatureChanged(temperature);
            }
        }
    }
    // Защищенный виртуальный метод вызова события
    protected virtual void OnTemperatureChanged(int currentTemperature)
    {
        TemperatureChanged?.Invoke(this, currentTemperature);
    }
}
// Класс термостата, управляющего отоплением
class Thermostat
{
    private int targetTemperature;
    // Конструктор термостата с заданной целевой температурой
    public Thermostat(int target)
    {
        targetTemperature = target;
    }
   // Метод-обработчик события изменения температуры
    public void OnTemperatureChanged(object sender, int currentTemperature)
    {
        Console.WriteLine($"[Термостат] Получено уведомление: текущая температура равна {currentTemperature}°C.");
        if (currentTemperature < targetTemperature)
        {
            Console.WriteLine("[Термостат] Отопление ВКЛЮЧЕНО.\n");
        }
        else
        {
            Console.WriteLine("[Термостат] Отопление ВЫКЛЮЧЕНО.\n");
        }
    }
}
class Program
{
    static void Main()
    {
        // Создание датчика температуры
        TemperatureSensor sensor = new TemperatureSensor();
        // Создание термостата с целевой температурой 22°C
        Thermostat thermostat = new Thermostat(22);
        // Подписка термостата на событие датчика
        sensor.TemperatureChanged += thermostat.OnTemperatureChanged;
        // Изменение температуры датчика (приводит к срабатыванию события)
        Console.WriteLine("Изменение температуры до 18°C:");
        sensor.Temperature = 18;
        Console.WriteLine("Изменение температуры до 24°C:");
        sensor.Temperature = 24;
    }
}
