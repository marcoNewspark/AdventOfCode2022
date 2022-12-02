using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221202
{
    internal class Processor
    {
        private string _file;
        private List<Move>? _moves;
        private Result _result;
        public Processor(string inFile, Result inResult)
        {
            _file = inFile;
            _moves = ProcessFile();
            _result = inResult;
        }

        private List<Move>? ProcessFile()
        {
            List<int> calorieValues = new List<int>();
            List<Move> moves = new List<Move>();
            StreamReader r = new StreamReader(File.Open(_file, FileMode.Open));
            
            if (r != null)
            {
                while (!r.EndOfStream)
                {
                    do
                    {
                        var line = r.EndOfStream ? string.Empty : r.ReadLine();
                        var value = line.Split(" ");
                        moves.Add(new(value[0], value[1]));

                    }
                    while (!r.EndOfStream);
                }
            }
            return moves;
        }

        public int CalculateResult()
        {
            int result = 0;

            foreach(Move m in _moves)
            {
                
                result += _result.CalculateResult(m);
                Console.WriteLine($"Interim: {result}");
                Console.WriteLine("_____________________________________________");
            }
            return result;
        }

        public int CalculateResult2()
        {
            int result = 0;
            foreach(Move m in _moves)
            {
                result += _result.CalculateResult2(m);
                Console.WriteLine($"Interim: {result}");
                Console.WriteLine("_____________________________________________");
            }
            return result;
        }
        public void Dump( )
        {
            foreach(Move move in _moves)
            {
                Console.WriteLine($"{move.HisMove} {move.MyMove} ");
            }
        }
    }
}
