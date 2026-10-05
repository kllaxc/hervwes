using System;

// Описание класса сотрудника
class Employee
{
    private string name;
    private int age;
    private string position;
    private decimal monthlySalary;

    // Конструктор по умолчанию
    public Employee()
    {
        name = "Не указано";
        age = 18;
        position = "Стажер";
        monthlySalary = 0;
    }

    // Конструктор с параметрами
    public Employee(string empName, int empAge, string empPosition, decimal salary)
    {
        name = empName;
        age = empAge;
        position = empPosition;
        monthlySalary = salary;
    }

    // Методы установки и получения имени
    public void SetName(string empName) { name = empName; }
    public string GetName() { return name; }

    // Методы установки и получения возраста
    public void SetAge(int empAge) { age = empAge; }
    public int GetAge() { return age; }

    // Методы установки и получения должности
    public void SetPosition(string empPosition) { position = empPosition; }
    public string GetPosition() { return position; }

    // Методы установки и получения зарплаты
    public void SetSalary(decimal salary) { monthlySalary = salary; }
    public decimal GetSalary() { return monthlySalary; }

    // Метод расчета годового дохода
    public decimal CalculateAnnualIncome()
    {
        return monthlySalary * 12;
    }

    // Метод вывода информации о сотруднике
    public void DisplayInfo()
    {
        Console.WriteLine($"Сотрудник: {name}, Возраст: {age}, Должность: {position}");
        Console.WriteLine($"Месячная зарплата: {monthlySalary:C}, Годовой доход: {CalculateAnnualIncome():C}\n");
    }
}

class Program
{
    static void Main()
    {
        // Создание объекта для Миланы (техник-программист, высокая зарплата)
        Employee milana = new Employee("Кухальская Милана", 17, "Техник-программист", 50000000000m);

        // Создание объекта для Валерии (техник-программист, высокая зарплата)
        Employee valeria = new Employee("Стальмакова Валерия", 18, "Техник-программист", 50000000000m);

        // Тестирование функциональности и вывод данных
        milana.DisplayInfo();
        valeria.DisplayInfo();
    }
}