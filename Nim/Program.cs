using System;
using System.Threading;

namespace Nim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            byte userMax = 3;  // The maximum amount the player/user is allowed to input
            int cpuTime = rnd.Next(512, 4096);  // Psudo-thinking time for the CPU, where the pauses are in between these two values
            byte matchCnt = 7;
            byte userIn = 0;
            byte turnCnt;
            byte matchUpd = 0;
            byte cpuRnd;
            string retryIn;

            Console.WriteLine("Welcome to NIM. Not to be confused with Nine Inch Nails (NIN)." +
           "\nIn this game you have 7 matches. You can pick 1 - 3 matches per turn,\nand the " +
           "goal is to pick up the last match before the opponent does!");

            do
            {
                for (turnCnt = 1; matchCnt > 0; turnCnt++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nRound number " + turnCnt + "!\n");
                    Console.ResetColor();
                    Console.WriteLine("How many do you want to pick up?");
                    while (true)
                    {
                        if (matchCnt > 3)  // Scales the pick-pool for the CPU to prevent picking more matches than available 
                        {
                            userMax = 3;
                        }
                        else if (matchCnt == 2)
                        {
                            userMax = 2;
                        }
                        else if (matchCnt == 1)
                        {
                            userMax = 1;
                        }
                        Console.Write("> "); // Player
                        if (!byte.TryParse(Console.ReadLine(), out userIn))
                        {
                            Console.WriteLine("You can't choose nothing.");
                        }
                        if (userIn <= userMax && userIn > 0)
                        {
                            break;
                        }
                        else
                        {
                            if (matchCnt > 3)
                            {
                                Console.WriteLine("Please enter a number from 1 - 3.");
                            }
                            else if (matchCnt == 2)
                            {
                                Console.WriteLine("Please enter a number from 1 - 2.");
                            }
                            else
                            {
                                Console.WriteLine("Please enter 1 to win.");
                            }
                        }
                    }
                    matchUpd = (byte)(matchCnt - userIn);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Matches -> " + matchUpd + " left.");
                    Console.ResetColor();
                    //Console.WriteLine("Matches -> " + matchUpd + " left.");
                    //Console.WriteLine("Match count = " + matchCnt + "\nMatch update = " + matchUpd);
                    if (matchUpd == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPLAYER WINS");
                        Console.ResetColor();
                        Console.Beep();
                        break;
                    }
                    Console.WriteLine(string.Empty);
                    if (matchCnt > matchUpd)  // CPU
                    {
                        matchCnt = matchUpd;
                        if (matchCnt > 3)  // Scales the pick-pool for the CPU to prevent picking more matches than available
                        {
                            cpuRnd = (byte)rnd.Next(1, 3);
                        }
                        else if (matchCnt == 2)
                        {
                            cpuRnd = (byte)rnd.Next(1, 2);
                        }
                        else
                        {
                            cpuRnd = 1;
                        }
                        Console.WriteLine("...\n");
                        Thread.Sleep(cpuTime);  // Adds pause for dramatic effect
                        Console.WriteLine("The opponent picked up " + cpuRnd + "!");
                        matchUpd = (byte)(matchCnt - cpuRnd);
                        //Console.WriteLine("CPU Matches -> " + matchUpd + " left.");
                        //Console.WriteLine("CPU Match count = " + matchCnt + "\nCPU Match update = " + matchUpd);
                        matchCnt = matchUpd;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Matches -> " + matchCnt + " left.");
                        Console.ResetColor();
                        if (matchCnt == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nCOMPUTER WINS");
                            Console.ResetColor();
                            Console.Beep();
                            break;
                        }
                    }
                }
                Console.WriteLine("\nWould you like to play again? Type \"Y\" " +
                             "to start over,\nor type anything else (or press enter) to quit the game.");
                Console.Write("> ");
                retryIn = Console.ReadLine().ToUpper();  // Ensures that the input will be accepted regardless of the casing,
                                                         // and that if the user is pedantic enough to use qoutation marks
                                                         // that will be accepted, as well
            } while (retryIn == "y" || retryIn == "\"y\"");
            return;
        }
    }
}