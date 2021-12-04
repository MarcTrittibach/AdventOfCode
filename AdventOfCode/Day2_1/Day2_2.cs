using System;
using System.IO;

namespace AdventOfCode
{
    class Day2_2
    {
        public static void Execute()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            using (var file = File.OpenText(@"C:\Users\trim\source\repos\AdventOfCode\AdventOfCode\Day2_1\DepthInputs.txt"))
            {
                string currentline;
                while ((currentline = file.ReadLine()) is not null)
                {
                    var reading = ProcessLine(currentline);

                    if(reading.Item2 == Direction.Horizontal)
                    {
                        horizontal += reading.Item1;
                        depth += reading.Item1 * aim;
                    }
                    else
                    {
                        aim += reading.Item1;
                    }
                }
            }
            Console.WriteLine(horizontal * depth); 
        }

        private static (int, Direction) ProcessLine(string line)
        {
            var items = line.Split(' ');
            if(items[0] == "down")
            {
                return (Int32.Parse(items[1]), Direction.Vertical); 
            } 
            else if (items[0] == "up")
            {
                return (Int32.Parse(items[1]) * -1, Direction.Vertical);
            }
            else
            {
                return (Int32.Parse(items[1]), Direction.Horizontal);
            }
        }
        
        enum Direction
        {
            Horizontal, 
            Vertical
        }

    }
}
