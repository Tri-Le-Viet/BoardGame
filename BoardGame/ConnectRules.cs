using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {
    class ConnectRules : Rules {
        override public bool IsMoveLegal(string move, Board board) {
            int x = ConnectUI.ConvertMove(move);
            if (x <= 0 || x > board.GetWidth() || board.GetTopUnfilled(x) == -1) {
                return false;
            }

            return true;
        }


        private readonly static int[][] directions = new int[][] {new int[] {-1, -1}, new int[] {1, 1},
            new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, 1}, new int[] {-1, 1 }, new int[] {1, -1 } };


        override public bool HasWon(Board board, string last_move, char sym) {
            int x = ConnectUI.ConvertMove(last_move); //assume that the move is valid so don't bother checking
            int y = board.GetTopUnfilled(x) - 1;
            for (int i = 0; i < directions.Length; i += 2) {
                int path_len = 1;
                path_len += board.CheckDirection(x, y, directions[i], sym); // check -ve direction
                path_len += board.CheckDirection(x, y, directions[i + 1], sym); // check +ve direction

                if (path_len >= 4) {
                    return true;
                }
            }

            return false;
        }
    }
}
