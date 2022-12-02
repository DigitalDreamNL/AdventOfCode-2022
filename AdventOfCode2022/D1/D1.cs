namespace AdventOfCode2022.D1;

public class D1
{
    private int _currentElfCalories;
    private readonly List<int> _elves = new();

    protected async Task<string> Execute(int numberOfElves)
    {
        using var sr = new StreamReader("D1/src/input.txt");
        while (!sr.EndOfStream)
            HandleLine((await sr.ReadLineAsync())!);

        return _elves
            .OrderByDescending(i => i)
            .Take(numberOfElves)
            .Sum()
            .ToString();
    }

    private void HandleLine(string value)
    {
        if (value == "")
        {
            FinalizeElf();
        }
        else
        {
            AddCaloriesToCurrentElf(value);
        }
    }

    private void FinalizeElf()
    {
        _elves.Add(_currentElfCalories);
        _currentElfCalories = 0;
    }

    private void AddCaloriesToCurrentElf(string value)
    {
        _currentElfCalories += int.Parse(value);
    }
}