using System;

namespace CardValidating
{
    class Program
    {
        string number;
        int[] cardNum = new int[16];
        string[] strArr = new string[16];
        int sum = 0;
       
        public void GettingCardNumber()
        {                       
            Console.WriteLine("Enter the card number");
            number =Console.ReadLine();
            for (int i = 0; i < 16; i++)
            {
                strArr[i] = Convert.ToString(number[i]);
            }
            cardNum = Array.ConvertAll(strArr, s => int.Parse(s));            
            Console.WriteLine("Original Number : " + string.Join(",", cardNum));
            reversing();
        }

        void reversing()
        {
            Array.Reverse(cardNum);            
            Console.WriteLine("Reversed Number : " + string.Join(",", cardNum));
            for (int i = 1; i < 16; i += 2)
            {
                if ((cardNum[i] * 2) > 9)
                {
                    cardNum[i] = (cardNum[i] * 2) - 9;
                }
                else
                {
                    cardNum[i] = cardNum[i] * 2;
                }                
            }
            Console.WriteLine("Multiple odd digits by 2 and Subtract 9 to numbers over 9 : " + string.Join(" +", cardNum));
            validating();
        }
        void validating()
        {
            for (int i = 0; i < 16; i++)
            {
                sum = sum + cardNum[i];
            }
            Console.WriteLine(sum);
            if (sum % 10 == 0)
            {
                Console.WriteLine("Card is Validated");
            }
            else
            {
                Console.WriteLine("Card is Invalid");
            }
        }
        static void Main(string[] args)
        {
            new Program().GettingCardNumber();
        }
    }
}
