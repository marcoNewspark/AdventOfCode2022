using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20221206
{
    internal class InputHelper
    {
        private string _inFile;
        public InputHelper(string inFile)
        {
            _inFile = inFile; 
        }

        public List<string> ProcessInputFile()
        {
            using (StreamReader r = new StreamReader(_inFile))
            {
                var res = new List<string>();
                do
                {

                    var line = r.ReadLine();
                    if(line!=null && line.Length>0)
                    {
                        res.Add(line);
                    }
                }
                while (!r.EndOfStream);

                return res;
            }

        }
    }
}
