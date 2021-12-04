using System;
using System.IO;

namespace AdventOfCode
{
    class Day1_1
    {
        public static void Execute()
        {
            int depthIncreadsed = 0;
            int previousDepth; 
            using (var file = File.OpenText(@"C:\Users\trim\source\repos\AdventOfCode\AdventOfCode\Day1_1\DepthInputs.txt"))
            {
                previousDepth = Int32.Parse(file.ReadLine());

                string currentline; 
                while((currentline = file.ReadLine()) is not null)
                {
                    int currentDepth = Int32.Parse(currentline);
                    if (previousDepth < currentDepth)
                    {
                        depthIncreadsed++;
                    }
                    previousDepth = currentDepth;
                }
            }
            Console.WriteLine(depthIncreadsed); 
        }
    }
}
