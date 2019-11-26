using System;
using System.Linq;

namespace Quadax
{
    class Program
    {
        static void Main(string[] args)
        {

            int WinCnt = 0;
            Random random = new Random();
            string DisplayCode;
            int[] CodeArray = new int[4];
            string[] GuessArray = new string[4];
            string result = "";

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    CodeArray[i] = random.Next(1, 7);
                    DisplayCode = (CodeArray[i]).ToString();
                    builder.Append(DisplayCode);
                }
            // Used for testing
            //Console.WriteLine("Secret Code. " + builder);

            for (int i = 0; i < 10; i++)
            {
                result = "";
                Console.WriteLine("");
                Console.WriteLine("Enter Guess (#:" + (i + 1) + ") a 4 Digit Number");
                string GuessInput = Console.ReadLine();
                
                // Here I need to test for more or less than 4 characters
                // They must be all numeric and between 1 and 6
               
                // All Integers
                int myInt;
                bool isNumerical = int.TryParse(GuessInput, out myInt);
                if (!isNumerical)
                {
                    Console.WriteLine("Invalid Entry (4 Numbers Only");
                    continue;
                }

                // Validate length of 4 characters
                int GuessLength;
                GuessLength = GuessInput.Length;
                if (GuessLength < 4 || GuessLength > 4)
                    {
                    Console.WriteLine("Invalid Entry (4 Digits Only)");
                    continue;
                }

                char[] charArr = GuessInput.ToCharArray();
                Console.WriteLine("Result Of Guess (#:" + (i + 1) + ")");
                Console.WriteLine("-----------------------------------");

                WinCnt =0;
                for (int x = 0; x < 4; x++)
                {
                   int charint = (int)char.GetNumericValue(charArr[x]);
                    //Validate Numbers entered
                    if ((charint < 1) || (charint > 6))
                    {
                        Console.WriteLine("Invalid Digit Must be between 1 and 6");
                    }

                    // Matches Value and Position
                    if (charint == CodeArray[x])
                    {
                        result = result + "  +" + charArr[x];
                        WinCnt++;
                    }
                    else   // Matches Value but wrong Position
                    {
                        if (CodeArray.Contains(charArr[x]))
                        {
                            result = result + "  -" + charArr[x];
                        }
                        else // No Match at all
                        {
                          result = result + "  " + charArr[x];
                        }
                    }
                }

                Console.WriteLine(result);
                Console.WriteLine("");

                if (WinCnt == 4)
                {
                    Console.WriteLine("Congratulations it's a Winner");
                    ExitEscKey();
                }
            }
            Console.WriteLine("You have exceeded the number of tries (10) ...");
            ExitEscKey();
        }

        static void ExitEscKey()
        {
            ConsoleKeyInfo k;
            bool bln = true;

            Console.WriteLine("Press ESC to exit...");
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    if (!bln)
                        Console.WriteLine("{0:s}", "x");
                    bln = true;
                }
                bln = false;
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Escape)
                    Environment.Exit(0);
            }
         }




    }
}
