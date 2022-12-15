using AdventOfCode2022.D13;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.D13;

public class PacketSorterTests
{
    [Fact]
    public void CpmpareIntegerPackets()
    {
        new PacketSorter()
            .Compare("[1,1,3,1,1]", "[1,1,5,1,1]")
            .Should().BeTrue();
    }

    [Fact]
    public void ComnpareChunkPackets()
    {
        new PacketSorter()
            .Compare("[[1]]", "[[2]]")
            .Should().BeTrue();
    }

    [Fact]
    public void CompareMixedPackets()
    {
        new PacketSorter()
            .Compare("[[1]]", "[2]")
            .Should().BeTrue();

        new PacketSorter()
            .Compare("[1]", "[[2]]")
            .Should().BeTrue();
    }

    [Fact]
    public void CompareUnequalLengthPackets()
    {
        new PacketSorter()
            .Compare("[1,2]", "[1,2,3]")
            .Should().BeTrue();

        new PacketSorter()
            .Compare("[1,2,3]", "[1,2]")
            .Should().BeFalse();
    }
}