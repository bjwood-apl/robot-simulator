using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic
{
    static class Board
    {
        internal const int MIN_POS = 0;
        internal const int MAX_POS = 5;

        internal static bool IsValidCoordinate(int x, int y)
        {
            return (x >= MIN_POS && x <= MAX_POS && y >= MIN_POS && y <= MAX_POS);
        }
    }
}
