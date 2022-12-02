using _20221202;
using System.Data;

const string inFile = "input\\input.txt";
var result = new Result();

var processor = new Processor(inFile, result);
Console.Write(processor.CalculateResult2());




