using System.Collections.Generic;
using AdventOfCode2022.D14;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D14;

public class SandSimTests
{
    private List<string> _rockPaths = new()
    {
        "2,2 -> 2,3",
        "3,1 -> 3,0 -> 4,0 -> 4,4"
    };

    [Fact]
    public void ParseLineTests()
    {
        var result = SandSim.ParsePath(_rockPaths[1]);

        var expected = new List<Vector2>
        {
            new(3, 1),
            new(3, 0),
            new(4, 0),
            new(4, 4)
        };

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }
}