using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221203
{
    internal class Calculator
    {
        private Dictionary<string, int> _letterMapper = new Dictionary<string,int>();
        public Calculator()
        {
            for (int i = 1; i <= 26; i++)
            {

                string letter = Convert.ToChar(96 + i).ToString();
                _letterMapper.Add(letter, i);

                letter = Convert.ToChar(64 + i).ToString();
                _letterMapper.Add(letter, i+26);

            }
        }

        public int CalculateScore1(List<string> Backpack)
        {
            int result = 0;

            /*
             * To help prioritize item rearrangement, every item type can be converted to a priority:

                Lowercase item types a through z have priorities 1 through 26.
                Uppercase item types A through Z have priorities 27 through 52.
                In the above example, the priority of the item type that appears in both compartments of each 
                rucksack is 16 (p), 38 (L), 42 (P), 22 (v), 20 (t), and 19 (s); the sum of these is 157.
            */
            foreach(string item in Backpack)
            {
                var res = FindDuplicate(item);
                result += res.Sum(l => _letterMapper[l]);
            }

            return result;
        }

        public int CalculateScore2(List<string> Backpack)
        {
            int res = 0;
            Range firstThree = new Range(0, 2);
            var count = Backpack.Count;
            for (int i = 0; i < count / 3; i++)
            {
                var items = Backpack.Take(3).ToList() ;
                
                var interim = items[0].Intersect(items[1]).ToList();
                var final = items[2].Intersect(interim).ToList();
                res += final.Sum(c => _letterMapper[c.ToString()]);
                Backpack.RemoveRange(0, 3);
            }
            
            return res;
        }

        private List<string> FindDuplicate(string input)
        {
            var comp= input.Insert(input.Length / 2, "|").Split("|");

            var comp1 = comp[0].AsEnumerable().ToList();
            var comp2 = comp[1].AsEnumerable().ToList();

            return comp1.Intersect(comp2).Select(c => c.ToString()).ToList();

        }

    }
}
