using System;
using System.Collections.Generic;
using AdventOfCode2022.D11.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace AdventOfCode2022.Tests.D11;

public class MonkeyTests
{
    private Mock<IMonkey> _trueMonkey = null!;
    private Mock<IMonkey> _falseMonkey = null!;

    [Fact]
    public void TestMonkeyWithTimesOperationWithoutReducedWorryLevel()
    {
        var monkey = DefaultTestMonkey
            .WithOperation("old * old");
        var monkeys = SetupMonkeys(monkey);

        monkey.PerformTurn(monkeys);

        VerifyMonkeyWasCalledWithValue(_trueMonkey, 3, 2);
        VerifyMonkeyWasCalledWithValue(_falseMonkey, 1);
    }

    [Fact]
    public void TestMonkeyWithPlusOperationWithoutReducedWorryLevel()
    {
        var monkey = DefaultTestMonkey
            .WithOperation("old + old");
        var monkeys = SetupMonkeys(monkey);

        monkey.PerformTurn(monkeys);


        VerifyMonkeyWasCalledWithValue(_trueMonkey, 0, 2);
        VerifyMonkeyWasCalledWithValue(_falseMonkey, 4);
    }

    [Fact]
    public void TestMonkeyWithTimesOperationAndReducedWorryLevel()
    {
        var monkey = DefaultTestMonkey
            .WithOperation("old * old");
        monkey.EnableReduceWorryLevel();
        var monkeys = SetupMonkeys(monkey);

        monkey.PerformTurn(monkeys);

        VerifyMonkeyWasCalledWithValue(_trueMonkey, 3);
        VerifyMonkeyWasCalledWithValue(_trueMonkey, 675);
        VerifyMonkeyWasCalledWithValue(_falseMonkey, 40);
    }

    [Fact]
    public void TestMonkeyWithInvalidOperationSymbolThrows()
    {
        var monkey = DefaultTestMonkey
            .WithOperation("old - old");

        var monkeys = SetupMonkeys(monkey);

        var turn = () => monkey.PerformTurn(monkeys);
        turn.Should().Throw<Exception>();

    }

    private static IMonkey DefaultTestMonkey =>
        new Monkey()
            .WithItems(new List<ulong> {3, 45, 11})
            .WithTestValue(3)
            .WithTrueMonkeyTarget(0)
            .WithFalseMonkeyTarget(1);

    private List<IMonkey> SetupMonkeys(IMonkey monkey)
    {
        _trueMonkey = new Mock<IMonkey>();
        _trueMonkey.Setup(m => m.TestValue).Returns(1);
        _falseMonkey = new Mock<IMonkey>();
        _falseMonkey.Setup(m => m.TestValue).Returns(2);
        return new List<IMonkey>
        {
            _trueMonkey.Object,
            _falseMonkey.Object,
            monkey
        };
    }

    private static void VerifyMonkeyWasCalledWithValue(Mock<IMonkey> monkey, ulong value, int times = 1) =>
        monkey.Verify(m => m.CatchItem(It.Is<ulong>(i => i == value)), Times.Exactly(times));
}