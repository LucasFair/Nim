using System;
using System.Threading;

namespace Nim
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var rnd = new Random();
            //int cpuNum;
            //cpuNum = 3;
            //int cpuRnd = rnd.Next(cpuNum, cpuNum);
            int cpuTime = 500;
            int matchCnt = 7;
            int userIn;

            Console.WriteLine("Matches -> " + matchCnt + " left.");  // Round 1
            Console.WriteLine("Pick 1 - 3 match(es)!");
            Console.Write("> ");
            userIn = Convert.ToInt32(Console.ReadLine());
            int matchUpd = matchCnt - userIn;
            matchCnt = matchUpd;
            Console.WriteLine("Matches -> " + matchCnt + " left.");
            if (matchUpd < 7)  // Round 1 CPU
            {
                {
                    int cpuRnd = rnd.Next(1, 3);
                    Thread.Sleep(cpuTime);
                    Console.WriteLine("The opponent took " + cpuRnd + "!");
                    matchUpd = matchCnt - cpuRnd;
                    matchCnt = matchUpd;
                    Console.WriteLine("...");
                    Console.WriteLine("Matches -> " + matchCnt + " left.");
                    if (matchUpd < 6)  // Round 2
                    {
                        Thread.Sleep(cpuTime);
                        Console.WriteLine("Pick 1 - 3 match(es)!");
                        Console.Write("> ");
                        userIn = Convert.ToInt32(Console.ReadLine());
                        matchUpd = matchCnt - userIn;
                        matchCnt = matchUpd;

                        Console.WriteLine("Matches -> " + matchCnt + " left.");
                        if (matchUpd < 5)  // Round 2 CPU
                        {
                            cpuRnd = rnd.Next(1, 1);
                            Thread.Sleep(cpuTime);
                            Console.WriteLine("The opponent took " + cpuRnd + "!\n...");
                            matchUpd = matchCnt - cpuRnd;
                            matchCnt = matchUpd;
                            Console.WriteLine("Matches -> " + matchCnt + " left.");
                            if (matchUpd < 4)  // Round 3
                            {
                                Thread.Sleep(cpuTime);
                                Console.WriteLine("Pick 1 - 3 match(es)!");
                                Console.Write("> ");
                                userIn = Convert.ToInt32(Console.ReadLine());
                                matchUpd = matchCnt - userIn;
                                matchCnt = matchUpd;
                                Console.WriteLine("Matches -> " + matchCnt + " left.");
                                if (matchUpd < 5)  // Round 3 CPU
                                {
                                    Thread.Sleep(cpuTime);
                                    Console.WriteLine("The opponent took " + cpuRnd + "!\n...");
                                    matchUpd = matchCnt - cpuRnd;
                                    matchCnt = matchUpd;
                                    Console.WriteLine("Matches -> " + matchCnt + " left.");
                                    if (matchUpd < 4)  // Round 4
                                    {
                                        Console.WriteLine("YOU WIN.");
                                    }

                                }
                            }
                        }

                    }

                }
            }
        }
    }
}