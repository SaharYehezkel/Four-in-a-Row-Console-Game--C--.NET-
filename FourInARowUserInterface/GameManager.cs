using System;
using System.Threading;
using FourInARowGameLogic;

namespace FourInARow
{
    public class GameManager
    {
        private Board m_GameBoard;
        ConsolePrinter m_ConsolePrinter;
        private bool m_AgainstPC;
        private byte m_PlayerTurn;
        private Player m_Player1;
        private Player m_Player2;

        public GameManager()
        {
            m_ConsolePrinter = new ConsolePrinter();
            (int rows, int columns, bool againstPC) = m_ConsolePrinter.MainMenuUserInput();
            m_AgainstPC = againstPC;
            m_GameBoard = new Board(rows, columns);
            m_Player1 = new Player();
            m_Player2 = new Player();
        }

        public Board GameBoard
        {
            get
            {
                return m_GameBoard;
            }
        }

        public bool AgainstPC
        {
            get
            {
                return m_AgainstPC;
            }
        }

        public byte PlayerTurn
        {
            get
            {
                return m_PlayerTurn;
            }
        }

        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        private void playRoundOfFourInARow()
        {
            int totalColumns = m_GameBoard.Columns;
            int totalRows = m_GameBoard.Rows;
            int totalInserts = totalRows * totalColumns;
            string userInput;
            int columnInsert;
            int rowInsert;
            bool isPlayed = false;

            m_PlayerTurn = flippingCoinForStarter();
            while (m_GameBoard.CoinsInserted < totalInserts)
            {
                m_ConsolePrinter.BoardPrinter(totalRows, totalColumns, m_GameBoard.GameBoard);

                if (m_PlayerTurn == 1 || !m_AgainstPC)
                {
                    Console.WriteLine(m_AgainstPC ? "Player's turn! Enter the column number to insert your coin:" :
                             (m_PlayerTurn == 1 ? "Player1 turn! Enter the column number to insert your coin:" :
                             "Player2 turn! Enter the column number to insert your coin:"));
                    userInput = Console.ReadLine();
                    if (userInput == "Q")
                    {
                        gameOverByPlayerSurrender(m_PlayerTurn);
                        break;
                    }

                    if (int.TryParse(userInput, out columnInsert) && columnInsert > 0 && columnInsert <= totalColumns)
                    {
                        if (m_GameBoard.IsColumnValid(columnInsert - 1))
                        {
                            isPlayed = false;
                            (rowInsert, isPlayed) = m_GameBoard.FindLowestRowFreeCellToInstert(columnInsert);
                            if (isPlayed)
                            {
                                m_GameBoard.InsertCellCoin(m_PlayerTurn == 1 ? 'O' : 'X', rowInsert, columnInsert - 1);
                            }
                            else
                            {
                                Console.WriteLine("Column is full. Please choose another column.");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Column is full. Please choose another column.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nInvalid input. Please enter a valid column number.");
                        Thread.Sleep(3000);
                        continue;
                    }
                }
                else // Computer's turn
                {
                    Console.WriteLine("Computer's turn...");
                    Thread.Sleep(600);
                    m_GameBoard.PlayAIPlay();
                }

                if (haveWinnerToPresent(m_GameBoard))
                {
                    break;
                }

                changePlayerTurn();
                m_GameBoard.CoinsInserted++;

                if (m_GameBoard.CoinsInserted == totalInserts)
                {
                    presentDrawByFullBoardWithoutWinner(m_GameBoard);
                    break;
                }
            }
        }

        private void gameOverByPlayerSurrender(int i_PlayerSurrender)
        {
            if (i_PlayerSurrender == 1)
            {
                Player2.Wins = Player2.Wins + 1;
                Player1.Loses = Player1.Loses - 1;
            }
            else
            {
                Player1.Wins = Player1.Wins + 1;
                Player2.Loses = Player2.Loses - 1;
            }

            m_ConsolePrinter.ClearAndPaintTheBoard(m_GameBoard.Rows, m_GameBoard.Columns, m_GameBoard.GameBoard);
            m_ConsolePrinter.StatsPrinter(m_Player1, m_Player2, m_AgainstPC);
        }

        private void presentDrawByFullBoardWithoutWinner(Board i_GameBoard)
        {
            Player1.Draws++;
            Player2.Draws++;
            m_ConsolePrinter.BoardPrinter(i_GameBoard.Rows, i_GameBoard.Columns, i_GameBoard.GameBoard);
            Console.WriteLine("\n═══════════════════════\nGame Over! It's a Draw.\n═══════════════════════");
            m_ConsolePrinter.StatsPrinter(m_Player1, m_Player2, m_AgainstPC);
        }

        private bool haveWinnerToPresent(Board i_GameBoard)
        {
            int winner = m_GameBoard.CheckForWin();
            bool haveWinner = false;

            if (winner == 1)
            {
                Player1.Wins = Player1.Wins + 1;
                Player2.Loses = Player2.Loses - 1;
                m_ConsolePrinter.BoardPrinter(i_GameBoard.Rows, i_GameBoard.Columns, i_GameBoard.GameBoard);
                Console.WriteLine("\n═══════════════════════\nGame Over! Player1 Win!\n═══════════════════════");
                m_ConsolePrinter.StatsPrinter(m_Player1, m_Player2, m_AgainstPC);
                haveWinner = true;
            }
            else if (winner == 2)
            {
                Player2.Wins = Player2.Wins + 1;
                Player1.Loses = Player1.Loses - 1;
                m_ConsolePrinter.BoardPrinter(i_GameBoard.Rows, i_GameBoard.Columns, i_GameBoard.GameBoard);
                Console.WriteLine("\n═══════════════════════\nGame Over! Player2 Win!\n═══════════════════════");
                m_ConsolePrinter.StatsPrinter(m_Player1, m_Player2, m_AgainstPC);
                haveWinner = true;
            }

            return haveWinner;
        }

        private void changePlayerTurn()
        {
            m_PlayerTurn = (m_PlayerTurn == 1) ? (byte)2 : (byte)1;
        }

        private byte flippingCoinForStarter()
        {
            byte starter;

            Console.Clear();
            Console.WriteLine("Flipping the coin...");
            Thread.Sleep(300);
            m_ConsolePrinter.FlippingCoinAnimation();
            Console.Clear();
            Console.WriteLine("Result:");
            if (getRandomCoinSide() == "Heads")
            {
                Console.WriteLine("Player1 starting the game.\nGood Luck!");
                starter = 1;
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("PC/Player2 starting the game.\nGood Luck!");
                starter = 2;
                Thread.Sleep(3000);
            }

            return starter;
        }

        private string getRandomCoinSide()
        {
            Random random = new Random();

            return random.Next(2) == 0 ? "Heads" : "Tails";
        }

        public void RunFourInARowGame()
        {
            bool userWantRestart = false;
            string userInput;
            String restartMessage = String.Format("Do you want to restart the game? (Y/N)");

            do
            {
                m_GameBoard.ResetBoard();
                playRoundOfFourInARow();
                Console.WriteLine(restartMessage);
                userInput = Console.ReadLine();
                userWantRestart = userInput.ToUpper() == "Y";
            }
            while (userWantRestart);
        }
    }
}
