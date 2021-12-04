using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3_1
{
    public class Day_3_1
    {
        public static void Sol_1()
        {
            Int64 res1 = 0;
            Int64 res2 = 0;

            int[] array = new int[] {0,0,0,0,0,0,0,0,0,0,0,0 };
            using (var file = File.OpenText(@"C:\Users\trim\source\repos\AdventOfCode\AdventOfCode\Day3_1\BinaryMeasurements.txt"))
            {
                string currentline;
                while ((currentline = file.ReadLine()) is not null)
                {
                    var number = 0;

                    for(int i = 0; i < 12; i++)
                    {
                        number += (currentline[11 - i] -48) * (int)Math.Pow(2, i);
                    }


                    for(int i = 0; i < 12; i++)
                    {
                        array[i] += (((Int64)Math.Pow(2, i) & number) > 0) ? 1 : 0;
                    }

                }

                for (int i = 0; i < 12; i++)
                {
                    if (array[i] >= 500)
                    {
                        res1 += (long)Math.Pow(2, i);
                    }
                    else
                    {
                        res2 += (long)Math.Pow(2, i);
                    }
                }

                Console.WriteLine(res1 * res2 );

            }
        }
    }
}