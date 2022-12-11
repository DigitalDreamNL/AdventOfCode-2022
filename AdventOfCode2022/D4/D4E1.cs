namespace AdventOfCode2022.D4;

public class D4E1 : D4
{
    protected override bool Comparator(int[] edges) =>
        (edges[0] <= edges[2] && edges[1] >= edges[3])
        || (edges[0] >= edges[2] && edges[1] <= edges[3]);
}