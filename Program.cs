using System;
using System.Security.Cryptography.X509Certificates;

namespace Inl.uppgift.version1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool socialSecurityValid = false;

            //While loop until social security is valid
            while (socialSecurityValid != true)
            {
                //All the variables are being declared and converted from users input
                string userInput = AskForSocialSecurity();
                int numCharacters = userInput.Length;
                int year = int.Parse(userInput.Substring(0, 4));
                int month = int.Parse(userInput.Substring(4, 2));
                int day = int.Parse(userInput.Substring(6, 2));
                bool isLeapYear = CheckLeapYear(year);
                int birthNumber = int.Parse(userInput.Substring(8, 3));
                int gender = int.Parse(userInput.Substring(10, 1));

                //Run checks if the social security number is valid
                if (
                    CheckNumCharacters(numCharacters) && //checks number of characters
                    CheckYear(year) && //checks if the year is valid
                    CheckMonth(month) && // checks if the month is valid
                    CheckValidDay(day, month, isLeapYear) && // checks day, month, leapyear
                    CheckBirthNum(birthNumber) //checks the birthnumber
                    )
                {
                    //Check if gender is female or male
                    if (gender % 2 == 0)
                    {
                        Console.WriteLine("Juridiskt kön kvinna");
                    }
                    else
                    {
                        Console.WriteLine("Juridiskt kön man");
                    }

                    Console.WriteLine("Ditt personnummer är korrekt");
                    socialSecurityValid = true; //If the social security number is valid, we print the text and end the loop
                }
                else
                {
                    Console.WriteLine("Ditt personnummer är inte korrekt"); //If it is not valid this text is printed on the screen
                }
            }
            Console.ReadKey();

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
            //Method that checks if the year is between 1753 and 2020, otherwise invalid year
            return year >= 1753 && year <= 2020;
        }

        public static bool CheckMonth(int month)
        {
            //Method that checks if the month is between 1 and 12 otherwise invalid month
            return month >= 1 && month <= 12;
        }

        public static bool CheckLeapYear(int year)
        {
            //Method that checks if the year the user put in is a leap year
            if (year % 400 == 0)
            {
                return true;
            }
            else if (year % 100 == 0)
            {
                return false;
            }
            else if (year % 4 == 0)
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
            //Method that checks if the birth number is between 000 and 999
            return birthNumber >= 000 && birthNumber <= 999;
        }
    }
}
