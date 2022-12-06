using AdventOfCode2022.D5.Cranes;
using AdventOfCode2022.D5.Models;

namespace AdventOfCode2022.D5;

public abstract class D5
{
    private const string InputPath = "D5/src/input.txt";
    private int _numberOfStacks;
    private readonly List<List<char>> _stacks = new();
    private readonly List<Instruction> _instructions = new();

    protected async Task<string> Execute(Crane crane)
    {
        await DetermineNumberOfStacks();
        InitializeStacks();
        await ReadInput();
        PerformInstructions(crane);
        return TakeTopCrateFromEachStack();
    }

    private async Task DetermineNumberOfStacks()
    {
        using var sr = new StreamReader(InputPath);
        var firstLine = (await sr.ReadLineAsync())!;
        _numberOfStacks = (firstLine.Length + 1) / 4;
    }

    private void InitializeStacks()
    {
        for (var stack = 0; stack < _numberOfStacks; stack++)
            _stacks.Add(new List<char>());
    }

    private async Task ReadInput()
    {
        using var sr = new StreamReader(InputPath);
        while (!sr.EndOfStream)
            await ParseLine(sr);
    }

    private async Task ParseLine(TextReader sr)
    {
        var line = await sr.ReadLineAsync();

        if (string.IsNullOrEmpty(line))
            return;

        if (line[0] == '[')
            ParseCrates(line);
        else if (line[0] == 'm')
            ParseInstructions(line);
    }

    private void ParseCrates(string line)
    {
        for (var stack = 0; stack < _numberOfStacks; stack++)
            AddCrateToStack(line, stack);
    }

    private void AddCrateToStack(string line, int stack)
    {
        var crate = line[stack * 4 + 1];
        if (crate == ' ') return;
        _stacks.ElementAt(stack).Add(crate);
    }

    private void ParseInstructions(string line) => _instructions.Add(Instruction.CreateFromLine(line));

    private void PerformInstructions(Crane crane)
        => crane.PerformInstructions(_instructions, _stacks);

    private string TakeTopCrateFromEachStack() => string.Join("", _stacks.Select(stack => stack.First()));
}