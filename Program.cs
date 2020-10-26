using System;

namespace Inl.uppgift.version1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool socialSecurityValid = false;

            while (socialSecurityValid != true)
            {
                Console.WriteLine("Write your social security number with 12 numbers: ");
                string userInput = Console.ReadLine();
                int numCharacter = userInput.Length;

                if (numCharacter == 12)
                {
                    socialSecurityValid = true;
                }
            }

        }
    }
}
