using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221202
{
    internal record Move
    {
        public string? HisMove { get; set; }
        public string? MyMove { get; set; }

        public Move(string hisMove, string myMove )
        {
            (HisMove, MyMove) = (hisMove, myMove);
        }
        public void Dump()
        {
            Console.WriteLine($"{HisMove} {MyMove}");
        }
    }
}
