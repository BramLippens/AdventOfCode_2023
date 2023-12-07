namespace AdventOfCode;

public class Day_04 : BaseDay
{
    private readonly string _input;

    public Day_04()
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

        Card currentCard;

        List<Card> cards = new List<Card>();

        for(int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(" | ");
            var currentCardNumber = int.Parse(lines[i].Substring("Card ".Length, lines[i].IndexOf(':') - "Card ".Length).Trim());

            if (!cards.Any(card => card.CardNumber == currentCardNumber))
            {
                currentCard = new Card { CardNumber = currentCardNumber, NumberOfCards = 1 };
                cards.Add(currentCard);
            }
            else
            {
                currentCard = cards.Find(card => card.CardNumber == currentCardNumber);
                currentCard.NumberOfCards++;
            }

            currentCard.GuessedNumbers = parts[1].Split(" ")
                                   .Where(s => !string.IsNullOrEmpty(s)) // Filter out empty strings
                                   .Select(int.Parse)
                                   .ToList();

            currentCard.WinningNumbers = parts[0].Split(":")[1].Split(" ")
                                   .Where(s => !string.IsNullOrEmpty(s)) // Filter out empty strings
                                   .Select(int.Parse)
                                   .ToList(); ;

            var cardsWon = currentCard.WinningNumbers.Intersect(currentCard.GuessedNumbers).ToList().Count;

            for (int k = 1; k <= currentCard.NumberOfCards; k++)
            {
                for (int j = 1; j <= cardsWon; j++)
                {
                    if (!cards.Any(card => card.CardNumber == currentCardNumber+j))
                    {
                        var newCard = new Card { CardNumber = currentCardNumber+j, NumberOfCards = 1};
                        cards.Add(newCard);
                    }
                    else
                    {
                        var foundCard = cards.Find(card => card.CardNumber == currentCardNumber + j);
                        foundCard.NumberOfCards++;
                    }
                }
            }
        }
        var sum = cards.Sum(card => card.NumberOfCards);
        return new($"{sum}");
    }
}

internal class Card
{
    public int CardNumber { get; set; }
    public List<int> WinningNumbers { get; set; }
    public List<int> GuessedNumbers { get; set; }
    public int NumberOfCards { get; set; }
}