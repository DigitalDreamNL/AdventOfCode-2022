namespace AdventOfCode2022.D14;

public class D14E1 : D14, IPuzzle
{
    private readonly string _inputFile;
    
    public D14E1(string inputFile = "D14/src/input.txt")
    {
        _inputFile = inputFile;
    }


    public async Task<string> Solve()
    {
        return await SandSim.Simulate(_inputFile, false);
    }
}