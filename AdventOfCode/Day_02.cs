namespace AdventOfCode
{
    public class Day_02: BaseDay
    {
        private readonly string _input;
        public Day_02()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            var lines = _input.Split("\n");
            var sum = 0;
            var bag = new List<KeyValuePair<string, int>>
            {
                new("red", 12),
                new("green", 13),
                new("blue", 14),
            };



            foreach (var line in lines)
            {
                var gameId = line.Split(":")[0].Split(" ")[1];
                var sets = line.Split(":")[1].Split(";");
                var impossible = false;
                foreach (var set in sets)
                {
                    var cubesPerSet = set.Split(",");
                    foreach(var cube in cubesPerSet)
                    {
                        var color = cube.Trim().Split(" ")[1];
                        var count = int.Parse(cube.Trim().Split(" ")[0]);

                        var bagItem = bag.FirstOrDefault(x => x.Key == color);
                        if (bagItem.Key != null && bagItem.Value < count)
                        {
                            impossible = true;
                        }
                    }
                }
                if (!impossible)
                {
                    sum += int.Parse(gameId);
                }

            }

            return new($"{sum}");
        }

        public override ValueTask<string> Solve_2()
        {
            var lines = _input.Split("\n");
            var sum = 0;
            var product = 1;
            

            foreach (var line in lines)
            {
                var bag = new List<KeyValuePair<string, int>>
                {
                    new("red", int.MinValue),
                    new("green", int.MinValue),
                    new("blue", int.MinValue),
                };
                var gameId = line.Split(":")[0].Split(" ")[1];
                var sets = line.Split(":")[1].Split(";");
                foreach (var set in sets)
                {
                    var cubesPerSet = set.Split(",");
                    foreach (var cube in cubesPerSet)
                    {
                        var color = cube.Trim().Split(" ")[1];
                        var count = int.Parse(cube.Trim().Split(" ")[0]);

                        var bagItem = bag.FirstOrDefault(x => x.Key == color);
                        if (bagItem.Key != null && bagItem.Value < count)
                        {
                            bag[bag.IndexOf(bagItem)] = new(color, count);
                        }
                    }
                }
                foreach (var bagItem in bag)
                {
                    product *= bagItem.Value;
                }

                sum += product;
                product = 1;

            }

            return new($"{sum}");
        }
    }
}