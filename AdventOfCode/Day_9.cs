using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day_9
    {
        private List<List<int>> map = new List<List<int>>();
        private int maxI = 99;
        private int maxJ = 99;

        public void Execute()
        {
            using (var file = File.OpenText(@"C:\Users\Marc\source\repos\AdventOfCode\AdventOfCode\Inputs\Day9.txt"))
            {
                string? currentline;
                while ((currentline = file.ReadLine()) is not null)
                {
                    map.Add(currentline.ToCharArray().Select(e => e - '0').ToList());
                }

                int amount = 0;
                List<Location> lowpoints = new List<Location>();

                for(int i = 0; i <= maxI; i++)
                {
                    for(int j = 0; j <= maxJ; j++)
                    {
                        bool islowest = !getAdjacent(i, j).Any(e => e <= map[i][j]);
                        if(islowest)
                        {

                            lowpoints.Add(new Location() { i = i, j = j, val = map[i][j] }); 
                        }
                    }
                }

                var lists = new List<List<Location>>();
                
                foreach(var lowest in lowpoints)
                {
                    visited = new();
                    getBasin(lowest);
                    lists.Add(new List<Location>(visited));
                }

                lists.Sort((a, b) => b.Count - a.Count);

                Console.WriteLine(lists[0].Count * lists[1].Count * lists[2].Count );

            }
        }

        List<Location> visited = new();

        void getBasin(Location location)
        {
            if(visited.Any(e => e.i == location.i && e.j == location.j))
            {
                return;
            }

            visited.Add(location);

            var adjacent = getAdjacentLocations(location.i, location.j);
            for(int i = adjacent.Count-1; i >= 0; i--)
            {
                if(adjacent[i].val == 9)
                {
                    adjacent.RemoveAt(i);
                }
            }

            foreach(var a in adjacent)
            {
                getBasin(a);
            }
        }

        public List<int> getAdjacent(int i, int j)
        {
            var adjacent = new List<int>();

            if (i == 0 && j == 0)
            {
                adjacent.Add(map[i + 1][j]);
                adjacent.Add(map[i][j + 1]);
            }
            else
            if (i == 0 && j == maxJ)
            {
                adjacent.Add(map[i + 1][j]);
                adjacent.Add(map[i][j-1]);
            }
            else
            if (i == maxI && j == 0)
            {
                adjacent.Add(map[i - 1][j]);
                adjacent.Add(map[i][j + 1]);
            }
            else
            if (i == maxI && j == maxJ)
            {
                adjacent.Add(map[i - 1][j]);
                adjacent.Add(map[i][j - 1]);
            }
            else

            if (i == 0)
            {
                adjacent.Add(map[i + 1][j]);
                adjacent.Add(map[i][j + 1]);
                adjacent.Add(map[i][j - 1]);
            }
            else

            if (j == maxJ)
            {
                adjacent.Add(map[i + 1][j]);
                adjacent.Add(map[i - 1][j]);
                adjacent.Add(map[i][j - 1]);
            }
            else

            if (j == 0)
            {
                adjacent.Add(map[i + 1][j]);
                adjacent.Add(map[i - 1][j]);
                adjacent.Add(map[i][j + 1]);
            } 
            else if (i == maxI)
            {
                adjacent.Add(map[i - 1][j]);
                adjacent.Add(map[i][j + 1]);
                adjacent.Add(map[i][j - 1]);

            }
            else
            {
                adjacent.Add(map[i + 1][j]);
                adjacent.Add(map[i - 1][j]);
                adjacent.Add(map[i][j + 1]);
                adjacent.Add(map[i][j - 1]);
            }

            return adjacent;

        }

        public struct Location
        {
            public int i;
            public int j;
            public int val;
        }

        public List<Location> getAdjacentLocations(int i, int j)
        {
            var adjacent = new List<Location>();

            if (i == 0 && j == 0)
            {
                adjacent.Add(new Location() { i = i + 1, j = j, val = map[i + 1][j] });
                adjacent.Add(new Location() { i = i, j = j + 1, val = map[i][j + 1] });
            }
            else if (i == 0 && j == maxJ)
            {
                adjacent.Add(new Location() { i = i + 1, j = j, val = map[i + 1][j] });
                adjacent.Add(new Location() { i = i, j = j - 1, val = map[i][j - 1] });
            }
            else
            if (i == maxI && j == 0)
            {
                adjacent.Add(new Location() { i = i - 1, j = j, val = map[i - 1][j] });
                adjacent.Add(new Location() { i = i, j = j + 1, val = map[i][j + 1] });
            }
            else
            if (i == maxI && j == maxJ)
            {
                adjacent.Add(new Location() { i = i - 1, j = j, val = map[i - 1][j] });
                adjacent.Add(new Location() { i = i, j = j - 1, val = map[i][j - 1] });
            }
            else

            if (i == 0)
            {
                adjacent.Add(new Location() { i = i + 1, j = j, val = map[i + 1][j] });
                adjacent.Add(new Location() { i = i, j = j + 1, val = map[i][j + 1] });
                adjacent.Add(new Location() { i = i, j = j - 1, val = map[i][j - 1] });
            }
            else

            if (j == maxJ)
            {
                adjacent.Add(new Location() { i = i + 1, j = j, val = map[i + 1][j] });
                adjacent.Add(new Location() { i = i - 1, j = j, val = map[i - 1][j] });
                adjacent.Add(new Location() { i = i, j = j - 1, val = map[i][j - 1] });
            }
            else

            if (j == 0)
            {
                adjacent.Add(new Location() { i = i + 1, j = j, val = map[i + 1][j] });
                adjacent.Add(new Location() { i = i - 1, j = j, val = map[i - 1][j] });
                adjacent.Add(new Location() { i = i, j = j + 1, val = map[i][j + 1] });
            }
            else if (i == maxI)
            {
                adjacent.Add(new Location() { i = i - 1, j = j, val = map[i - 1][j] });
                adjacent.Add(new Location() { i = i, j = j + 1, val = map[i][j + 1] });
                adjacent.Add(new Location() { i = i, j = j - 1, val = map[i][j - 1] });

            }
            else
            {
                adjacent.Add(new Location() { i = i + 1, j = j, val = map[i + 1][j] });
                adjacent.Add(new Location() { i = i - 1, j = j, val = map[i - 1][j] });
                adjacent.Add(new Location() { i = i, j = j + 1, val = map[i][j + 1] });
                adjacent.Add(new Location() { i = i, j = j - 1, val = map[i][j - 1] });
            }

            return adjacent;

        }
    }
}
