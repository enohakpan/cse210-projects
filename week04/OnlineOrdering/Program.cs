using System;

class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("34 Worgumati St", "Port Harcourt", "Rivers", "Nigeria");
        Address address2 = new Address("22 School Road", "Rumuekini", "Rivers", "Nigeria");

    
        Customer customer1 = new Customer("Akpan Enoh", address1);
        Customer customer2 = new Customer("Marie-Curie Edgeweblime", address2);

        Product product1 = new Product("Phone", "LPT123", 999.99, 1);
        Product product2 = new Product("Laptop", "MSE456", 19.99, 2);
        Product product3 = new Product("Sewing Machine", "KBD789", 49.99, 1);

        Product product4 = new Product("Blender", "MON101", 199.99, 1);
        Product product5 = new Product("Pot", "USB202", 9.99, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}