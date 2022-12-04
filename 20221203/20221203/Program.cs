using _20221203;

Calculator c = new Calculator();
InputHelper i = new InputHelper("input\\input.txt");
Console.WriteLine($"result 1: { c.CalculateScore1(i.InputLiness)}");
Console.WriteLine($"result 2: { c.CalculateScore2(i.InputLiness)}");