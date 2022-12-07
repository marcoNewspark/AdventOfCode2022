using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20221207
{
    internal class AoCDir
    {
        public string DirName { get; set; } = string.Empty;
        public List<AoCDir> SubDirectories { get; set; }
        public List<AoCFile> Files { get; set; }

        public AoCDir? Parent { get; set; }

        public AoCDir()
        {
            SubDirectories = new List<AoCDir>();    
            Files = new List<AoCFile>();    
        }

        public AoCDir(string dirName)
        {
            DirName = dirName;
            SubDirectories = new List<AoCDir>();
            Files = new List<AoCFile>();
        }

        public int DirSize { get {
                int res = 0;

                foreach(AoCDir d in SubDirectories)
                {
                    res += d.DirSize;
                }

                int fileRes = 0;
                foreach (AoCFile f in Files)
                {
                    fileRes += f.Size;

                };
                res += fileRes;

                if(res >= 1272621)
                {
                    Console.WriteLine($"{DirName} {res}");
                }
               
                return res;
            } }
         

        
    }
}
