namespace ConcurrencyAndParallelism12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var things = new List<DailyDuty>
            {
                new("Cleaning House"),
                new("Washing Dishes"),
                new("Doing Laundry"),
                new("Preparing Meals"),
                new("Checking Emails"),
                new("Cleaning House")
            };

            //Console.WriteLine("Using Parallel Processing");
            //await ProcessThingsInParallel(things);

            Console.WriteLine("Using Concurrent Processing");
            await ProcessThingsInConcurrent(things);

            Console.ReadKey();
        }

        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(things, thing => thing.Process());
            return Task.CompletedTask;
        }

        static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }
            return Task.CompletedTask;
        }
    }

    class DailyDuty
    {
        public string title { get; private set; }

        public bool Processed { get; private set; }

        public DailyDuty(string title)
        {
            this.title = title;
        }

        public void Process()
        {
            Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}," +
                $"ProcessorId: {Thread.GetCurrentProcessorId()}");
            Task.Delay(100).Wait();
            this.Processed = true;
        }
    }
}