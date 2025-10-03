using System;
using System.Collections.Generic;

namespace SRP
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Invoice
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public double TaxRate { get; set; }
    }

    public class InvoiceCalculator
    {
        public double CalculateTotal(Invoice invoice)
        {
            double subTotal = 0;
            foreach (var item in invoice.Items)
                subTotal += item.Price;

            return subTotal + (subTotal * invoice.TaxRate);
        }
    }

    public class InvoiceRepository
    {
        public void SaveToDatabase(Invoice invoice)
        {
            Console.WriteLine($"Счет №{invoice.Id} сохранен в базе данных.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ID счета: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Введите налоговую ставку (например 0,2): ");
            double tax = double.Parse(Console.ReadLine());

            var items = new List<Item>();
            Console.Write("Сколько товаров добавить? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите название товара {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Введите цену товара {i + 1}: ");
                double price = double.Parse(Console.ReadLine());

                items.Add(new Item { Name = name, Price = price });
            }

            var invoice = new Invoice { Id = id, TaxRate = tax, Items = items };
            var calculator = new InvoiceCalculator();
            var repo = new InvoiceRepository();

            double total = calculator.CalculateTotal(invoice);
            Console.WriteLine($"Итоговая сумма: {total}");
            repo.SaveToDatabase(invoice);
        }
    }
