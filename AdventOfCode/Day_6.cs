using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Day_6
    {
        public static void Execute()
        {
            var bingoBoards = new List<BingoBoard>();
            var numbers = new List<int>();

            using (var file = File.OpenText(@"C:\Users\trim\source\repos\AdventOfCode\AdventOfCode\Inputs\Day6.txt"))
            {
                string fishyLine = file.ReadLine();

                List<Lanternfish> lanternfishes = fishyLine.Split(',').Select(e => new Lanternfish(Int32.Parse(e))).ToList();

                long[] fishies = new long[7];
                foreach (var l in lanternfishes)
                {
                    fishies[l.Counter]++;
                }

                long newBorn = 0;
                long newBornPlus1 = 0;

                for (int i = 0; i < 258; i++)
                {
                    long toBePotentAfterThisDay = newBornPlus1;

                    newBornPlus1 = newBorn;
                    newBorn = fishies[i % 7];

                    fishies[i % 7] += toBePotentAfterThisDay;
                }
                
                    /*
                    for(int i = 0; i < 256; i++)
                    {
                        int reproduceCounter = 0;

                        foreach(var fishy in lanternfishes)
                        {
                            var didReproduce = fishy.Decrement();
                            if(didReproduce)
                            {
                                reproduceCounter++;
                            }
                        }

                        for(int j = 0; j < reproduceCounter; j++)
                        {
                            lanternfishes.Add(new Lanternfish());
                        }
                    }
                    */

                    Console.WriteLine($"{fishies.Sum()} fishies are now swimming in the pond!");
            }
        }
    }

    public class Lanternfish
    {
        public int Counter { get; private set; }

        public Lanternfish(int counter = 8)
        {
            Counter = counter;
        }

        public bool Decrement()
        {
            Counter--;
            if(Counter == -1)
            {
                Counter = 6;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
