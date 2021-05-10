using System;
using System.Collections.Generic;
using System.Linq;
namespace RepeatedNumbers
  
{
    class Program
    {
        List<int> GettingNumbers()
        {
            List<int> numbers = new List<int>();
            int number;
            Console.WriteLine("Please enter a number. Enter a negative number to quit");
            do
            {               
                number = Convert.ToInt32(Console.ReadLine());
                numbers.Add(number);
            } while (number>0);
            return numbers;
        }
        void PrintingRepeatedNumbers()
        {            
            List<int> numbers = GettingNumbers();
            List<int> repeated = new List<int>();
            var result = numbers.GroupBy(i => i);
            foreach (var i in result)
            {
                if (i.Count() > 1)
                {
                    repeated.Add(i.Key);
                    //Console.WriteLine(i.Key);
                }                
            }
            if (repeated.Count > 1)
            {
                Console.WriteLine("The Repeating numbers are");
                foreach (var item in repeated)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No number is repeated");
            }           
        }
        static void Main(string[] args)
        {
            new Program().PrintingRepeatedNumbers();            
        }
    }
}
