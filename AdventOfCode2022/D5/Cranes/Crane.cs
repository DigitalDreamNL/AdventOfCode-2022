using AdventOfCode2022.D5.Models;

namespace AdventOfCode2022.D5.Cranes;

public abstract class Crane
{
    protected abstract int DetermineCratePosition(int i);

    public void PerformInstructions(List<Instruction> instructions, List<List<char>> stacks)
        => instructions.ForEach(instruction => PerformInstruction(instruction, stacks));

    private void PerformInstruction(Instruction instruction, List<List<char>> stacks)
    {
        var numberOfCratesRemaining = instruction.NumberOfCrates;
        while (numberOfCratesRemaining > 0)
        {
            MoveCrate(instruction, stacks, numberOfCratesRemaining);
            numberOfCratesRemaining--;
        }
    }

    private void MoveCrate(Instruction instruction, List<List<char>> stacks, int numberOfCratesRemaining)
    {
        var cratePosition = DetermineCratePosition(numberOfCratesRemaining);
        var crateToMove = stacks.ElementAt(instruction.FromStack).ElementAt(cratePosition);
        stacks.ElementAt(instruction.FromStack).RemoveAt(cratePosition);
        stacks.ElementAt(instruction.ToStack).Insert(0, crateToMove);
    }
}