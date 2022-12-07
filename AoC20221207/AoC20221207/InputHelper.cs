using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20221207
{
    internal class InputHelper
    {
        private string _inFile;
        private AoCDir _root;
        public InputHelper(string inFile)
        {
            _inFile = inFile;
        }

        public List<AoCDir> ProcessInputfile()
        {
            var res = new List<AoCDir>();
            AoCDir currentDir = new AoCDir();
            AoCDir prevDir = new AoCDir();


            using (StreamReader r = new StreamReader(_inFile))
            {
                do
                {
                    
                    var line = r.ReadLine();
                    
                    var lineType= GetLineType(line);
                    //Console.WriteLine(lineType);

                    if (lineType.StartsWith("command"))
                    {
                        line = line.Replace("command ", "");
                        if (line == "$ cd /")
                        {
                            // start wth root folder
                            currentDir = new AoCDir("root");
                            _root = currentDir;
                        }
                        else if (line.StartsWith("$ ls"))
                        {
                            // do nothing for now. Just listing the files, we can ignore this
                        }
                        else if (line.StartsWith("$ cd ") && !line.StartsWith("$ cd .."))
                        {

                            // changing to new subfolder
                            AoCDir newDir = ProcessSubdir(line);
                            newDir.Parent = currentDir;
                            currentDir.SubDirectories.Add(newDir);
                            currentDir = newDir;

                        }
                        else if (line.StartsWith("$ cd .."))
                        {
                            // create new subdir and add it to root
                            currentDir = currentDir.Parent;
                        }
                    }

                    else if (lineType.StartsWith("file"))
                    {
                        currentDir.Files.Add(ProcessFile(lineType));
                    }

                } while (!r.EndOfStream);

            }
            Console.WriteLine(DumpFiletree());
            Console.WriteLine($"Root: {_root.DirSize}");
            return res;
        }

        public void GetDirectorySizes()
        {
            
        }


        public string GetLineType(string line)
        {
            string res = "";

            // Command?
            res = line.Trim()[0] == '$' ? $"command {line.Substring(2)}" : res;
            res = line.Trim().StartsWith("dir") ? $"subdir {line.Substring(4)}" : res;
            res = (!line.Trim().StartsWith("dir") && line.Trim()[0] != '$') ? $"file {line}" : res;
            return res;
        }

        private void ProcessCommand(string command)
        {

        }

        private AoCDir ProcessSubdir(string subdir)
        {
            var res = new AoCDir();
            subdir = subdir.Replace("$ cd ", string.Empty);
            res.DirName = subdir;
            res.Files = new List<AoCFile>();
            res.SubDirectories = new List<AoCDir>();

            return res;
        }
        private AoCFile ProcessFile(string file)
        {
            var res = new AoCFile();
            var fileParts = file.Replace("file ", string.Empty).Split(" ");
            res.Size = int.Parse(fileParts[0]);
            res.Name = fileParts[1];

            return res;

        }
        
        private string DumpFiletree()
        {
            StringBuilder b = new StringBuilder();
            int indent = 0;

            b.Append(DumpDirectory(_root));

            return b.ToString();
        }
        
        private string DumpDirectory(AoCDir dir, int Indent=0)
        {
            StringBuilder b = new StringBuilder();

            b.AppendLine(dir.DirName.PadLeft(Indent));
            foreach(var subdir in dir.SubDirectories)
            {
                b.Append(DumpDirectory(subdir, Indent+2));
            }

            foreach(var file in dir.Files)
            {
                var fileName = DumpFile(file);
                fileName = fileName.PadLeft(fileName.Length + Indent-1, ' ');
                b.AppendLine(fileName);
            }

            return b.ToString();
        }

        private string DumpFile(AoCFile file)
        {
            return $"{file.Size} {file.Name}";
        }
        
        
        
    }
}
