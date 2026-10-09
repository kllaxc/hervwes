using System;
//созданный интерфейс книги
interface ILibraryBook
{
    string GetTitle();
    bool IsAvailable();
    void IssueBook();
}
class FictionBook : ILibraryBook
{
    private string title;
    private bool available;
    public FictionBook(string title, bool isAvailable) { this.title = title; this.available = isAvailable; }
    public string GetTitle() => title;
    public bool IsAvailable() => available;
    public void IssueBook()
    {
        if (available) { available = false; Console.WriteLine($"Книга \"{title}\" выдана."); }
        else { Console.WriteLine($"Книга \"{title}\" недоступна."); }
    }
}
class Program
{
    static void Main()
    {
        ILibraryBook book = new FictionBook("Мастер и Маргарита", true);
        Console.WriteLine($"Книга: {book.GetTitle()}, Доступна: {book.IsAvailable()}");
        book.IssueBook();
    }
}