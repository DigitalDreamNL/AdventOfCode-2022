namespace AdventOfCode2022.D5.Models;

public class Instruction
{
    public int NumberOfCrates { get; private init; }
    public int FromStack { get; private init; }
    public int ToStack { get; private init; }

    public static Instruction CreateFromLine(string line)
    {
        var split = line.Split(" ");
        return new Instruction
        {
            NumberOfCrates = int.Parse(split[1]),
            FromStack = int.Parse(split[3]) - 1,
            ToStack = int.Parse(split[5]) - 1,
        };
    }
}