using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC20221208
{
    internal class InputHelper
    {
        private string _inFile;
        private int[,] _trees;
        // private List<List<int>> _trees = new List<List<int>>();
        public InputHelper(string inFile)
        {
            _inFile = inFile;
        }

        public void ProcessInputFile()
        {
            List<string> lineList = new List<string>();
            using(StreamReader r = new StreamReader(_inFile))
            {
                do
                {
                    var line = r.ReadLine();
                    if (line != null) lineList.Add(line);


                } while (!r.EndOfStream);

                CreateArrays(lineList);

                Console.Write(DumpTrees());
                Console.WriteLine("-------------");
                Console.Write($"{CountVisibleTrees()}");


            }
        }

        private void CreateArrays(List<string> lines)
        {
            int xE = lines[0].Length - 1;
            int yE = lines.Count - 1;
            int x = 0;
            int y = 0;

            _trees = new int[xE+1,yE+1];

            foreach(string line in lines)
            {
                foreach(char c in line.ToCharArray())
                {
                    _trees[x++,y] = Int32.Parse(c.ToString());
                }
                x = 0;
                y += 1;
            }
        }

        private int CountVisibleTrees()
        {
            var res = 0;
            var x = 0;
            var y = 0;

            for(y=0;y<=_trees.GetUpperBound(1);y++)
            {
                for(x=0;x<=_trees.GetUpperBound(0);x++)
                {
                    if (x == 0 || y == 0 || x == _trees.GetUpperBound(0) || y==_trees.GetUpperBound(1))
                    {
                        // edges are always visible
                        res += 1;
                    }
                    else
                    {
                        // go to the edges and check if there are higher numbers. 
                        // if there are no higher numbers, tree is visible. 
                        var visible = true;
                        for(var x1=0; x1 < x && visible; x1++)
                        {
                            visible = _trees[x1, y] < _trees[x,y];
                        }
                        if(!visible)
                        {
                            var visible2 = true;
                            for(var x1 = x+1; x1 <= _trees.GetUpperBound(0) && visible2; x1++)
                            {
                                visible2 = _trees[x1, y] < _trees[x, y];
                            }
                            visible = visible2;
                        }

                        if(!visible)
                        {
                            var visible2 = true;
                            for(var y1=0; y1< y && visible2; y1++)
                            {
                                visible2 = _trees[x, y1] < _trees[x, y];
                            }

                            if(!visible2)
                            {
                                var visible3 = true;
                                for (var y1 = y+1; y1 <= _trees.GetUpperBound(1) && visible3; y1++)
                                {
                                    visible3 = _trees[x, y1] < _trees[x, y];
                                }

                                visible2 = visible3;
                            }

                            visible = visible2;
                        }

                        res += visible ? 1 : 0;
                    }
                }
            }

            
            return res;
        }

        public int GetResult2()
        {
            var res = 0;

            for(int x = 1; x<=_trees.GetUpperBound(0)-1; x++)
            {
                for(int y = 1; y<=_trees.GetUpperBound(1)-1; y++)
                {
                    var calcRes = ScenicScore(x, y);
                    res = calcRes > res ? calcRes : res;
                }
            }

            Console.WriteLine($"final result2: {res}");
            return res;
        }

        private int ScenicScore(int inX, int inY)
        {
            var res = 0;
            int[] values = new int[4];
            var highest = true;
            var work = 0;
            // check all values before the current one - X
            for(var x = inX-1; x >=0 && highest; x--)
            {
                work += 1;
                highest = _trees[x, inY] < _trees[inX, inY];
                if(!highest)
                {
                    break;
                }
            }
            values[0] = work;
            work = 0;
            // check all values after the current one - X
            highest = true;
            for (var x = inX + 1; x <= _trees.GetUpperBound(0) && highest; x++)
            {
                work += 1;
                highest = _trees[x, inY] < _trees[inX, inY];
                if (!highest)
                {
                    break;
                }
            }
            values[1] = work;
            work = 0;

            // check all values before the current one - Y
            highest = true;
            for(var y= inY-1; y>=0 && highest; y--)
            {
                work += 1;
                highest = _trees[inX, y] < _trees[inX, inY];
                if (!highest) {
                    break;
                }
            }
            values[2] = work;
            work = 0;

            // check all values after the current one - Y
            highest = true;
            for(var y= inY+1; y<=_trees.GetUpperBound(1) && highest; y++)
            {
                work += 1;
                highest = _trees[inX, y] < _trees[inX, inY];
                if (!highest)
                {
                    break;
                }
            }
            values[3] = work;

            res = values[0] * values[1] * values[2] * values[3];
            return res;
        }
        private string DumpTrees()
        {
            StringBuilder b = new StringBuilder();
            string line = string.Empty;
            for(var y = 0; y<=_trees.GetUpperBound(1); y++)
            {
                for(var x = 0; x<=_trees.GetUpperBound(0);x++)
                {
                    line += _trees[x,y].ToString();
                }
                b.AppendLine(line);
                line = string.Empty;
            }
            return b.ToString();
        }
    }
}
