using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20221205
{
    internal class Move
    {
        public int Count { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public Move(int CountIn, int FromIn, int ToIn)
        {
            (Count, From, To) = (CountIn, FromIn, ToIn);
        }
    }
}
