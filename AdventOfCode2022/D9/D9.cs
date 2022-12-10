using AdventOfCode2022.D9.Models;

namespace AdventOfCode2022.D9;

public abstract class D9 : IPuzzle
{
    protected abstract int RopeLength { get; }
    
    public async Task<string> Execute()
    {
        var rope = new Rope(RopeLength);
        
        using var sr = new StreamReader("D9/src/input.txt");
        while (!sr.EndOfStream)
        {
            var parts = (await sr.ReadLineAsync())!.Split(" ");
            var moves = int.Parse(parts[1]);
            while (moves > 0)
            {
                rope.Move(parts[0]);
                moves--;
            }
        }

        return rope.UniquePositionsVisitedByTail.ToString();
    }
}