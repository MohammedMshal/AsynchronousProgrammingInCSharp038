namespace AsyncFunction
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // -- 1 --
            //var task = Task.Run(() => ReadContent("https://www.youtube.com/c/Metigator"));
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));

            Console.WriteLine(await ReadContent("https://www.youtube.com/c/Metigator"));
            Console.WriteLine("test");
            Console.ReadKey();
        }

        static Task<string> ReadContent(string url)
        {
            HttpClient client = new();

            var task = client.GetStringAsync(url);

            return task;
        }

        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();

            var content = await client.GetStringAsync(url);

            return content;
        }
    }
}