using System;
using Store.Entities.Enums;
using System.Text;
using System.Globalization;
using System.Collections.Generic;


namespace Store.Entities
{
    class Order
    {
        public OrderStatus Status { get; set; }
        public DateTime Moment { get; set; }

        public Client Client { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(OrderStatus status, DateTime moment, Client client)
        {
            Status = status;
            Moment = moment;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total() 
        {
            double sum = 0.0;
            foreach (OrderItem item in Items) 
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order Status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order Items: ");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total Price: " + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();

        }
    }
}
