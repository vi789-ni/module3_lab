using System;

namespace DIP
{
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Отправка Email: {message}");
        }
    }

    public class SmsService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }

    public class Notification
    {
        private readonly IMessageService _messageService;

        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Send(string message)
        {
            _messageService.SendMessage(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите способ уведомления (email/sms): ");
            string type = Console.ReadLine().ToLower();

            IMessageService service;
            if (type == "email")
                service = new EmailService();
            else if (type == "sms")
                service = new SmsService();
            else
            {
                Console.WriteLine("Неизвестный способ уведомления");
                return;
            }

            Console.Write("Введите сообщение: ");
            string message = Console.ReadLine();

            var notification = new Notification(service);
            notification.Send(message);
        }
    }
}


}
