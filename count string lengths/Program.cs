namespace count_string_lengths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入一個有意義的英文字串:");
            string input = Console.ReadLine();
            string[] item = input.Split(' ');
            var list = item.ToList();

            var count = list.Select(x => x.ToLower()).GroupBy(x => x).Select(x => new
            {
                Word = x.Key,
                Count = x.Count(),
            });
            foreach(var word in count)
            {
                Console.WriteLine($"{word.Word} : {word.Count}");
            }
        }
    }
}
