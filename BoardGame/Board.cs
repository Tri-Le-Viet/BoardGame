using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {

    public class Board {
        private int width;
        private int height;
        private Piece[][] state;
        private char empty;

        public int GetWidth() {
            return width;
        }

        public int GetHeight() {
            return height;
        }

        public char GetSpace(int x, int y) {
            return state[x - 1][y - 1].symbol;
        }
        public bool IsSpaceEmpty(int x, int y) {
            return (state[x - 1][y - 1].symbol == empty);
        }

        public void Place(int x, int y, char symbol) {
            state[x - 1][y - 1] = new Piece(symbol);
        }

        public void Remove(int x, int y) {
            state[x - 1][y - 1] = new Piece(empty);
        }

        public bool IsInBoard(int x, int y) {
            if (x <= 0 || y <= 0 || x > width || y > height) {
                return false;
            }

            return true;
        }

        public int GetTopUnfilled(int x) {
            for (int i = 1; i < this.GetHeight(); i++) {
                if (this.IsSpaceEmpty(x, i)) {
                    return i;
                }
            }

            return -1; // all slots filled
        }

        public int CheckDirection(int start_x, int start_y, int[] direction, char sym) {
            int new_x = start_x + direction[0];
            int new_y = start_y + direction[1];
            int path_len = 0;

            while (this.IsInBoard(new_x, new_y) && this.GetSpace(new_x, new_y) == sym) {
                new_x += direction[0];
                new_y += direction[1];
                path_len++;
            }

            return path_len;
        }

        public Board(int width, int height, char empty) {
            this.width = width;
            this.height = height;
            this.empty = empty;
            state = new Piece[width][];

            for (int i = 0; i < width; i++) {
                state[i] = new Piece[height];

                for (int j = 0; j < height; j++) {
                    state[i][j] = new Piece(empty);
                }
            }
        }

        public override string ToString() {
            string board_state = "";
            for (int i = this.GetHeight(); i >= 1; i--) {
                for (int j = 1; j <= this.GetWidth(); j++) {
                    board_state += this.GetSpace(j, i);
                    if (j != this.GetWidth()) {
                        board_state += "|";
                    }
                }
                board_state += "\n";
            }
            return board_state;
        }
    }
}
