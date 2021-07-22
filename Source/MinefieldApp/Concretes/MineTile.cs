using MinefieldApp.Interfaces;
using System;

namespace MinefieldApp.Concretes
{
    public class MineTile : Tile
    {
        public MineTile(int x, int y, string _xLabel = null, string _yLabel = null) : base(x, y, _xLabel, _yLabel)
        {
        }

        public override void Activate(IPlayer player)
        {
            player.ReduceLives(1);
            Console.WriteLine(" ****You've been hit by a mine!****");
        }
    }
}