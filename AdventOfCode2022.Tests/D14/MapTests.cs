using System;
using System.Collections.Generic;
using AdventOfCode2022.D14;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D14;

public class MapTests
{
    private List<string> _paths = new()
    {
        "2,2 -> 2,3",
        "3,1 -> 3,0 -> 4,0 -> 4,4"
    };
    [Fact]
    public void DetermineBounds()
    {
        var paths = SandSim.ParsePaths(_paths);
        var bounds = Map.DetermineBounds(paths);

        bounds.Min.Should().BeEquivalentTo(new Vector2(2, 0));
        bounds.Max.Should().BeEquivalentTo(new Vector2(4, 4));
    }
    
    [Fact]
    public void CreateMap()
    {
        var paths = SandSim.ParsePaths(_paths);
    
        var map = Map.From(paths);

        var expectedMap = new List<string>
        {
            ".....",
            ".....",
            "..██.",
            "██...",
            "█████",
        };

        for (var x = 0; x <=3; x++)
        {
            for (var y = 0; y <= 4; y++)
            {
                var actual = map.Squares[x,y];
                var expected = expectedMap[x][y];
                actual.Should().Be(expected.ToSquareType());
            }
        }
    }

}