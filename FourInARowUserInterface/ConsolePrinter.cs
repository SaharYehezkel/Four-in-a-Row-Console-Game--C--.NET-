using FourInARowGameLogic;
using System;
using System.Threading;


namespace FourInARow
{
    public class ConsolePrinter
    {
        // Pseudo:
        // 1. Reuse the method who clears the screen (ref).                                               <---- /// <DONE> ///
        // 2. Implement the method that print the board for every move in the game.                       <---- /// <DONE> ///
        //  2.1 Get the height & width of the board.                                                      <---- /// <DONE> ///
        //  2.2 Get the matrix updated with last play.                                                    <---- /// <DONE> ///   
        //  2.3 For each cell in the board check the for empty\X\O and print in to the current cell.      <---- /// <DONE> ///
        //  2.4 Every space in the cells-between will print the relevant parts of the board.              <---- /// <DONE> ///
        //   2.4.1 Top of the board present the Column number to choose by the players.                   <---- /// <DONE> ///
        //   2.4.2 Every new rows of cells be boarded by " | ".                                           <---- /// <DONE> ///
        //   2.4.3 Every new row between cells filled by "====...".                                       <---- /// <DONE> ///
        // 3. Implement the method of the main-menu.                                                      <---- /// <DONE> ///

        public void BoardPrinter(int i_Rows, int i_Columns, char[,] matrix)
        {
            string separatorLine = new string('=', i_Columns * 4);

            Ex02.ConsoleUtils.Screen.Clear();
            Console.Write(" ");
            for (int i = 0; i < i_Columns; i++)
            {
                Console.Write($" {i + 1}  ");
            }

            Console.WriteLine();
            for (int i = 0; i < i_Rows; i++)
            {
                Console.Write("|");
                for (int j = 0; j < i_Columns; j++)
                {
                    Console.Write($" {matrix[i, j]} |");
                }

                Console.WriteLine($"\n{separatorLine}");
            }

        }

        public void MainMenuScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("██╗  ██╗    ██╗███╗   ██╗     █████╗     ██████╗  ██████╗ ██╗    ██╗");
            Console.WriteLine("██║  ██║    ██║████╗  ██║    ██╔══██╗    ██╔══██╗██╔═══██╗██║    ██║");
            Console.WriteLine("███████║    ██║██╔██╗ ██║    ███████║    ██████╔╝██║   ██║██║ █╗ ██║");
            Console.WriteLine("╚════██║    ██║██║╚██╗██║    ██╔══██║    ██╔══██╗██║   ██║██║███╗██║");
            Console.WriteLine("     ██║    ██║██║ ╚████║    ██║  ██║    ██║  ██║╚██████╔╝╚███╔███╔╝");
            Console.WriteLine("     ╚═╝    ╚═╝╚═╝  ╚═══╝    ╚═╝  ╚═╝    ╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝ ");
            Console.WriteLine("\n\n                       Press '1' to Start Game");
            Console.WriteLine("                       Press '2' to Exit");
            Console.WriteLine("\n\n\n______         _____       _                 __   __   _              _        _  ");
            Console.WriteLine("| ___ \\       /  ___|     | |                \\ \\ / /  | |            | |      | |");
            Console.WriteLine("| |_/ /_   _  \\ `--.  __ _| |__   __ _ _ __   \\ V /___| |__   ___ ___| | _____| | ");
            Console.WriteLine("| ___ \\ | | |  `--. \\/ _` | '_ \\ / _` | '__|   \\ // _ \\ '_ \\ / _ \\_  / |/ / _ \\ | ");
            Console.WriteLine("| |_/ / |_| | /\\__/ / (_| | | | | (_| | |      | |  __/ | | |  __// /|   <  __/ | ");
            Console.WriteLine("\\____/ \\__, | \\____/ \\__,_|_| |_|\\__,_|_|      \\_/\\___|_| |_|\\___/___|_|\\_\\___|_| ");
            Console.WriteLine("        __/ |                                                                     ");
            Console.WriteLine("       |___/                                                                      \n");
            Console.WriteLine("          _____ _           _                   ___      _     _                        _ ");
            Console.WriteLine("  ___    /  ___| |         | |                 / _ \\    | |   | |                      (_)");
            Console.WriteLine(" ( _ )   \\ `--.| |__   __ _| |__   __ _ _ __  / /_\\ \\___| |__ | | _____ _ __   __ _ _____ ");
            Console.WriteLine(" / _ \\/\\  `--. \\ '_ \\ / _` | '_ \\ / _` | '__| |  _  / __| '_ \\| |/ / _ \\ '_ \\ / _` |_  / |");
            Console.WriteLine("| (_>  < /\\__/ / | | | (_| | | | | (_| | |    | | | \\__ \\ | | |   <  __/ | | | (_| |/ /| |");
            Console.WriteLine(" \\___/\\/ \\____/|_| |_|\\__,_|_| |_|\\__,_|_|    \\_| |_/___/_| |_|_|\\_\\___|_| |_|\\__,_/___|_|");
        }

