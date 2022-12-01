using _20221201;
using Microsoft.VisualBasic.FileIO;
using System.IO;

const string inFile = "input\\input.txt";
Processor proc = new Processor(inFile);

var elves = proc.ProcessFile();

var highest = elves.Max(e2 => e2.GetCalorieSum());
proc.DumpElves(elves);
Console.WriteLine($"highest: {highest}");

proc.ListTopXElves(elves, 3);