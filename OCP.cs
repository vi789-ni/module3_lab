using System;

namespace OCP
{
    public interface IDiscount
    {
        double ApplyDiscount(double amount);
    }

    public class RegularDiscount : IDiscount
    {
        public double ApplyDiscount(double amount) => amount;
    }

    public class SilverDiscount : IDiscount
    {
        public double ApplyDiscount(double amount) => amount * 0.9;
    }

    public class GoldDiscount : IDiscount
    {
        public double ApplyDiscount(double amount) => amount * 0.8;
    }

    public class PlatinumDiscount : IDiscount
    {
        public double ApplyDiscount(double amount) => amount * 0.7;
    }

    public class DiscountCalculator
    {
        public double Calculate(IDiscount discount, double amount)
        {
            return discount.ApplyDiscount(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите сумму покупки: ");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Выберите тип клиента: Regular, Silver, Gold, Platinum");
            string type = Console.ReadLine();

            IDiscount discount;
            switch (type.ToLower())
            {
                case "regular": discount = new RegularDiscount(); break;
                case "silver": discount = new SilverDiscount(); break;
                case "gold": discount = new GoldDiscount(); break;
                case "platinum": discount = new PlatinumDiscount(); break;
                default:
                    Console.WriteLine("Неизвестный тип клиента");
                    return;
            }

            var calculator = new DiscountCalculator();
            Console.WriteLine($"Сумма со скидкой: {calculator.Calculate(discount, amount)}");
        }
    }
}
