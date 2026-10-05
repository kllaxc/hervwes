using System;
using System.Collections.Generic;
// Класс автора
class Author
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthYear { get; set; }

    public Author(string firstName, string lastName, int birthYear)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthYear = birthYear;
    }
        public override string ToString()
    {
        return $"{FirstName} {LastName} (род. {BirthYear})";
    }
}
// Класс книги, использующий класс Author
class Book
{
    public string Title { get; set; }
    public Author BookAuthor { get; set; }
    public int PublicationYear { get; set; }
    public Book(string title, Author author, int year)
    {
        Title = title;
        BookAuthor = author;
        PublicationYear = year;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Книга: \"{Title}\", Год издания: {PublicationYear}");
        Console.WriteLine($"  Автор: {BookAuthor}");
    }
}
// Класс библиотеки, управляющий списком книг
class Library
{
    private List<Book> books = new List<Book>();
    // Метод добавления книги в библиотеку
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Добавлена книга: \"{book.Title}\"");
    }
    // Метод удаления книги из библиотеки
    public void RemoveBook(Book book)
    {
        books.Remove(book);
        Console.WriteLine($"Удалена книга: \"{book.Title}\"");
    }
    // Метод поиска книг по автору (по фамилии)
    public List<Book> FindBooksByAuthor(string authorLastName)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in books)
        {
            if (book.BookAuthor.LastName.Equals(authorLastName, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
    // Метод поиска книг по году издания
    public List<Book> FindBooksByYear(int year)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in books)
        {
            if (book.PublicationYear == year)
            {
                result.Add(book);
            }
        }
        return result;
    }
    // Вывод всех книг в библиотеке
    public void DisplayAllBooks()
    {
        Console.WriteLine("\n--- Список всех книг в библиотеке ---");
        if (books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
            return;
        }

        foreach (Book book in books)
        {
            book.DisplayInfo();
            Console.WriteLine();
        }
    }
}
class Program
{
    static void Main()
    {
        // Создание объектов авторов
        Author author1 = new Author("Александр", "Пушкин", 1799);
        Author author2 = new Author("Михаил", "Лермонтов", 1814);
        // Создание объектов книг
        Book book1 = new Book("Евгений Онегин", author1, 1833);
        Book book2 = new Book("Капитанская дочка", author1, 1836);
        Book book3 = new Book("Герой нашего времени", author2, 1840);
        // Создание объекта библиотеки
        Library library = new Library();
        // Тестирование добавления книг
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        // Вывод всех книг
        library.DisplayAllBooks();
        // Тестирование поиска по автору
        Console.WriteLine("Результаты поиска книг автора Пушкин:");
        List<Book> searchByAuthor = library.FindBooksByAuthor("Пушкин");
        foreach (Book b in searchByAuthor)
        {
            Console.WriteLine($"- \"{b.Title}\" ({b.PublicationYear})");
        }
        // Тестирование поиска по году издания
        Console.WriteLine("\nРезультаты поиска книг за 1836 год:");
        List<Book> searchByYear = library.FindBooksByYear(1836);
        foreach (Book b in searchByYear)
        {
            Console.WriteLine($"- \"{b.Title}\"");
        }
        // Тестирование удаления книги
        Console.WriteLine();
        library.RemoveBook(book3);
        library.DisplayAllBooks();
    }
}