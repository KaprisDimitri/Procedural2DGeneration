using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automata_Method
{
    public static class Utility_CelllularAuomataCaveGeneration
    {
        /*
         * REGLE:
         * 1. Remplir la grille aleatoirement
         * 2. Refaire un nombre d'iteration:
         * - La case devient un mur sur dans la region de 3X3 il y a 5 mur ou plus
        */

        private static Random _rand = new Random();
        public static List<int[,]> _iterations = new List<int[,]>();
        private static void RamdomlyFillGrid (ref Grid grid)
        {
            for(int x = 0; x < grid._grid.GetLength(0); x++)
            {
                for(int y = 0;  y < grid._grid.GetLength(1); y++)
                {
                    if (grid._grid[x,y] == -2) { continue; }
                    grid._grid[x, y] = _rand.Next(0, 2);
                }
            }
        }

        public static void CreateCaveMap (ref Grid grid, int iteration)
        {
            RamdomlyFillGrid(ref grid);
            int[,] toAdd = (int[,])grid._grid.Clone();
            _iterations.Add(toAdd);
            for (int i = 0; i<iteration;i++)
            {
                SetValuesOfCells(ref grid);
                 toAdd = (int[,])grid._grid.Clone(); 
                _iterations.Add(toAdd);
            }
        }

        private static void SetValuesOfCells (ref Grid grid)
        {
            for(int x = 0; x < grid._grid.GetLength(0); x++)
            {
                for(int y = 0; y < grid._grid.GetLength(1); y++)
                {
                    grid._grid[x,y] = CheckValueOfCell(grid, x, y);
                }
            }
        }

        private static int CheckValueOfCell (Grid grid, int xPos, int yPos)
        {
            int[,] neibourds = grid.GetNeibourds(xPos, yPos);

            int wallCount = 0;

            for(int x = 0; x < neibourds.GetLength(0); x++)
            {
                for (int y = 0; y < neibourds.GetLength(1); y++)
                {
                    if (neibourds[x,y] == 1 || neibourds[x, y] == - 1)
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount >= 5 ? 1 : 0;
        }
      
    }
}
