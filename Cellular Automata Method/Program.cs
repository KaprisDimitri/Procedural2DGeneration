// See https://aka.ms/new-console-template for more information
using Cellular_Automata_Method;
Console.WriteLine("Hello, World!");

Grid _grid;
int width = 100;
int height = 100;

float amplitude = 1f;
float frequency = 5f;

float amplitudeMountane = 25;
float frequencyMountane = 50f;

float amplitudeHill = 5;
float frequencyHill = 20f;

_grid = new Grid(width, height);

for(int x = 0; x<_grid._grid.GetLength(0); x++)
{
    int yRef = (int)
        (Math.Round(amplitudeMountane * Math.Sin((double)(x * (1/ frequencyMountane)))) +
        Math.Round(amplitude * Math.Sin((double)(x * (1 / frequency)))) +
        Math.Round(amplitudeHill * Math.Sin((double)(x * (1 / frequencyHill))))
        ) + height / 2;


    for (int y = yRef; y < _grid._grid.GetLength(1); y++)
    {
        _grid._grid[x, y] = -2;
    }
}

string gridString = "";
for (int y = _grid._grid.GetLength(1) - 1; y >= 0; y--)
{
    for (int x = 0; x < _grid._grid.GetLength(0); x++)
    {
        gridString += _grid._grid[x, y] == 1 ? " #" : _grid._grid[x, y] == 0 ? "  " : " -";
    }
    gridString += "\n";
}


Console.WriteLine(gridString);
Utility_CelllularAuomataCaveGeneration.CreateCaveMap(ref _grid, 10);

for (int i = 0; i < Utility_CelllularAuomataCaveGeneration._iterations.Count; i++)
{
    Console.WriteLine("Iteration numéros " + i + ": ");
    gridString = "";
    int[,] grid = Utility_CelllularAuomataCaveGeneration._iterations[i];
    for (int y = grid.GetLength(1) - 1; y >= 0; y--)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            gridString += grid[x, y] == 1 ? " #" : "  ";
        }
        gridString += "\n";
    }
    Console.WriteLine(gridString);
    Console.WriteLine("\n");
}


/*string gridString = "";
for (int y = _grid._grid.GetLength(1) - 1; y >= 0; y--)
{
    for (int x = 0; x < _grid._grid.GetLength(0); x++)
    {
        gridString += _grid._grid[x, y] == 1 ? " #" : _grid._grid[x, y] == 0 ? "  " : " -";
    }
    gridString += "\n";
}*/

/*Utility_CelllularAuomataCaveGeneration.CreateCaveMap(50, 200, 10);

for(int i = 0; i < Utility_CelllularAuomataCaveGeneration._iterations.Count;i++)
{
    Console.WriteLine("Iteration numéros " + i +": ");
    string gridString = "";
    int[,] grid = Utility_CelllularAuomataCaveGeneration._iterations[i];
    for (int y = grid.GetLength(1) - 1; y >= 0;y--)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            gridString += grid[x, y] == 1 ? " #" :  "  ";
        }
        gridString += "\n";
    }
    Console.WriteLine(gridString);
    Console.WriteLine("\n");
}*/