using System;
using System.Threading;

namespace BoardGame {
    public class EasyConnectCompPlayer : ConnectCompPlayer {
        public EasyConnectCompPlayer(string name, char symbol) : base(name, symbol) {
        }
        public override string GenerateMove(Board board) {
            Random rand = new Random();
            int x;
            do {
                x = rand.Next(1, board.GetWidth());
            } while (board.GetTopUnfilled(x) == -1);
            string move = "place " + x;
            Thread.Sleep(500);
            Console.WriteLine(move);
            return move;
        }
    }
}