using BingoWithoutUI;

const int POINTS_FOR_ROW = 100;

IBingoCard card = new BingoCard(3,5);
IBingoGame game = new BingoGame(60);

card.GenerateBingoCardNumbers(60);
var drawnBalls = game.DrawBalls();

DisplayNumbers();
CheckScore();

void DisplayNumbers()
{
    var cardNumbers = card.Get_TwoDimensionalNumberArray();

    Console.WriteLine("--Your bingo card--");

    for (int row = 0; row < cardNumbers.GetLength(0); row++)
    {
        for (int column = 0; column < cardNumbers.GetLength(1); column++)
        {
            Console.Write(String.Format("{0}\t", cardNumbers[row, column]));
        }
        Console.WriteLine();
    }

    Console.WriteLine("--Drawing numbers--");

    for (int i = 0; i < drawnBalls.Count; i++)
    {
        Console.Write(drawnBalls[i] + "\t");

        if (i+1 == drawnBalls.Count)
        {
            Console.WriteLine();
        }
    }
}

void CheckScore()
{
    var cardNumbers = card.Get_TwoDimensionalNumberArray();
    int column = 0;
    int howManyNumbersHaveMatched = 0;
    int howManyRowNumbersHaveMatched = 0 ;
    int size_of_a_card = card.GetSizeOfACard();

    for (int row = 0; row < cardNumbers.GetLength(0); row++)
    {
        while (column < cardNumbers.GetLength(1))
        {
            if (drawnBalls.Contains(cardNumbers[row, column]))
            {
                howManyRowNumbersHaveMatched++;
                howManyNumbersHaveMatched++;
            }
            column++;
        }

        if (howManyRowNumbersHaveMatched == cardNumbers.GetLength(1))
        {
            card.AddPoints(POINTS_FOR_ROW);
            howManyRowNumbersHaveMatched = 0;
        }
        else if(howManyNumbersHaveMatched == size_of_a_card)
        {
            card.SetMaxPoints();
        }
        else
        {
            howManyRowNumbersHaveMatched = 0;
            column = 0;
        }
    }
    Console.WriteLine("Your score: " + card.GetPoints());
}

