using System;

class Program
{
    static void Main(string[] args)
    {
        // First Order
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LP1001", 800, 1));
        order1.AddProduct(new Product("Mouse", "MS2001", 25, 2));

        // Second Order
        Address address2 = new Address("456 Oak Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "SP3001", 600, 1));
        order2.AddProduct(new Product("Headphones", "HP4001", 80, 2));
        order2.AddProduct(new Product("Charger", "CH5001", 20, 3));

        // Display First Order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        // Display Second Order
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}
