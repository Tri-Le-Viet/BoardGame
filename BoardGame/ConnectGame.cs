using System;
using System.Threading;

namespace BoardGame {
    public class ConnectGame : Game {
        private static int x = 7;
        private static int y = 6;
        private static char empty = ' ';

        public override string TakeTurn() {
            ConnectTurn turn = new ConnectTurn(players[player_turn], players[(player_turn + 1) % 2], board, history, game_type, rules);
            return turn.Move();
        }
        public override Player CreatePlayer(int player_num, char symbol) {
            string name = String.Format("player{0}", player_num);
            string[] player_options = { "p : person", "e : easy computer", "h: hard computer" };
            Console.WriteLine(String.Format("What kind of player do you want for player {0}?", player_num));

            bool valid_response = false;
            Player new_player = null;
            do {
                foreach (string option in player_options) {
                    Console.WriteLine(option);
                }

                string player_type = Console.ReadLine();
                switch (player_type) {
                    case "p":
                        new_player = new HumanConnectPlayer(name, symbol);
                        valid_response = true;
                        break;
                    case "e":
                        new_player = new EasyConnectCompPlayer(name, symbol);
                        valid_response = true;
                        break;
                    case "h":
                        throw new NotImplementedException(); // TODO
                        valid_response = true;
                        break;
                    default:
                        Console.WriteLine("Invalid player option. Valid options are:");
                        break;
                }

            } while (!valid_response);

            Console.WriteLine(String.Format("Do you want a custom name for this player (default is {0})? Y/N", name));
            valid_response = false;
            do {
                string response = Console.ReadLine();

                switch (response) {
                    case "Y":
                        Console.Write("Please enter player name: ");
                        name = Console.ReadLine();
                        new_player.ChangeName(name);
                        return new_player;
                    case "N":
                        return new_player;
                    default:
                        Console.WriteLine("Please enter either Y or N");
                        break;
                }


            } while (true);
        }

        public override void Play() {
            while (true) {
                string move = TakeTurn();
                if (move.StartsWith("place")) {
                    if (rules.HasWon(board, move, players[player_turn].GetSymbol())) {
                        Console.WriteLine(String.Format("Congratulations {0} you win!\nExiting game...", players[player_turn].GetName()));
                        Thread.Sleep(2000);
                        break;
                    }
                    AdvanceTurn();
                } else if (game_type == 1 && (move == "undo" || move == "redo")) {
                    AdvanceTurn();
                }
            }
        }

        public ConnectGame() {
            players = new Player[2];
            players[0] = CreatePlayer(1, '*');
            players[1] = CreatePlayer(2, '+');

            if (players[0] is ConnectCompPlayer || players[1] is ConnectCompPlayer) {
                game_type = 2;
            } else {
                game_type = 1;
            }

            history = new ConnectHistory();
            rules = new ConnectRules();
            board = new Board(x, y, empty);
        }
    }
}
