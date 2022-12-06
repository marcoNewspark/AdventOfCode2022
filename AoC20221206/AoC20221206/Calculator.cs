using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20221206
{
    
    internal class Calculator
    {
        public Calculator()
        {

        }

        public int ProcessLine(string Line)
        {
            int length = Line.Length;
            int res = 0;

            for (int end = 3; end < length && res==0; end++)
            {
                res = (Line.Substring(end - 3, 4).ToCharArray().GroupBy(c => c).ToList().Count >= 4) ? end + 1 : 0;
            }
            return res;
        }

        public int ProcessLine2(string Line)
        {
            int length = Line.Length;
            int res = 0;

            for (int end = 13; end < length && res == 0; end++)
            {
                res = (Line.Substring(end - 13, 14).ToCharArray().GroupBy(c => c).ToList().Count >= 14) ? end + 1 : 0;
            }
            return res;
        }
        
    }
}
