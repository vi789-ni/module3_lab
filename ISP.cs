using System;

namespace ISP
{
    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public interface ISleepable
    {
        void Sleep();
    }

    public class HumanWorker : IWorkable, IEatable, ISleepable
    {
        public void Work() => Console.WriteLine("Человек работает");
        public void Eat() => Console.WriteLine("Человек ест");
        public void Sleep() => Console.WriteLine("Человек спит");
    }

    public class RobotWorker : IWorkable
    {
        public void Work() => Console.WriteLine("Робот работает");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите тип работника (human/robot): ");
            string type = Console.ReadLine().ToLower();

            if (type == "human")
            {
                var human = new HumanWorker();
                human.Work();
                human.Eat();
                human.Sleep();
            }
            else if (type == "robot")
            {
                var robot = new RobotWorker();
                robot.Work();
            }
            else
            {
                Console.WriteLine("Неизвестный тип работника");
            }
        }
    }
}
