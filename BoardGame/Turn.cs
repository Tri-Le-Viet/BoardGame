using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {
    public abstract class Turn {
        protected Player active_player;
        protected Player inactive_player;
        protected Board board;
        protected History history;
        protected int game_type; // 1 for human vs human, 2 for human vs ai (easy or hard)
        protected Rules rules;

        public Turn(Player active_player, Player inactive_player, Board board, History history, int game_type, Rules rules) {
            this.active_player = active_player;
            this.inactive_player = inactive_player;
            this.board = board;
            this.history = history;
            this.game_type = game_type;
            this.rules = rules;
        }

        public abstract string Move();
    }
}
