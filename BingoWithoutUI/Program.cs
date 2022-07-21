// See https://aka.ms/new-console-template for more information
using BingoWithoutUI;

const int POINTS_FOR_ROW = 100;

BingoCard card = new BingoCard(5,3);
BingoGame game = new BingoGame(60);

card.GenerateBingoCardNumbers(60);
var drawnBalls = game.DrawBalls();

Debug();
CheckScore();

void Debug()
{
    var cardNumbers = card.Get_TwoDimensionalNumberArray();

    for (int i = 0; i < cardNumbers.GetLength(0); i++)
    {
        for (int j = 0; j < cardNumbers.GetLength(1); j++)
        {
            Console.Write(String.Format("{0}\t", cardNumbers[i, j]));
        }
        Console.WriteLine();
    }

    Console.WriteLine("LETS DRAW SOME BALLZ");


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
    int j = 0;
    int howManyNumbersHaveMatched = 0;
    int howManyRowNumbersHaveMatched = 0 ;


    for (int i = 0; i < cardNumbers.GetLength(0); i++)
    {
        while (j < cardNumbers.GetLength(1))
        {
            if (drawnBalls.Contains(cardNumbers[i,j]))
            {
                Console.WriteLine("Matched one!, Continue {0}", cardNumbers[i, j]);
                howManyRowNumbersHaveMatched++;
                howManyNumbersHaveMatched++;
            }
            j++;
        }

        if (howManyRowNumbersHaveMatched == 5)
        {
            AddPointsForRow();
            howManyRowNumbersHaveMatched = 0;
            Console.WriteLine(card.points);
        }
        else if(howManyNumbersHaveMatched == 15)
        {
            SetMaxPoints();
            Console.WriteLine(card.points);
        }
        else
        {
            howManyRowNumbersHaveMatched = 0;
            j = 0;
        }
        Console.WriteLine();
    }
}

void AddPointsForRow()
{
    card.AddPoints(POINTS_FOR_ROW);
}

void SetMaxPoints()
{
    card.SetMaxPoints();
}

