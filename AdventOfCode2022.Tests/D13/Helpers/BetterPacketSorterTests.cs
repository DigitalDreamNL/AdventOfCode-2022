using System.Collections.Generic;
using AdventOfCode2022.D13.Helpers;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D13.Helpers;

public class BetterPacketSorterTests
{
    [Fact]
    public void Parse()
    {
        var input = "[[],1,[2,3,4],[[5,6]],7,8,10,9]";
        var expected = new List<string>
        {
            "[", "[", "]", ",", "1", ",", "[", "2", ",", "3", ",", "4", "]", ",", "[", "[", "5", ",", "6", "]", "]",
            ",", "7", ",", "8", ",", "10", ",", "9", "]"
        };
        BetterPacketSorter.Parse(input).Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Fact]
    public void Constructor()
    {
        var left = "[[],1,[2,3,4],[[5,6]],7,8,10,9]";
        var right = "[[],1,[2,3,4],[[5,6]],7,8,10,9]";
        var sorter = new BetterPacketSorter(left, right);

        var expected = new List<string>
        {
            "[", "[", "]", ",", "1", ",", "[", "2", ",", "3", ",", "4", "]", ",", "[", "[", "5", ",", "6", "]", "]",
            ",", "7", ",", "8", ",", "10", ",", "9", "]"
        };
        
        sorter.ChunksLeft.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        sorter.ChunksRight.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Theory]
    [InlineData("[[]]", "[]")]
    [InlineData("[[1,3,[],[4]],5]", "[1,3,[],[4]]")]
    [InlineData("[[1],5]", "[1]")]
    public void NextChunk(string input, string expected)
    {
        var chunk = BetterPacketSorter.Parse(input);
        var result = BetterPacketSorter.NextChunk(chunk, 1);
        result.Should().BeEquivalentTo(BetterPacketSorter.Parse(expected), options => options.WithStrictOrdering());
    }

    [Fact]
    public void Compare()
    {
        var left = "[1]";
        var right = "[2]";
        var sorter = new BetterPacketSorter(left, right);

    }
}