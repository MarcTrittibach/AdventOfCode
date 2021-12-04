using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Day1_2
    {
        public static void Execute()
        {
            List<int> nums = new();

            int depthIncreadsed = 0;
            
            int previousLocalMax; 
            
            using (var file = File.OpenText(@"C:\Users\trim\source\repos\AdventOfCode\AdventOfCode\Day1_1\DepthInputs.txt"))
            {
                nums.Add(Int32.Parse(file.ReadLine()));
                nums.Add(Int32.Parse(file.ReadLine()));
                nums.Add(Int32.Parse(file.ReadLine()));

                previousLocalMax = nums.Sum();

                string currentline; 

                while((currentline = file.ReadLine()) is not null)
                {
                    int currentDepth = Int32.Parse(currentline);
                    nums.RemoveAt(0);
                    nums.Add(currentDepth);

                    if (previousLocalMax < nums.Sum())
                    {
                        depthIncreadsed++;
                    }
                    previousLocalMax = nums.Sum();
                }
            }
            Console.WriteLine(depthIncreadsed); 
        }
    }
}
