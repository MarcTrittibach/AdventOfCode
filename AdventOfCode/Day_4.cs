using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Day_4
    {
        public static void Execute()
        {
            var bingoBoards = new List<BingoBoard>();
            var numbers = new List<int>();

            using (var file = File.OpenText(@"C:\Users\trim\source\repos\AdventOfCode\AdventOfCode\Inputs\Day4.txt"))
            {
                string currentline;
                string bingoline = file.ReadLine();
                int counter = 0;

                while ((currentline = file.ReadLine()) is not null)
                {
                    if(string.IsNullOrEmpty(currentline))
                    {
                        continue;
                    }


                    var strings = currentline.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach(var s in strings)
                    {
                        numbers.Add(Int32.Parse(s));
                    }

                    counter++;
                    if (counter > 4)
                    {
                        bingoBoards.Add(new BingoBoard(numbers.ToArray()));
                        counter = 0;
                        numbers.Clear();
                    }
                }

                int lastWinScore = 0;
                foreach (var n in bingoline.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(e => Int32.Parse(e)))
                {
                    BingoBoard? winbb = null;
                    foreach(var bb in bingoBoards)
                    {
                        if (bb.didwin == true)
                        { continue; }

                        var didwin = bb.SetEntry(n);
                        if(didwin)
                        {
                            winbb = bb;
                            lastWinScore = bb.CalculateScore();
                            //Console.WriteLine(lastWinScore);

                        }
                    }
                }
                Console.WriteLine(lastWinScore);
            }
        }
    }

    public class BingoBoard
    {
        private BingoEntry[,] _board = new BingoEntry[5, 5];
        private int winningNumber = -12;

        public bool didwin = false;

        public BingoBoard(int[] input)
        {
            if(input.Length != 25)
            {
                throw new System.Exception();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    _board[i, j] = new BingoEntry(false, input[i*5 +j]); 
                }
            }
        }

        public int CalculateScore()
        {
            int score = 0;
            foreach(var e in _board)
            {
                if(e.Marked == false)
                {
                    score += e.Value;
                }
            }
            return score *= winningNumber;
        }

        public bool SetEntry(int value)
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (_board[i, j].Value == value)
                    {
                        _board[i, j].Marked = true;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                bool isWin = true;
                for (int j = 0; j < 5; j++)
                {
                    if(_board[i, j].Marked == false)
                    {
                        isWin = false;
                    }
                }
                
                if(isWin)
                {
                    didwin = true;
                    winningNumber = value;
                    return true;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                bool isWin = true;
                for (int j = 0; j < 5; j++)
                {
                    if (_board[j, i].Marked == false)
                    {
                        isWin = false;
                    }
                }

                if (isWin)
                {
                    winningNumber = value;
                    didwin = true;
                    return true;
                }
            }
            return false;
        }
    }

    public struct BingoEntry
    {
        public BingoEntry(bool marked, int value)
        {
            Marked = marked;
            Value = value;
        }

        public bool Marked;
        public int Value;
    }
}
