using Spectre.Console;

namespace AdventOfCode2022.Helpers;

public static class Ask
{
    public static string MultipleChoiceQuestion(string title, List<string> choices, string? moreChoicesText = null)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText(moreChoicesText)
                .AddChoices(choices)
                .HighlightStyle(new Style(Color.Green)));
    }
}