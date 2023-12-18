using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid_Methods
{
    public class GridBase<T>
    {
        private T[,] _grid;

        private int _width;
        private int _height;

        private T _errorValue;
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        public GridBase(int width, int height, T errorValue)
        {
            _errorValue = errorValue;
            _width = width;
            _height = height;
            _grid = new T[_width, _height];
        }

        public bool IsInGrid (int xPos, int yPos)
        {
            return xPos >= 0 || xPos < _grid.GetLength(0) || yPos >= 0 || yPos < _grid.GetLength(1);
        }

        public T GetCell(int xPos, int yPos)
        {
            if (!IsInGrid(xPos, yPos)) { return _errorValue; }

            return _grid[xPos, yPos];
        }

        public T[,] GetNeibourds(int xPos, int yPos, int width = 1)
        {
            if(!IsInGrid(xPos, yPos)) { return new T[1, 1] { { _errorValue } }; }

            if (width <= 0)
            {
                width = 1;
            }

            T[,] toReturn = new T[1 + 2 * width, 1 + 2 * width];

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
