using System.Collections.Generic;
using System;

namespace BoardGame {
    public abstract class History {
        protected List<string> record;
        protected int last_move;
        public History() {
            record = new List<string>();
            last_move = 0;
        }

        public History(List<string> record, int last_move) {
            this.record = record;
            this.last_move = last_move;
        }

        public void AddMove(string move) {
            if (last_move < record.Count) {
                Console.WriteLine(last_move);
                Console.WriteLine(record.Count);
                record.RemoveRange(last_move, record.Count - last_move); // erase all newer moves
            }
            last_move++;
            record.Add(move);
        }

        public abstract int Undo(Board board, int game_type);
        public abstract int Redo(Board board, int game_type);

        public abstract void Save(string file_name, Board board, Player player1, Player player2);

        // load? probably makes more sense as a part of Menu
        
    }
}
