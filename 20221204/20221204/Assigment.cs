using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221204
{
    public class Assignment
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Assignment(int start, int end)
        {
            (Start, End) = (start, end);
        }

        public bool Contains(Assignment Other)
        {
            return Other.Start >= Start && Other.End <= End;
        }

        public bool Overlaps(Assignment Other)
        {
            return (Other.Start >= Start && Other.Start <= End) || (Other.End <= End && Other.End >= Start);
        }
    }
}
