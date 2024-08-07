namespace Refactoring.Examples;

file class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string ShippingAddress { get; set; }

    public void CalculateTotal(List<Product> products)
    {
        TotalAmount = products.Sum(p => p.Price);
    }

    public void SendConfirmationEmail()
    {
        // Code to send email
    }
}

file class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
