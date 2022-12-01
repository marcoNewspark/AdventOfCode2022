using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221201
{
    internal class Elf
    {
        public List<int> Items { get; set; }
        public Elf(List<int> calories)
        {
            Items = calories;

        }

        public int GetCalorieSum()
        {
            return Items.Sum();
        }
    }
}
