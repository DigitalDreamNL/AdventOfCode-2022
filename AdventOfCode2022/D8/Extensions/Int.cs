namespace AdventOfCode2022.D8.Extensions;

public static class Int
{
    public static bool CannotSeePast(this int self, int other) => self <= other;
}