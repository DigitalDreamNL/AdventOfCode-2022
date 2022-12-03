namespace AdventOfCode2022.D3;

public class D3
{
    protected int SumOfPriorities = 0;
    
    protected static int CalculatePriority(char item) 
        => item > 96 ? item - 96 : item - 38;
}