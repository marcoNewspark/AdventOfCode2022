using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20221205
{
    internal class StackHelper
    {
        private List<List<string>> _preStacks = new List<List<string>>();
        private List<Stack<String>> _stacks = new List<Stack<string>>();
        private List<Move> _moves = new List<Move>(); 

        public void AddToStack(String Box, int StackNumber )
        {
            while(StackNumber >= _preStacks.Count)
            {
                _preStacks.Add(new List<string>());
            }
            _preStacks[StackNumber].Add(Box);

        }

        public void ReverseStacks()
        {
            _stacks.Clear();
            for(int i =0; i<_preStacks.Count; i++)
            {
                var stack = new Stack<string>();

                for(int j = _preStacks[i].Count-1 ; j >=0 ; j--)
                {
                    stack.Push(_preStacks[i][j]);
                }
                _stacks.Add(stack);
            }
            
        }

        public void AddMove(Move move)
        {
            _moves.Add(move);
        }

        public string DumpStacks()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;

            foreach (var s in _stacks)
            {
                sb.Append($"{i++}: "); 
                foreach(var e in s)
                {
                    sb.Append(e);
                }
                sb.Append("\r\n");
            }

            return sb.ToString();
        }

        public string DumpMoves()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Move m in _moves)
            {
                sb.AppendLine($"Move {m.Count} from {m.From} to {m.To}");
            }

            return sb.ToString();
        }

        public void ProcessMoves()
        {
            foreach(Move m in _moves)
            {
                int count; int from; int to;
                
                (count, from, to) = (m.Count, m.From - 1, m.To - 1);
                
                Console.WriteLine($"Move {count} from {from} to {to}");

                for (int i=0;i<count;i++)
                {
                    _stacks[to].Push(_stacks[from].Pop());
                }

                Console.WriteLine($"{DumpStacks()}");
            }
        }

        public void ProcessMoves2()
        {
            foreach (Move m in _moves)
            {
                int count; int from; int to;

                (count, from, to) = (m.Count, m.From - 1, m.To - 1);

                Console.WriteLine($"Move {count} from {from} to {to}");

                List<string> grabber = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    grabber.Add(_stacks[from].Pop());
                    
                }
                for (int j = grabber.Count - 1; j >= 0; j--)
                {
                    _stacks[to].Push(grabber[j]);
                }

                Console.WriteLine($"{DumpStacks()}");
            }
        }
    }
}
