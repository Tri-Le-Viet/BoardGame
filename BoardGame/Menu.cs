using System;
using System.Threading;

namespace BoardGame {
    class Menu {
        private static string[] game_types = { "Connect Four", "Checkers" };
        static void Main(string[] args) {
            while (true) {
                Game game = SelectGameType();
                game.Play();
                Console.WriteLine("\n\n\nGenerating new game");
                Thread.Sleep(1000);
            }
        }

        private static Game SelectGameType() {
            int selected_game;
            Console.WriteLine("What game would you like to play?");
            while (true) {
                for (int i = 0; i < game_types.Length; i++) {
                    Console.WriteLine(String.Format("{0}: {1}", i + 1, game_types[i]));
                }

                string response = Console.ReadLine();

                if (!int.TryParse(response, out selected_game)) {
                    Console.WriteLine(String.Format("Invalid choice. Please enter a number between 1 and {0}", game_types.Length));
                } else {
                    switch (selected_game) {
                        case 1:
                            return new ConnectGame();
                        case 2:
                            throw new NotImplementedException();
                        default:
                            Console.WriteLine("Invalid choice. Options are:");
                            break;
                    }
                }
            }
        }
    }
}
