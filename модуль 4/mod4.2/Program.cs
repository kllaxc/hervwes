using System;
//созданный интерфейс товара
interface IProduct
{
    string GetName();
    decimal GetTotalPrice();
    int GetStockRemaining();
}
class WeightedProduct : IProduct
{
    private string name;
    private decimal pricePerKg;
    private double weightKg;
    public WeightedProduct(string name, decimal price, double weight) { this.name = name; pricePerKg = price; weightKg = weight; }
    public string GetName() => name;
    public decimal GetTotalPrice() => (decimal)weightKg * pricePerKg;
    public int GetStockRemaining() => (int)weightKg;
}
class UnitProduct : IProduct
{
    private string name;
    private decimal unitPrice;
    private int quantity;
    public UnitProduct(string name, decimal price, int qty) { this.name = name; unitPrice = price; quantity = qty; }
    public string GetName() => name;
    public decimal GetTotalPrice() => quantity * unitPrice;
    public int GetStockRemaining() => quantity;
}
class Program
{
    static void Main()
    {
        IProduct[] inventory = { new UnitProduct("Смартфон", 500m, 10), new WeightedProduct("Яблоки", 2.5m, 45.5) };
        foreach (var item in inventory)
        {
            Console.WriteLine($"Товар: {item.GetName()}, Остаток: {item.GetStockRemaining()}, Стоимость: {item.GetTotalPrice():C}");
        }
    }
}