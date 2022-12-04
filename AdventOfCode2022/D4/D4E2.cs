namespace AdventOfCode2022.D4;

public class D4E2 : D4, IPuzzle
{
    protected override bool Comparator(int[] edges) =>
        (edges[0] <= edges[2] && edges[2] <= edges[1])
        || (edges[2] <= edges[0] && edges[0] <= edges[3]);
}