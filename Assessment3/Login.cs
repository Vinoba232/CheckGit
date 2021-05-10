using System;

namespace LoginPage
{
    class Program
    {
        string username, password;
        public void GettingUsernameAndPassword()
        {           
                Console.WriteLine("Please enter the username");
                username = Console.ReadLine();
                Console.WriteLine("Please enter the password");
                password = Console.ReadLine();       
                
        }
        void Checking()
        {
            string myUsername = "Admin";
            string myPassword = "admin";
            int count = 1;
            do
            {
                GettingUsernameAndPassword();
                if(username==myUsername && password == myPassword)
                {
                    Console.WriteLine("Welcome!!!");
                    break;
                }
                else
                {
                    if (count == 3)
                    {
                        Console.WriteLine("Sorry..You have already tried 3 times.");
                        break;
                    }
                    Console.WriteLine("Invalid Username or Password...\nTry Again ");
                    count++;                   
                }
            } while (count<=3);
            
        }
        static void Main(string[] args)
        {
            new Program().Checking();
        }
    }
}
