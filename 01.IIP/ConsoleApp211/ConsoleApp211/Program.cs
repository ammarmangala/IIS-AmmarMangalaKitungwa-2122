using System;

namespace ConsoleApp211
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jaar invoeren : ");
            int Jaar = int.Parse(Console.ReadLine());
            if (((Jaar % 4 == 0) && (Jaar % 100 != 0)) || (Jaar % 400 == 0))
            {
                Console.WriteLine("{0} is een schrikkeljaar.", Jaar);
            }
            else 
            { 
                Console.WriteLine("{0} is geen schrikkeljaar.", Jaar);
            }
        }
    }
}
