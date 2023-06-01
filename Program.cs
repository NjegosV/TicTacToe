namespace TicTacToe
{
    class Program
    {
        static char[,] field = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        static char[,] fieldInitial = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        static void Main(string[] args) {
            char[] players = { 'O', 'X' };
            int playerIndex = 0;
            int input = 0;
            bool inputCorrect = false;

            do {
                SetField();

                playerIndex = 1 - playerIndex;
                char currentPlayer = players[playerIndex];

                do {
                    Console.Write($"Player {currentPlayer}, enter a number: ");
                    inputCorrect = int.TryParse(Console.ReadLine(), out input) &&
                                   input >= 1 && input <= 9 &&
                                   field[(input - 1) / 3, (input - 1) % 3] != 'X' &&
                                   field[(input - 1) / 3, (input - 1) % 3] != 'O';

                    if (!inputCorrect)
                        Console.WriteLine("Invalid input, please try again.");
                }
                while (!inputCorrect);

                field[(input - 1) / 3, (input - 1) % 3] = currentPlayer;


                if (CheckWin(currentPlayer)) {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    Console.Write("Press any key to reset the game:");
                    Console.ReadKey();
                    playerIndex = 0;
                    field = (char[,])fieldInitial.Clone();
                }
            }
            while (true);
        }

        public static void SetField() {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {field[0, 0]}  |  {field[0, 1]}  |  {field[0, 2]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {field[1, 0]}  |  {field[1, 1]}  |  {field[1, 2]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {field[2, 0]}  |  {field[2, 1]}  |  {field[2, 2]}  ");
            Console.WriteLine("     |     |     ");
        }


        public static bool CheckWin(char player) {

            for (int i = 0; i < 3; i++) {
                if (field[i, 0] == player && field[i, 1] == player && field[i, 2] == player)
                    return true;
            }

            for (int i = 0; i < 3; i++) {
                if (field[0, i] == player && field[1, i] == player && field[2, i] == player)
                    return true;
            }

            if (field[0, 0] == player && field[1, 1] == player && field[2, 2] == player)
                return true;

            if (field[0, 2] == player && field[1, 1] == player && field[2, 0] == player)
                return true;

            return false;
        }


    }
}