using _20221204;

var i = new InputHelper("input\\input.txt");

var c = new Calculator();
Console.WriteLine($"Result 1: {c.CalculateResult(i.ElfAssignments)}");
Console.WriteLine($"Result 2: {c.CalculateResult2(i.ElfAssignments)}");
