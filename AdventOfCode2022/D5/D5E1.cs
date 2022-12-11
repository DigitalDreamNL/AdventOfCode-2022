using AdventOfCode2022.D5.Cranes;

namespace AdventOfCode2022.D5;

public class D5E1 : D5, IPuzzle
{
    public async Task<string> Solve() =>
        await Execute(new CrateMover9000());
}