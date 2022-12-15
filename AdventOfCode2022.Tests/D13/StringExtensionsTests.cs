using System;
using AdventOfCode2022.D13;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D13;

public class StringExtensionsTests
{
    [Fact]
    public void StringOverrides()
    {
        var act = () => "".SelectNextSymbol();
        act.Should().Throw<Exception>();
        
        "[".SelectNextSymbol().Should().Be("[");
        "]".SelectNextSymbol().Should().Be("]");
        ",".SelectNextSymbol().Should().Be(",");
        
        "5".SelectNextSymbol().Should().Be("5");
        "5,".SelectNextSymbol().Should().Be("5");
        "10,".SelectNextSymbol().Should().Be("10");
        "1],".SelectNextSymbol().Should().Be("1");
        "1,,".SelectNextSymbol().Should().Be("1");
        
        "10".IsDigit().Should().BeTrue();
        "1".IsDigit().Should().BeTrue();
        "[".IsDigit().Should().BeFalse();
        ",".IsDigit().Should().BeFalse();
        
        "10".IsChunkStart().Should().BeFalse();
        "1".IsChunkStart().Should().BeFalse();
        "[".IsChunkStart().Should().BeTrue();
        ",".IsChunkStart().Should().BeFalse();
        
        "10".ToInt().Should().Be(10);
        
        "10".IsLargerThan("5").Should().BeTrue();
        "10".IsLargerThan("10").Should().BeFalse();
        "5".IsSmallerThan("5").Should().BeFalse();
        "5".IsSmallerThan("10").Should().BeTrue();

        "12,5]".RemoveCurrentSymbol().Should().Be(",5]");
        "[4]".RemoveCurrentSymbol().Should().Be("4]");
        ",3]".RemoveCurrentSymbol().Should().Be("3]");
        
        
        "[[],1,2,[3]],[2]".SelectNextChunk().Should().Be("[[],1,2,[3]]");

        "[[],[1,1,2,3],1,[],2,[3]],[2],[[],5,6,[]".SelectNextChunk().Should().Be("[[],[1,1,2,3],1,[],2,[3]]");
    }
}