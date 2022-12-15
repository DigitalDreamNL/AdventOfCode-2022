using System.Linq;
using AdventOfCode2022.D14;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D15;

public class D15Tests
{
    private readonly string _line = "Sensor at x=8, y=7: closest beacon is at x=2, y=10";
    
    [Fact]
    public void ParseTests()
    {
        var positions = AdventOfCode2022.D15.D15.Parse(_line);

        positions.Count.Should().Be(2);
        
        var sensor = positions.First();
        sensor.Should().BeEquivalentTo(new Vector2(8, 7));
        
        var beacon = positions.Last();
        beacon.Should().BeEquivalentTo(new Vector2(2, 10));
    }

    [Fact]
    public void CalculateManhattanDistanceTests()
    {
        var positions = AdventOfCode2022.D15.D15.Parse(_line);

        var distance = AdventOfCode2022.D15.D15.CalculateManhattanDistance(positions);

        distance.Should().Be(9);
    }

    [Theory]
    [InlineData("Sensor at x=16, y=7: closest beacon is at x=15, y=3", 14, 18)]
    [InlineData("Sensor at x=2, y=0: closest beacon is at x=2, y=10", 2, 2)]
    [InlineData("Sensor at x=8, y=7: closest beacon is at x=2, y=10", 2, 14)]
    public void CalculateLimitsOnLineTests(string line, int lowerBound, int upperBound)
    {
        var positions = AdventOfCode2022.D15.D15.Parse(line);
        
        var limits = AdventOfCode2022.D15.D15.CalculateLimitsOnLine(positions, 10);
        
        limits.Count.Should().Be(2);
        limits[0].Should().Be(lowerBound);
        limits[1].Should().Be(upperBound);
    }
    
}