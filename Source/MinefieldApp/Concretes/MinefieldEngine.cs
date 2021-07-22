using System;
using MinefieldApp.Interfaces;

namespace MinefieldApp.Concretes
{
    public class MinefieldEngine : IMinefieldEngine
    {
        public void Start(IBoard board, IPlayer player)
        {
            board.Setup();

            while (player.Alive() && !player.Finished())
            {
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            player.MoveUp();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            player.MoveDown();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            player.MoveLeft();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            player.MoveRight();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            board.Setup();
                            player.Reset();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }

            End();
        }

        public void End()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    {
                        var renderer = new BasicConsoleDesigner();
                        var board = new Board(renderer);
                        Start(board, new Player(board));
                        break;
                    }
                case ConsoleKey.Escape: { return; }
                default: { End(); break; }
            }
        }
    }
}