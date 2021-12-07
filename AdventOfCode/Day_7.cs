using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day_7
    {
        public static void Execute()
        {
            var numbers = new List<int>();

            using (var file = File.OpenText(@"C:\Users\trim\source\repos\AdventOfCode\AdventOfCode\Inputs\Day7.txt"))
            {
                string crabbyLine = file.ReadLine();

                List<long> crabSubs = crabbyLine.Split(',').Select(e => long.Parse(e)).ToList();

                long min = crabSubs.Min();
                long max = crabSubs.Max();
                long lowestFuel = 9999999999;
                long currentFuel = 9999999999;
                long bestAmount = 0;

                for (long i = max; i >= min; i--)
                {
                    currentFuel = crabSubs.Select(s => GetDifferenceIncreasing(Math.Abs(s-i))).Sum();
                    if (lowestFuel > currentFuel)
                    {
                        lowestFuel = currentFuel;
                        bestAmount = i;
                    }
                }

                Console.WriteLine(lowestFuel); 
            }
        }
        public static long GetDifferenceIncreasing(long input)
        {
            long output = 0;
            for (long i = 0; i < input; i++)
            {
                output += i + 1;
            }
            return output;
        }

    }
}
