using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automata_Method
{
    public class Grid
    {
        public int[,] _grid;

        private int _width;
        private int _height;

        public Grid (int width, int height)
        {
            _width = width;
            _height = height;
            _grid = new int[width, height];
        }

        public int GetCell(int xPos, int yPos)
        {
            if (xPos < 0 || xPos >= _grid.GetLength(0) || yPos < 0 || yPos >= _grid.GetLength(1)) { return -1; }

            return _grid[xPos, yPos];
        }

        public int[,] GetNeibourds(int xPos, int yPos, int width = 1)
        {
            if (width <= 0)
            {
                width = 1;
            }

            int[,] toReturn = new int[1 + 2 * width, 1 + 2 * width];

            for (int x = 0; x < toReturn.GetLength(0); x++)
            {
                for (int y = 0; y < toReturn.GetLength(1); y++)
                {
                    toReturn[x, y] = GetCell(xPos + x - 1, yPos + y - 1);
                }
            }

            return toReturn;
        }
    }
}

