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
    public class PlayerTests
    {
        private IBoard _board;
        private int _startingLives;

        [SetUp]
        public void Setup()
        {
            _board = Substitute.For<IBoard>();
            _startingLives = 3;
        }

        [Test]
        public void Move_PlayerMoveShouldBeRecorded()
        {
            // Arrange
            _board.ShiftTileDown().Returns(true);
            var player = new Player(_board, _startingLives);

            // Act
            player.MoveDown();

            // Assert
            Assert.AreEqual(1, player.GetMovesTaken());
        }

        [Test]
        public void ReduceLives_NumberOfLivesShouldBeReduced()
        {
            // Arrange
            int livesToReduce = 1;
            var player = new Player(_board, _startingLives);

            // Act
            player.ReduceLives(livesToReduce);

            // Assert
            Assert.AreEqual(_startingLives - livesToReduce, player.GetLivesLeft());
        }

        [Test]
        public void CheckIfAlive_ShouldReturnTrueOrFalse()
        {
            // Arrange
            var player = new Player(_board, _startingLives);

            // Act
            player.ReduceLives(2);

            // Assert
            Assert.IsTrue(player.Alive());

            // Act
            player.ReduceLives(1);

            // Assert
            Assert.IsFalse(player.Alive());
        }

        /// <summary>
        /// Check that lives and moves reset when player resets
        /// </summary>
        [Test]
        public void Reset_ShouldResetLivesAndMoves()
        {
            // Arrange
            int resetLives = 3, initialMoves = 0;
            var player = new Player(_board);
            _board.ShiftTileDown().Returns(true);

            player.ReduceLives(1);
            player.MoveDown();

            Assert.AreNotEqual(resetLives, player.GetLivesLeft());
            Assert.AreNotEqual(initialMoves, player.GetMovesTaken());

            // Act
            player.Reset();

            // Assert
            Assert.AreEqual(resetLives, player.GetLivesLeft());
            Assert.AreEqual(initialMoves, player.GetMovesTaken());
        }
    }
}