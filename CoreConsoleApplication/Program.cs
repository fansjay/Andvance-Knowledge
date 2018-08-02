using System;

namespace CoreConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine($"{i}*{j}={i*j}");
                }
            }

            Console.ReadKey();
        }
    }
}
