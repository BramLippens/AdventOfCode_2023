namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly string _input;

    public Day_01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split("\n");
        var sum = 0;

        foreach (var line in lines)
        {
            var left = FindFirstDigit(line);
            var reversed = new string(line.Reverse().ToArray());
            var right = FindFirstDigit(reversed);

            // merge the two digits
            var digit = int.Parse($"{left}{right}");
            sum += digit;
        }

        return new($"{sum}");
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split("\n");
        var sum = 0;
        Dictionary<string, int> OneToNine = new()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
            {"1", 1},
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9}
        };

        foreach (var line in lines)
        {
            KeyValuePair<string, int> firstDigit = new("", int.MaxValue);
            KeyValuePair<string, int> secondDigit = new("", int.MinValue);
            foreach (var target in OneToNine.Keys)
            {
                var firstIndex = line.IndexOf(target,StringComparison.OrdinalIgnoreCase);
                var lastIndex = line.LastIndexOf(target,StringComparison.OrdinalIgnoreCase);
                if(firstIndex != -1 && firstDigit.Value > firstIndex)
                {
                    firstDigit = new(target, firstIndex);
                }
                if(lastIndex != -1 && secondDigit.Value < lastIndex)
                {
                    secondDigit = new(target, lastIndex);
                }
            }

            var digit = int.Parse($"{OneToNine[firstDigit.Key]}{OneToNine[secondDigit.Key]}");
            sum+= digit;
        }

        return new($"{sum}");
    }


    static char FindFirstDigit(string input)
    {
        foreach (var c in input)
        {
            if (char.IsDigit(c))
            {
                return c;
            }
        }

        return '\0';
    }
}
