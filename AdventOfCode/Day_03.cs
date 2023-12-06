using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly string _input;

    public Day_03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split("\n")
                          .Select(line => line.Trim())
                          .ToArray();
        var sum = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            MatchCollection matches = Regex.Matches(line, @"\d+");

            foreach (Match match in matches)
            {
                int number = int.Parse(match.Value);
                var startIndexNumber = match.Index;
                var endIndexNumber = match.Index + match.Length-1;
                var lengthNumber = match.Length;

                var YIndexSearch = i - 1;
                var XIndexSearch = startIndexNumber - 1;
                for (int Y = YIndexSearch; Y <= YIndexSearch + 2; Y++)
                {
                    if(Y < 0 ||  Y >= lines.Length)
                    {
                        continue;
                    }
                    for (int X = XIndexSearch; X <= XIndexSearch + lengthNumber + 1; X++)
                    {
                        if (X < 0 || X > lines[Y].Length - 1)
                        {
                            continue;
                        }
                        var currentChar = lines[Y][X];

                        if(!char.IsDigit(currentChar)&&currentChar!= '.')
                        {
                            sum += number;
                            break;
                        }
                    }
                }
            }
        }

        return new($"{sum}");
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split("\n")
                          .Select(line => line.Trim())
                          .ToArray();
        Dictionary<(int,int),List<int>> parts = new();
        var product = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            MatchCollection matches = Regex.Matches(line, @"\d+");

            foreach (Match match in matches)
            {
                int number = int.Parse(match.Value);
                var startIndexNumber = match.Index;
                var endIndexNumber = match.Index + match.Length - 1;
                var lengthNumber = match.Length;

                var YIndexSearch = i - 1;
                var XIndexSearch = startIndexNumber - 1;
                for (int Y = YIndexSearch; Y <= YIndexSearch + 2; Y++)
                {
                    if (Y < 0 || Y >= lines.Length)
                    {
                        continue;
                    }
                    for (int X = XIndexSearch; X <= XIndexSearch + lengthNumber + 1; X++)
                    {
                        if (X < 0 || X > lines[Y].Length - 1)
                        {
                            continue;
                        }
                        var currentChar = lines[Y][X];

                        if (!char.IsDigit(currentChar) && currentChar == '*')
                        {
                            if(!parts.ContainsKey((X,Y)))
                            {
                                parts.Add((X, Y), new());
                            }
                            parts[(X, Y)].Add(number);
                            break;
                        }
                    }
                }
            }
        }

        foreach (var part in parts)
        {
            if(part.Value.Count == 2)
            {
                product += part.Value[0] * part.Value[1];
            }
        }

        return new($"{product}");
    }
}
