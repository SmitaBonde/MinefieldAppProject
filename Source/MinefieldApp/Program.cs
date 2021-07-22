using MinefieldApp.Concretes;

namespace MinefieldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var renderer = new BasicConsoleDesigner();
            var board = new Board(renderer);
            new MinefieldEngine().Start(board, new Player(board));
        }
    }
}
