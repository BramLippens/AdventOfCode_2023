namespace AdventOfCode;

public class Day_05 : BaseDay
{
    private readonly string _input;

    public Day_05()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split("\n")
                          .Select(line => line.Trim())
                          .ToArray();
        return new($"");
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split("\n")
                           .Select(line => line.Trim())
                           .ToArray();

        return new($"");
    }
}
