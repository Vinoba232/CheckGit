using System;
using System.Collections.Generic;

namespace SortingNumbers
{
    class Program
    {
        List<int> GettingNumbers()
        {
            int number;
            List<int> numbers = new List<int>();
            Console.WriteLine("Please enter Positive number. Enter 0 to quit");
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number>0)
                {
                    numbers.Add(number);
                }
                else if(number<0)
                {
                    Console.WriteLine("You have entered a negative number. Please enter a positive number.");
                }
            } while (number!=0);
            return numbers;
        }
        void SortingNumbers()
        {
            List<int> numbers = GettingNumbers();
            numbers.Sort();
            Console.WriteLine("The numbers after sorting....");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            new Program().SortingNumbers();
        }
    }
}
