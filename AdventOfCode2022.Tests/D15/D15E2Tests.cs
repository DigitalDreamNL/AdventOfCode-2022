using System.Threading.Tasks;
using AdventOfCode2022.D15;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D15;

public class D15E2Tests
{
    [Fact (Skip = "Does not finish for some reason (multiple threads/Spectre?)")]
    public async Task SolveTests()
    {
        var puzzle = new D15E2("D15/src/demo.txt", 10);
        var result = await puzzle.Solve();

        result.Should().Be("56000011");
    }

    [Fact (Skip = "Does not finish for some reason (multiple threads/Spectre?)")]
    public async Task SolveTestsWithRealInput()
    {
        var puzzle = new D15E2("D15/src/input.txt", 2000000);
        var result = await puzzle.Solve();

        result.Should().Be("12691026767556");
    }
}