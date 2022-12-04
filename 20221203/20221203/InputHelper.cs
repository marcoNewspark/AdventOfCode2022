using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221203
{
    internal class InputHelper
    {
        private string _inFile = string.Empty;
        public List<string> InputLiness { get; set; }
        public InputHelper(string inFile)
        {
            _inFile = inFile;
            InputLiness = ReadInputFile();

        }

        private List<string> ReadInputFile()
        {
            InputLiness = new List<string>();
            using (StreamReader r = new StreamReader(_inFile))
            {
                do
                {

                    string line = r.ReadLine();
                    InputLiness.Add(line);
                }
                while (!r.EndOfStream);
            }

            return InputLiness;
        }
    }
}
