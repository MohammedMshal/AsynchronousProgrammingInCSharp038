namespace TaskDelay06
{
    class Program
    {
        static void Main(string[] args)
        {
            DelayTask(5000);
            Console.ReadKey();
        }

        static void DelayTask(int ml)
        {
            Task.Delay(ml).GetAwaiter().OnCompleted(() => Console.WriteLine($"After Delay Task {ml} Mili OnComplited"));
            Console.WriteLine($"After Delay Task {ml} Mili");


        }

        static void SleepThread(int ml)
        {
            Thread.Sleep(ml);
            Task.Delay(ml);
            Console.WriteLine($"After Thread Sleep {ml} Mili");
        }
    }

    
}