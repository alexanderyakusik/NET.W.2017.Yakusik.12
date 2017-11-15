namespace Timer.Example
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var worker = new Worker();
            var manager = new Manager();

            Console.WriteLine("Creating timer with 2 seconds expiration time...\n");
            var timer = new Timer(2000);

            worker.Subscribe(timer);
            manager.Subscribe(timer);

            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Starting timer...\n");
            
            timer.Start();

            Console.ReadLine();
        }
    }
}
