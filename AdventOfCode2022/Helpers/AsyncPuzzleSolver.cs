using Spectre.Console;

namespace AdventOfCode2022.Helpers;

public class AsyncPuzzleSolver
{
    public async Task<T> Execute<T>(string title, Func<Action<double>, Task<T>> solver, bool? isIndeterminate = false)
    {
        var solution = default(T)!;

        var columns = new List<ProgressColumn>
        {
            new SpinnerColumn(),
            new TaskDescriptionColumn(), 
            new ProgressBarColumn()
        };

        if (isIndeterminate == false)
            columns.Add(new PercentageColumn());

        await AnsiConsole.Progress()
            .Columns(columns.ToArray())
            .StartAsync(async ctx =>
            {
                var task = ctx.AddTask(title);

                if (isIndeterminate == true)
                    task.IsIndeterminate();

                solution = await solver(progress => task.Value = progress);

                task.Value = 100;
            });

        return solution;
    }
}