using AoC20221206;

var i = new InputHelper("input\\input.txt");
var lines = i.ProcessInputFile();

var c = new Calculator();
foreach(string line in lines)
{
    Console.WriteLine($"{line}: {c.ProcessLine(line)}");
    Console.WriteLine($"Result 2: {c.ProcessLine2(line)}");
}
