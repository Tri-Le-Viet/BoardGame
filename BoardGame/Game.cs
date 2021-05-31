using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {
    public abstract class Game {
        protected Player[] players;
        protected Board board;
        protected History history;
        protected int game_type; // 1 for human vs human, 2 for human vs ai (easy or hard)
        protected Rules rules;
        protected int player_turn = 0;

        public abstract void Play();
        public abstract string TakeTurn();
        public void AdvanceTurn() {
            player_turn = (player_turn + 1) % players.Length;
        }
        public abstract Player CreatePlayer(int player_num, char symbol);
    }
}
