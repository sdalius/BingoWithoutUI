using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoWithoutUI
{
    public class BingoCard
    {
        const int BALLS_SMALLEST_NUMBER = 1;

        public int points;
        public int rows { get; private set; }
        public int columns { get; private set; }

        int[] number_array;
        int[,] Two_Dimensional_number_array;

        public BingoCard ( int columns, int rows)
        {
            this.rows = rows;
            this.columns = columns;
            points = 0;
        }

        public int[,] Get_TwoDimensionalNumberArray()
        {
            return Two_Dimensional_number_array;
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }

        public void SetMaxPoints()
        {
            this.points = 1500;
        }
        public void GenerateBingoCardNumbers(int max_number)
        {
            int size_of_a_card = rows * columns;
            
            Random random = new Random();
            Two_Dimensional_number_array = new int[rows, columns];

            number_array = Enumerable.Range(1, max_number)
                            .OrderBy(query => random.Next(BALLS_SMALLEST_NUMBER, max_number)).Take(size_of_a_card)
                            .Distinct()
                            .ToArray()
                            .OrderBy(i => i)
                            .ToArray();


            for (int i = 0; i < Two_Dimensional_number_array.GetLength(0); i++)
            {
                for (int j = 0; j < Two_Dimensional_number_array.GetLength(1); j++)
                {
                    Two_Dimensional_number_array[i, j] = number_array[i * columns + j];
                }
            }
        }
    }
}
