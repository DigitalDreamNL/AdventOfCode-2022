using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode2022.D11;
using AdventOfCode2022.D11.Models;
using Moq;
using Xunit;

namespace AdventOfCode2022.Tests.D11;

public class InputParserTests
{
    private readonly List<ulong> _startingItems = new() {79, 98};
    private readonly string _operation = "old * 19";
    private const int TestValue = 23;
    private const int TrueMonkeyTarget = 2;
    private const int FalseMonkeyTarget = 3;

    [Fact]
    public async Task GivenValidInput_WhenCallingParse_CorrectMonkeyIsCreated()
    {
        var monkey = new Mock<IMonkey>();
        monkey.Setup(m => m.WithItems(It.IsAny<List<ulong>>())).Returns(monkey.Object);
        monkey.Setup(m => m.WithOperation(It.IsAny<string>())).Returns(monkey.Object);
        monkey.Setup(m => m.WithTestValue(It.IsAny<int>())).Returns(monkey.Object);
        monkey.Setup(m => m.WithTrueMonkeyTarget(It.IsAny<int>())).Returns(monkey.Object);
        monkey.Setup(m => m.WithFalseMonkeyTarget(It.IsAny<int>())).Returns(monkey.Object);

        using var sr = CreateInput();
        await MonkeyParser.Parse(sr, monkey.Object);

        var items = new List<ulong> {79, 98};
        monkey.Verify(m => m.WithItems(It.Is<List<ulong>>(i => items.TrueForAll(i.Contains))), Times.Once());
        monkey.Verify(m => m.WithOperation(It.Is<string>(s => s == _operation)), Times.Once());
        monkey.Verify(m => m.WithTestValue(It.Is<int>(v => v == TestValue)), Times.Once());
        monkey.Verify(m => m.WithTrueMonkeyTarget(It.Is<int>(v => v == TrueMonkeyTarget)), Times.Once());
        monkey.Verify(m => m.WithFalseMonkeyTarget(It.Is<int>(v => v == FalseMonkeyTarget)), Times.Once());
    }

    private StreamReader CreateInput()
    {
        var lines = new[] {
            "Monkey 0:",
            $"  Starting items: {string.Join(", ", _startingItems)}",
            $"  Operation: new = {_operation}",
            $"  Test: divisible by {TestValue}",
            $"    If true: throw to monkey {TrueMonkeyTarget}",
            $"    If false: throw to monkey {FalseMonkeyTarget}"
        };

        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        foreach (var line in lines)
            writer.Write(line + Environment.NewLine);
        writer.Flush();
        stream.Position = 0;
        return new StreamReader(stream);
    }
}