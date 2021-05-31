using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {
    public abstract class Rules {
        public abstract bool IsMoveLegal(string move, Board board);
        public abstract bool HasWon(Board board, string last_move, char sym);
    }
}
