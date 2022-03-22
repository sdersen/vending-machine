class Inventory
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Id { get; set; }
    public int AmountInStock { get; set; }

    public Inventory(string name, int price, int id, int amountInStock)
    {
        Name = name;
        Price = price;
        Id = id;
        AmountInStock = amountInStock;
    }

}
