using System;
// Класс автора
class Author
{
    public string Name { get; set; }
    public int BirthYear { get; set; }
    // Конструктор автора
    public Author(string name, int birthYear)
    {
        Name = name;
        BirthYear = birthYear;
    }
    // Метод вывода информации об авторе
    public void DisplayInfo()
    {
        Console.WriteLine($"Автор: {Name} (год рождения: {BirthYear})");
    }
}
// Класс книги, использующий композицию с классом Author
class Book
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public Author BookAuthor { get; set; } // Ссылка на объект Author
    // Конструктор книги
    public Book(string title, int releaseYear, Author author)
    {
        Title = title;
        ReleaseYear = releaseYear;
        BookAuthor = author;
    }
    // Метод вывода полной информации о книге и ее авторе
    public void DisplayInfo()
    {
        Console.WriteLine($"Книга: \"{Title}\", Год выпуска: {ReleaseYear}");
        BookAuthor.DisplayInfo();
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        // Создание объектов авторов
        Author author1 = new Author("Лев Толстой", 1828);
        Author author2 = new Author("Фёдор Достоевский", 1821);
        Book book1 = new Book("Война и мир", 1869, author1);
        Book book2 = new Book("Преступление и наказание", 1866, author2);
        // Вывод информации о книгах
        book1.DisplayInfo();
        book2.DisplayInfo();
    }
}