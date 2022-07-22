namespace BingoWithoutUI
{
    public class BingoCard : IBingoCard
    {
        const int BALLS_SMALLEST_NUMBER = 1;

        const int MAX_POINTS = 1500;
        public int points { get; private set; }
        public int rows { get; private set; }
        public int columns { get; private set; }

        int[] generated_numbers_for_card;

        int[,] Two_Dimensional_generated_numbers_for_card;

        public BingoCard(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            points = 0;
        }

        public int[,] Get_TwoDimensionalNumberArray()
        {
            return Two_Dimensional_generated_numbers_for_card;
        }
        public int GetSizeOfACard()
        {
            return rows * columns;
        }
        public void SetMaxPoints()
        {
            this.points = MAX_POINTS;
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }

        public int GetPoints()
        {
            return points;
        }

        public void GenerateBingoCardNumbers(int max_number)
        {
            int size_of_a_card = rows * columns;
            
            Random random = new Random();

            Two_Dimensional_generated_numbers_for_card = new int[rows, columns];

            generated_numbers_for_card = Enumerable.Range(1, max_number)
                            .OrderBy(query => random.Next(BALLS_SMALLEST_NUMBER, max_number)).Take(size_of_a_card)
                            .ToArray()
                            .OrderBy(i => i)
                            .ToArray();


            for (int column = 0; column < Two_Dimensional_generated_numbers_for_card.GetLength(1); column++)
            {
                for (int row = 0; row < Two_Dimensional_generated_numbers_for_card.GetLength(0); row++)
                {
                    Two_Dimensional_generated_numbers_for_card[row, column] = generated_numbers_for_card[column * rows + row];
                }
            }
        }
    }
}
