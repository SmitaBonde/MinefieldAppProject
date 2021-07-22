using System;
using System.Collections.Generic;
using System.Text;

namespace MinefieldApp.Interfaces
{
    public interface IMinefieldEngine
    {
        void Start(IBoard board, IPlayer player);

        void End();
    }
}
