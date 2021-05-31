using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {
    class HumanConnectPlayer : Player {
        public HumanConnectPlayer(string name, char symbol) : base(name, symbol) {
        }
        public override string GenerateMove(Board board) {
            return Console.ReadLine();
        }
    }
}
