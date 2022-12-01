using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221201
{
    internal class Processor
    {
        string _file;
        public Processor(string inFile)
        {
            _file = inFile;
        }

        public List<Elf>? ProcessFile()
        {
            List<int> calorieValues = new List<int>();
            List<Elf> elves = new List<Elf>();
            StreamReader r = new StreamReader(File.Open(_file, FileMode.Open));

            if (r != null)
            {
                string? value = r.EndOfStream ? string.Empty : r.ReadLine();
                if (value != null)
                {
                    while (!r.EndOfStream)
                    {
                        calorieValues = new List<int>();
                        value = r.EndOfStream ? string.Empty : r.ReadLine();
                        while (value.Length > 0 && !r.EndOfStream)
                        {
                            int intValue;
                            Int32.TryParse(value, out intValue);
                            calorieValues.Add(intValue);
                            value = r.EndOfStream ? String.Empty : r.ReadLine();
                        }
                        elves.Add(new Elf(calorieValues));

                    }

                }
            }
            return elves;
        }

        public void DumpElves(List<Elf> elves)
        {
            int i = 0;
            
            foreach(Elf elf in elves.OrderBy(e => e.GetCalorieSum()))
            {

                Console.WriteLine($"Elf {i++}: {elf.GetCalorieSum()} ");
            }
        }

        public void ListTopXElves(List<Elf> elves, int topX)
        {
            int value = elves.OrderBy(e => e.GetCalorieSum()).ToList().TakeLast(3).Sum(e=> e.GetCalorieSum());
            
            Console.WriteLine($"Sum of 3 highest: {value}");
        }
    }
}
