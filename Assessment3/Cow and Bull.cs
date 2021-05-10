using System;
using System.Collections.Generic;

namespace CowAndBull
{
    class Program
    {
        string guess;
        int cow , bull ;
        List<string> words()
        {
            List<string> word = new List<string>();
            word.Add("kite");
            word.Add("four");
            word.Add("neat");
            word.Add("play");
            word.Add("goal");
            return word;
        }
        void GettingWord()
        {
            Console.WriteLine("Enter the guess...");
            guess = Console.ReadLine();
            guess.ToLower();
        }
        void checking(string item)
        {
            cow = 0;
            bull = 0;
            GettingWord();

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == item[i])
                {
                    cow = cow + 1;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (guess[i] == item[j])
                    {
                        if (guess[i] != item[i])
                        {
                            bull = bull + 1;
                        }
                    }
                }
            }
            Console.WriteLine("Cow = " + cow);
            Console.WriteLine("Bull = " + bull);

        }
        void Result()
        {
            
            List<string> myWords = words();           
            foreach (var item in myWords)
            {
                do
                {
                    checking(item);
                } while (guess != item);
                
                if (guess == item)
                {
                    Console.WriteLine("You Win!!!");
                    Console.WriteLine("Do you want to play again(Yes or No).");
                    string choice = Console.ReadLine();
                    choice.ToLower();
                    if (choice == "no")
                    {
                        break;
                    }
                }                
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Play...");
            new Program().Result();
        }
    }
}
