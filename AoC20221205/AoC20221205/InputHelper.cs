using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC20221205
{
    internal class InputHelper
    {
        private StackHelper _stackHelper = new StackHelper();
        private List<Move> _moves = new List<Move>();
        public InputHelper(string inFile)
        {
            
            using(StreamReader r = new StreamReader(inFile))
            {
                string line;
                do
                {
                    // read until empty line to get the current state
                    do
                    {
                        line = r.ReadLine() ?? String.Empty;
                        if(line.Length > 0)
                        {
                            // now check if it is a box line
                            // or a matrix line
                            if(IsBoxLine(line))
                            {
                                // Proces box line
                                ProcessBoxline(line) ;
                            }
                        }

                    }
                    while (line.Length > 0);

                    // now process the moves
                    do
                    {
                        var parts = (r.ReadLine() ?? String.Empty).Replace("move ", "").Replace(" from", "").Replace(" to", "").Split(" ").ToList().Select(i => Int32.Parse(i)).ToList();
                        _stackHelper.AddMove(new Move(parts[0], parts[1], parts[2]));

                    }
                    while (!r.EndOfStream);

                    Console.WriteLine($"Moves: {_stackHelper.DumpMoves()}");
                }
                while (!r.EndOfStream);
                _stackHelper.ProcessMoves2();

                Console.WriteLine($"{_stackHelper.DumpStacks()}");

            }
        }

        private bool IsBoxLine(string Line)
        {
            return Line.TrimStart()[0] == '[';
        }
        private void ProcessBoxline(string Line)
        {
            char[] lineAsChars = Line.ToCharArray();
            for(int i=0;i<Line.Length;i++)
            {
                if ((i+1) % 4 == 0)
                {
                    lineAsChars[i] = '|'; 
                }
            }
            Line = new string(lineAsChars);

            var stackItems = Line.Split("|").ToList() ;
            for(int i=0; i<stackItems.Count; i++)
            {
                if (stackItems[i].Trim().Length != 0)
                {
                    _stackHelper.AddToStack(stackItems[i], i);
                }
            }

            _stackHelper.ReverseStacks();

            Console.WriteLine($"{_stackHelper.DumpStacks()}");



        }
    }
}
