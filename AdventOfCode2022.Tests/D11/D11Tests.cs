using System.Threading.Tasks;
using AdventOfCode2022.D11;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D11;

public class D11Tests
{
    [Fact]
    public async Task Puzzle1()
    {
        var puzzle = new D11E1();
        (await puzzle.Solve()).Should().Be("58786");
    }

    [Fact]
    public async Task Puzzle2()
    {
        var puzzle = new D11E2();
        (await puzzle.Solve()).Should().Be("14952185856");
    }
}