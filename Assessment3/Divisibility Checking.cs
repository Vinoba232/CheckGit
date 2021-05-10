using System;
using System.Collections.Generic;
namespace DivisibilityCheck
{
    class Program
    {                        
        List<int> TakeNumbersFromUser()
        {
            List<int> numbers = new List<int>();            
            for (int i = 0; i < 10; i++)
            {                
                numbers.Add(Convert.ToInt32(Console.ReadLine()));
            }                               
            return numbers;
        }

        void CheckingDivisibility()
        {
            
            List<int> myNumbers = TakeNumbersFromUser();            
            Console.WriteLine("The numbers divisible by 7 are ");
            foreach (var item in myNumbers)
            {
                if (item % 7 == 0)
                {
                    Console.WriteLine(item);
                }
            }                                                   
        }       
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 10 numbers... ");
            new Program().CheckingDivisibility();
           Console.ReadKey();
        }
    }
}

