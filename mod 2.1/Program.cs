using System;
// Описание класса человека
class Person
{
    // Поля для хранения личных данных
    private string name;
    private int age;
    private string address;
    // Метод установки имени
    public void SetName(string personName)
    {
        name = personName;
    }
    // Метод получения имени
    public string GetName()
    {
        return name;
    }
    // Метод установки возраста
    public void SetAge(int personAge)
    {
        age = personAge;
    }
    // Метод получения возраста
    public int GetAge()
    {
        return age;
    }
    // Метод установки адреса
    public void SetAddress(string personAddress)
    {
        address = personAddress;
    }
    // Метод получения адреса
    public string GetAddress()
    {
        return address;
    }
    // Метод вывода информации о человеке
    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {name}, Возраст: {age}, Адрес: {address}");
    }
}
class Program
{
    static void Main()
    {
        // Создание первого объекта человека и заполнение его данных
        Person person1 = new Person();
        person1.SetName("Милана");
        person1.SetAge(17);
        person1.SetAddress("ул. Пушкина 9Б/1");
        // Создание второго объекта человека и заполнение его данных
        Person person2 = new Person();
        person2.SetName("Валерия");
        person2.SetAge(18);
        person2.SetAddress("ул. Пушкина 9Б/1");
        // Вывод информации об объектах на экран
        person1.DisplayInfo();
        person2.DisplayInfo();
    }
}
