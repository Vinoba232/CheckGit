using System;

namespace PrimeNumbers
{
    class Program
    {        
        void PrimeNum(int min,int max)
        {
            int count = 0;        
            for (int i = min; i <= max; i++)
            {
                int flag = 1;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    Console.WriteLine(i);
                    count = 1;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Invalid Entry...");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            int min, max;
            Console.WriteLine("Enter the minimum Number: ");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the minimum Number: ");
            max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prime Numbers between " + min + " and " + max);

            program.PrimeNum(min,max);
        }
    }
}
