using MinefieldApp.Interfaces;
using System;

namespace MinefieldApp.Concretes
{
    public class FinishTile : Tile
    {
        public FinishTile(int x, int y, string xLabel = null, string yLabel = null) : base(x, y, xLabel, yLabel)
        {
        }

        public override void Activate(IPlayer player)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ***YOU WON!***");
            Console.WriteLine($" Final Score (moves taken): {player.GetMovesTaken()}");
            Console.WriteLine(" Press Enter to play again, or Escape to exit");
        }
    }
}