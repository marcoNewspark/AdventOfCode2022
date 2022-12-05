using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221204
{
    internal class InputHelper
    {
        private string _inFile;
        public List<ElfAssignment> ElfAssignments { get; } = new List<ElfAssignment>();
        
        public InputHelper(string inFile)
        {
            _inFile = inFile;   
            ReadInputfile();    
        }

        private void ReadInputfile()
        {
            using(StreamReader r = new StreamReader(_inFile))
            {
                do
                {
                    var line = r.ReadLine();
                    // 2-4,6-8
                    var aList = line.Split(",").Select(c => c.Split("-").Select(c2 => Int32.Parse(c2))).ToList();
                    var iList = aList[0].Concat(aList[1]).ToList();

                    
                    // Select(c => c.Split("-").Select(c2 => Int32.Parse(c2)).ToList()) ;
                    ElfAssignments.Add(new ElfAssignment(iList[0], iList[1], iList[2], iList[3]));
                }
                while (!r.EndOfStream);
            }
        }


    }
}
