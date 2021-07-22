using System;
using System.Collections.Generic;
using System.Text;
using MinefieldApp.Interfaces;
using MinefieldApp.Concretes;
using NUnit.Framework;

namespace MinefieldApp.Tests
{
    [TestFixture]
    public class TileTests
    {
        private ITile _tile;
        private int _xPos;
        private int _yPos;
        private string _xLable;
        private string _yLable;

        [SetUp]
        public void Setup()
        {
            _xPos = 3;
            _yPos = 5;
            _xLable = "C";
            _yLable = "5";
            _tile = new Tile(_xPos, _yPos, _xLable, _yLable);
        }

        [Test]
        public void GetXPos_ShouldReturnXPosition()
        {
            Assert.AreEqual(_xPos, _tile.GetXPos());
        }

        [Test]
        public void GetYLabel_ShouldReturnYLable()
        {
            Assert.AreEqual(_yLable, _tile.GetYLabel());
        }
    }
}