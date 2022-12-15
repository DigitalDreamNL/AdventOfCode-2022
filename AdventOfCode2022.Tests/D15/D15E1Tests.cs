using System.Threading.Tasks;
using AdventOfCode2022.D15;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D15;

public class D15E1Tests
{
    [Fact]
    public async Task SolveTests()
    {
        var puzzle = new D15E1("D15/src/demo.txt", 10);
        var result = await puzzle.Solve();

        result.Should().Be("26");
    }

    [Fact]
    public async Task SolveTestsWithRealInput()
    {
        var puzzle = new D15E1("D15/src/input.txt", 2000000);
        var result = await puzzle.Solve();

        result.Should().Be("4883971");
    }
}