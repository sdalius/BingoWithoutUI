using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoWithoutUI
{
    public interface IBingoCard
    {
        int[,] Get_TwoDimensionalNumberArray();
        int GetSizeOfACard();
        void SetMaxPoints();
        void AddPoints(int points);
        int GetPoints();
        void GenerateBingoCardNumbers(int max_number);
    }
}
