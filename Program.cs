using System;
using System.Security.Cryptography.X509Certificates;

namespace Inl.uppgift.version1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool socialSecurityValid = false;

            //While loop until social security is true
            while (socialSecurityValid != true)
            {
                // 200003270162
                //All the variables are being declared and converted from users input
                string userInput = AskForSocialSecurity(); // 199302155958
                int numCharacters = userInput.Length; // 12
                int year = int.Parse(userInput.Substring(0, 4)); // 1993
                int month = int.Parse(userInput.Substring(4, 2)); // 2
                int day = int.Parse(userInput.Substring(6, 2)); // 15
                bool isLeapYear = CheckLeapYear(year); // false
                int birthNumber = int.Parse(userInput.Substring(8, 3)); //true birthNumber
                int gender = int.Parse(userInput.Substring(10, 1)); // male

                if (
                    CheckNumCharacters(numCharacters) && //checks number of characters
                    CheckYear(year) && //checks if the year is valid
                    CheckMonth(month) && // checks if the month is valid
                    CheckValidDay(day, month, isLeapYear) && // check day, month, leapyear
                    CheckBirthNum(birthNumber) && //checks the birthnumber
                    CheckGender(gender)
                    )
                {
                    Console.WriteLine("Ditt personnummer är korrekt");
                    socialSecurityValid = true; //If the social security number is valid the text is printed
                } else
                {
                    Console.WriteLine("Vi forlorade!"); //If it is not valid this text is printed on the screen
                    // Try again - felmeddelande
                }
            } Console.ReadKey();

        }

        public static string AskForSocialSecurity()
        {
            //Method asking user for their social security number
            Console.WriteLine("Write your social security number with 12 numbers: ");
            string userInput = Console.ReadLine();
            return userInput;
        }
        
        public static bool CheckNumCharacters(int number) 
        {
            //Method that checks if the user input contains 12 numbers
            return number == 12;
        }

        public static bool CheckYear(int year)
        {
            //Method that sets the year to be between 1753 and 2020, otherwise unvalid year
            return year >= 1753 && year <= 2020;
        }

        public static bool CheckMonth(int month)
        {
            //Method that sets the month to be inbetween 1 and 12 otherwise unvalid month
            return month >= 1 && month <= 12;
        }

        public static bool CheckLeapYear(int year)
        {
            //Method that checks if the year the user put in is a leap year
            if(year % 400 == 0)
            {
                return true;
            }
            else if(year % 100 == 0)
            {
                return false;
            }
            else if(year % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool CheckValidDay(int day, int month, bool leapYear)
        {
            int daysInFebruary = 28;
            //Sets february to have 29 days on leapyear
            if (leapYear)
            {
                daysInFebruary = 29;
            }

            //Check the days in each month
            switch (month)
            {
               
                case 1:
                    return day >= 1 && day <= 31;
                case 2:
                    return day >= 1 && day <= daysInFebruary;
                case 3:
                    return day >= 1 && day <= 31;
                case 4:
                    return day >= 1 && day <= 30;
                case 5:
                    return day >= 1 && day <= 31;
                case 6:
                    return day >= 1 && day <= 30;
                case 7:
                    return day >= 1 && day <= 31;
                case 8:
                    return day >= 1 && day <= 31;
                case 9:
                    return day >= 1 && day <= 30;
                case 10:
                    return day >= 1 && day <= 31;
                case 11:
                    return day >= 1 && day <= 30;
                case 12:
                    return day >= 1 && day <= 31;
                default:
                    return false;
            }
        }

        public static bool CheckBirthNum(int birthNumber)
        {
            //Method that sets the birth number between 000 and 999
            return birthNumber >= 000 && birthNumber <= 999;
        }

        public static bool CheckGender(int gender)
        {
            if(gender % 2 == 0)
            {
                Console.WriteLine("Juridiskt kön kvinna");
            }
            else
            {
                Console.WriteLine("Juridiskt kön man");
            }
            return true;
        }
    }
}
