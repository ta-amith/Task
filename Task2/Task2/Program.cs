using System;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        static bool checkBinaryString(string binaryString)
        {
            int countOf0 = 0, Countof1 = 0;
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '0')
                {
                    countOf0++;
                }
                if (binaryString[i] == '1')
                {
                    Countof1++;
                }
            }

            // 1) Checking Number of 0 equals 1
            // 2) Checking number of 1 should not be less than the number of 0   

            if (Countof1>=countOf0)
            {
                return true;
            }

            return false;
        }


        static void Main(string[] args)
        {
            string binaryString = string.Empty;

            Console.WriteLine("Ener a binary string :  ");
            binaryString = Console.ReadLine();

            if (Regex.IsMatch(binaryString, "^[01]+$"))
            {
                if (checkBinaryString(binaryString))
                {
                    Console.WriteLine("Good binary string");
                }
                else
                {
                    Console.WriteLine("Not good binary string");
                }
            }
            else
            {
                
                Console.WriteLine("Given input is not binary string");
            }

            Console.ReadLine();
        }
    }
}
