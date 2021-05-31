using System;

namespace BoardGame {
    public class ConnectTurn : Turn {
        public ConnectTurn(Player active_player, Player inactive_player, Board board, History history, int game_type, Rules rules) : base(active_player, inactive_player, board, history, game_type, rules) {
        }

        public override string Move() {
            Console.Write(board.ToString());
            while (true) {
                Console.Write(String.Format("{0}'s turn: ", active_player.GetName()));
                string response = active_player.GenerateMove(board);
                bool turn_over = false;
                switch (response) {
                    case "undo":
                        if (history.Undo(board, game_type) != -1) {
                            turn_over = true;
                        } else {
                            Console.WriteLine("No moves left to undo");
                        }
                        break;
                    case "redo":
                        if (history.Redo(board, game_type) != -1) {
                            turn_over = true;
                        } else {
                            Console.WriteLine("No moves left to redo");
                        }
                        
                        break;
                    case "save":
                        // this is a valid response but doesn't change whose turn it is
                        // so we stay in the while loop
                        Console.Write("Please enter the filename to save to: ");
                        string filename = Console.ReadLine();
                        history.Save(filename, board, active_player, inactive_player);
                        break;
                    case "load":
                        //TODO
                        break;
                    case "help":
                        //TODO
                        break;
                    case string move when move.StartsWith("place"):
                        if (rules.IsMoveLegal(move, board)) {
                            turn_over = true;
                            int x = ConnectUI.ConvertMove(move);
                            board.Place(x, board.GetTopUnfilled(x), active_player.GetSymbol());
                            history.AddMove(move + " " + active_player.GetSymbol());
                        } else {
                            Console.WriteLine("Move is not valid. Please try again");
                        }
                        break;
                }

                if (turn_over) {
                    return response;
                }
            }
        }
    }
}
