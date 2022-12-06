namespace AdventOfCode2022.D5.Cranes;

public class CrateMover9001 : Crane
{
    protected override int DetermineCratePosition(int i) => i - 1;
}