        public void MainMenuScreenAfterInvalidInput()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("██╗  ██╗    ██╗███╗   ██╗     █████╗     ██████╗  ██████╗ ██╗    ██╗");
            Console.WriteLine("██║  ██║    ██║████╗  ██║    ██╔══██╗    ██╔══██╗██╔═══██╗██║    ██║");
            Console.WriteLine("███████║    ██║██╔██╗ ██║    ███████║    ██████╔╝██║   ██║██║ █╗ ██║");
            Console.WriteLine("╚════██║    ██║██║╚██╗██║    ██╔══██║    ██╔══██╗██║   ██║██║███╗██║");
            Console.WriteLine("     ██║    ██║██║ ╚████║    ██║  ██║    ██║  ██║╚██████╔╝╚███╔███╔╝");
            Console.WriteLine("     ╚═╝    ╚═╝╚═╝  ╚═══╝    ╚═╝  ╚═╝    ╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝ ");
            Console.WriteLine("\n\nInvalid input!\n");
            Console.WriteLine("\n\n                       Press '1' to Start Game");
            Console.WriteLine("                       Press '2' to Exit");
        }

        public void FlippingCoinAnimation()
        {
            string[] coinFrames = {
            "   _______   ",
            "  /       \\  ",
            " |         | ",
            " |    *    | ",
            " |    |    | ",
            "  \\_______/  ",
            "",
            "   _______   ",
            "  /       \\  ",
            " |         | ",
            " |    o    | ",
            " |   /|\\   | ",
            "  \\_______/  ",
            "",
            "   _______   ",
            "  /       \\  ",
            " |         | ",
            " |   *     | ",
            " |  /|\\    | ",
            "  \\_______/  ",
            "",
            "   _______   ",
            "  /       \\  ",
            " |         | ",
            " |    o    | ",
            " |   / \\   | ",
            "  \\_______/  "
            };

            for (int i = 0; i < coinFrames.Length; i++)
            {
                Console.Clear();
                Console.WriteLine(coinFrames[i]);
                Thread.Sleep(75);
            }
        }

        public void ChooseOpponentScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("  _      ____   _____          _         __      __                                       _____   _____ ");
            Console.WriteLine(" | |    / __ \\ / ____|   /\\   | |       /_ |    /_ |                                     |  __ \\ / ____|");
            Console.WriteLine(" | |   | |  | | |       /  \\  | |  ______| |_   _| |                         __   _____  | |__) | |     ");
            Console.WriteLine(" | |   | |  | | |      / /\\ \\ | | |______| \\ \\ / / |                         \\ \\ / / __| |  ___/| |     ");
            Console.WriteLine(" | |___| |__| | |____ / ____ \\| |____    | |\\ V /| |                          \\ V /\\__ \\ | |    | |____ ");
            Console.WriteLine(" |______\\____/ \\_____/_/    \\_\\______|   |_| \\_/ |_|                           \\_/ |___/ |_|     \\_____|");
            Console.WriteLine("      _____                     __                                                _____                     ___  ");
            Console.WriteLine("     |  __ \\                   /_ |                                              |  __ \\                   |__ \\ ");
            Console.WriteLine("     | |__) | __ ___  ___ ___   | |                                              | |__) | __ ___  ___ ___     ) |");
            Console.WriteLine("     |  ___/ '__/ _ \\/ __/ __|  | |                                              |  ___/ '__/ _ \\/ __/ __|   / / ");
            Console.WriteLine("     | |   | | |  __/\\__ \\__ \\  | |                                              | |   | | |  __/\\__ \\__ \\  / /_ ");
            Console.WriteLine("     |_|   |_|  \\___||___/___/  |_|                                              |_|   |_|  \\___||___/___/ |____|");
        }

        public (int, int, bool) MainMenuUserInput()
        {
            string userInput;
            int columns = 0;
            int rows = 0;
            bool againstPC = false;

            MainMenuScreen();
            userInput = Console.ReadLine();
            while (userInput != "1" && userInput != "2")
            {
                MainMenuScreenAfterInvalidInput();
                userInput = Console.ReadLine();
            }

            if (userInput == "1")
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Please enter the dimensions of the board.");
                Console.WriteLine("Rows (must be min - 4, max - 8):");

                while (!(int.TryParse(Console.ReadLine(), out rows) && rows >= 4 && rows <= 8))
                {
                    Console.WriteLine("Invalid input! Rows (must be min - 4, max - 8):");
                }

                Console.WriteLine("Columns (min - 4, max - 8):");

                while (!(int.TryParse(Console.ReadLine(), out columns) && columns >= 4 && columns <= 8))
                {
                    Console.WriteLine("Invalid input! Columns (must be min - 4, max - 8):");
                }

                do
                {
                    ChooseOpponentScreen();
                    userInput = Console.ReadLine();
                }
                while (userInput != "1" && userInput != "2");

                againstPC = (userInput == "2");
            }

            return (rows, columns, againstPC);
        }

        public void ClearAndPaintTheBoard(int i_Rows, int i_Columns, char[,] matrix)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            BoardPrinter(i_Rows, i_Columns, matrix);
        }

        public void StatsPrinter(Player i_Player1, Player i_Player2, bool i_AgainstPC)
        {
            Console.WriteLine("\n══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("═════════════════════════════ Player1 Stats: ═════════════════════════════");
            Console.WriteLine("═════════════════════ Wins: {0} | Draws: {1} | Loses: {2} ══════════════════════", i_Player1.Wins, i_Player1.Draws, i_Player1.Loses);
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("{0}", i_AgainstPC ? "════════════════════════════════ PC Stats: ═══════════════════════════════" : "═════════════════════════════ Player2 Stats: ═════════════════════════════");
            Console.WriteLine("═════════════════════ Wins: {0} | Draws: {1} | Loses: {2} ══════════════════════", i_Player2.Wins, i_Player2.Draws, i_Player2.Loses);
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════\n");
        }
    }
}