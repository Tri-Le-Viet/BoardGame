using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {
    public abstract class Player {
        protected char symbol;
        protected string name;

        public Player(string name, char symbol) {
            this.name = name;
            this.symbol = symbol;
        }
        public abstract string GenerateMove(Board board);

        public char GetSymbol() {
            return symbol;
        }

        public string GetName() {
            return name;
        }
        public void ChangeName(string name) {
            this.name = name;
        }
    }
}
