using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame {
    class ConnectUI {
        public static int ConvertMove(string move) {
            string[] details = move.Split(" ");
            if (details.Length < 2) {
                return -1;
            }

            try {
                return int.Parse(move.Split(" ")[1]);
            } catch {
                return -1;
            }
        }
    }
}
