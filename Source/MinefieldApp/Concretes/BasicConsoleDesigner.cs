using System;
using MinefieldApp.Interfaces;

namespace MinefieldApp.Concretes
{
    public class BasicConsoleDesigner : IConsoleDesigner
    {
        public void ShowGrid(ITile[,] tiles, ITile currentTile, ITile finishTile)
        {
            Console.CursorVisible = false;

            var width = tiles.GetLength(0);
            var height = tiles.GetLength(1) - 1;

            Console.WriteLine();

            for (var y = height; y >= 0; y--)
            {
                Console.Write(" ");
                Console.Write(tiles[0, y].GetYLabel());
                Console.Write(" ");
                for (var x = 0; x < width; x++)
                {
                    if (tiles[x, y] == currentTile)
                        Console.Write("[x]");
                    else if (tiles[x, y] == finishTile)
                        Console.Write("[o]");
                    else
                        Console.Write("[ ]");
                }
                Console.WriteLine();
            }

            Console.Write("    ");

            for (var x = 0; x < width; x++)
            {
                Console.Write(tiles[x, 0].GetXLabel());
                Console.Write("  ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void ShowProximity(int distance)
        {
            switch (distance)
            {
                case 1:
                    {
                        Console.WriteLine(" You are very close to a mine");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(" You are close to a mine");
                        break;
                    }
            }
        }
    }
}