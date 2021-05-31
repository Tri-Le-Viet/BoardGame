using System;
using System.IO;

namespace BoardGame {
    public class ConnectHistory : History {

        public override int Undo(Board board, int game_type) { // type 1 = human vs human, just undo last move. type 2 is human vs ai, undo 2 moves
            if (last_move <= 0) {
                return -1; // error
            } else {
                Console.WriteLine(game_type);
                for (int i = 0; i < game_type; i++) {
                    last_move--;
                    int x = ConnectUI.ConvertMove(record[last_move]);
                    board.Remove(x, board.GetTopUnfilled(x) - 1);
                }
                return last_move;
            }
        }
        public override int Redo(Board board, int game_type) {
            if (last_move >= record.Count) {
                return -1; //error
            } else {
                for (int i = 0; i < game_type; i++) { 
                    int x = ConnectUI.ConvertMove(record[last_move]);
                    char sym = record[last_move].Split(" ")[2][0];
                    board.Place(x, board.GetTopUnfilled(x), sym);
                    last_move++;
                }
                return last_move;
            }
        }

        public override void Save(string file_name, Board board, Player player1, Player player2) {
            //format is player1, player2, current move number, each entry of history and then board.To_string()
            FileStream save_file = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(save_file);
            writer.WriteLine(player1.GetName() + " " + player1.GetSymbol());
            writer.WriteLine(player2.GetName() + " " + player2.GetSymbol());
            writer.WriteLine(last_move);
            foreach (string move in record) {
                writer.WriteLine(move);
            }

            writer.Write(board.ToString());

            writer.Close();
            save_file.Close();
        }
    }
}
