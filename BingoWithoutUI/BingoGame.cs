using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoWithoutUI
{
    public class BingoGame
    {
        Guid game_id = Guid.NewGuid();
        const int BALLS_SMALLEST_NUMBER = 1;
        const int DIVISON_OF_MAX_NUMBER = 2;
        int max_number;

        int[] number_array;

        public BingoGame (int max_number)
        {
            this.max_number = max_number;
        }

        public List<int> DrawBalls()
        {
            Random random = new Random();

            number_array = Enumerable.Range(1, max_number)
                            .OrderBy(query => random.Next(BALLS_SMALLEST_NUMBER, max_number)).Take(max_number / DIVISON_OF_MAX_NUMBER)
                            .Distinct()
                            .ToArray()
                            .OrderBy(i => i)
                            .ToArray();

            return number_array.ToList();
        }
    }
}
