using System;
using System.Collections.Generic;
using System.Text;

namespace MinefieldApp.Interfaces
{
    public interface IBoard
    {
        void Setup();
        ITile[,] GenerateTiles(int boardWidth, int boardHeight, int startPosX = 0);
        ITile GenerateFinishTile(int endPosX, int boardHeight);
        bool ShiftTileUp();
        bool ShiftTileDown();
        bool ShiftTileLeft();
        bool ShiftTileRight();
        void GetMineProximity();
        void SetActiveTile(int xPos, int yPos);
        ITile GetActiveTile();
        ITile GetFinishedTile();
    }
}
