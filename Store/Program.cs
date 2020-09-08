using System;
using Store.Entities;
using Store.Entities.Enums;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client Data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Client NewClient = new Client(name, email, date);

            Console.WriteLine("Enter Order Data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Order order = new Order(status, DateTime.Now, NewClient);

            Console.Write("How many itens to this order");
            int QItens = int.Parse(Console.ReadLine());
            

            for (int i = 1; i <= QItens; i++) {
                Console.Write("Product Name: ");
                string Pname = Console.ReadLine();
                Console.Write("Product price: ");
                double Pprice = double.Parse(Console.ReadLine());

                Product product = new Product(Pname, Pprice);

                Console.Write("Quantity: ");
                int qtd = int.Parse(Console.ReadLine());

                OrderItem Item = new OrderItem(qtd, Pprice, product);

                order.AddItem(Item);
            }

            Console.WriteLine("ORDER SUMARY: ");
            Console.WriteLine(order);

        }
    }
}
