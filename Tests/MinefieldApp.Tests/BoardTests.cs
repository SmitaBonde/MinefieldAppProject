using System;
using System.Collections.Generic;
using System.Text;
using MinefieldApp.Interfaces;
using MinefieldApp.Concretes;
using NUnit.Framework;
using NSubstitute;

namespace MinefieldApp.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private IConsoleDesigner _designer;
        private IBoard _board;
        private int _boardHeight, _boardWidth;

        [SetUp]
        public void Setup()
        {
            _designer = Substitute.For<IConsoleDesigner>();
            _board = new Board(_designer);
            _board.Setup();
            _boardHeight = _boardWidth = 8;
        }

        [Test]
        public void GetActiveTile_ShouldGetCurrentTileOfBoard()
        {
            // Act
            var activeTile = _board.GetActiveTile();

            // Assert
            Assert.AreEqual(typeof(Tile), activeTile.GetType());
            Assert.AreEqual(0, activeTile.GetYPos());
            Assert.IsTrue(activeTile.GetXPos() >= 0 && activeTile.GetXPos() < _boardWidth);
        }

        [Test]
        public void GenerateTiles_ShouldGenerate8By8Tiles()
        {
            var tiles = _board.GenerateTiles(_boardWidth, _boardHeight);

            Assert.AreEqual("A1", tiles[0, 0].GetId());
            Assert.AreEqual("H8", tiles[7, 7].GetId());
            Assert.AreEqual(_boardWidth, tiles.GetLength(0));
            Assert.AreEqual(_boardHeight, tiles.GetLength(1));
        }

        [Test]
        public void ShiftTile()
        {
            _board.SetActiveTile(0, 0);
            Assert.True(_board.GetActiveTile().GetId() == "A1");

            _board.ShiftTileRight();
            Assert.True(_board.GetActiveTile().GetId() == "B1");

            _board.ShiftTileUp();
            Assert.True(_board.GetActiveTile().GetId() == "B2");

            _board.ShiftTileLeft();
            Assert.True(_board.GetActiveTile().GetId() == "A2");

            _board.ShiftTileDown();
            Assert.True(_board.GetActiveTile().GetId() == "A1");
        }
    }
}