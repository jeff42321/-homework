namespace 黑客松homework01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = Console.ReadLine();
            int nums = int.Parse(num);
            for(int i = 1; i <= nums; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("dann");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("School");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Build");
                }
                else
                {
                    Console.WriteLine(i);
                }

            }

        }
    }
}
