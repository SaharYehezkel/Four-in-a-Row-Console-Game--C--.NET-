using System;

namespace FourInARowGameLogic
{
    public class Board
    {
        private char[,] m_GameBoard;
        private int m_Columns;
        private int m_Rows;
        private int m_CoinsInserted;

        public Board(int i_Column, int i_Row)
        {
            m_CoinsInserted = 0;
            Columns = i_Column;
            Rows = i_Row;
            m_GameBoard = new char[Rows, Columns];
            InitializeGameBoard();
        }

        public char[,] GameBoard
        {
            get
            {
                return m_GameBoard;
            }
        }

        public int Columns
        {
            get
            {
                return m_Columns;
            }
            set
            {
                if (value >= 4 && value <= 8)
                {
                    m_Columns = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public int Rows
        {
            get
            {
                return m_Rows;
            }
            set
            {
                if (value >= 4 && value <= 8)
                {
                    m_Rows = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public int CoinsInserted
        {
            get
            {
                return m_CoinsInserted;
            }
            set
            {
                m_CoinsInserted = value;
            }
        }

        public void InitializeGameBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    m_GameBoard[row, col] = ' ';
                }
            }
        }

        public void InsertCellCoin(char i_CoinType, int i_Row, int i_Col)
        {
            if (i_Col >= 0 && i_Col < Columns && i_Row >= 0 && i_Row < Rows)
            {
                GameBoard[i_Row, i_Col] = i_CoinType;
            }
            else
            {
                throw new Exception("OutOfBounds!");
            }
        }

        public void RemoveCellCoin(int i_Row, int i_Column)
        {
            if (i_Row >= 0 && i_Row < Rows && i_Column >= 0 && i_Column < Columns)
            {
                GameBoard[i_Row, i_Column] = ' ';
            }
        }

        public (int, bool) FindLowestRowFreeCellToInstert(int i_ColumnInsert)
        {
            int row = -1;
            bool isPlayed = false;

            for (int i = Rows - 1; i >= 0; i--)
            {
                if (GameBoard[i, i_ColumnInsert - 1] == ' ')
                {
                    InsertCellCoin('O', i, i_ColumnInsert - 1);
                    row = i;
                    isPlayed = true;
                    break;
                }
            }

            return (row, isPlayed);
        }

        public void PlayAIPlay()
        {
            // 1. Check if AI can win in the next move
            //  1.1 Assuming 'X' is the AI's coin
            // 2. Block opponent's winning move
            //  2.1 Assuming 'O' is the opponent's coin
            // 3. Otherwise, make a move towards a potential win
            //  3.1 Implement logic to find the best move
            int bestMove = -1;
            bool isPlayed = false;

            bestMove = findWinningMove('X');
            if (bestMove != -1)
            {
                makeMove(bestMove, 'X');
                isPlayed = true;
            }

            if (!isPlayed)
            {
                bestMove = findWinningMove('O');
                if (bestMove != -1)
                {
                    makeMove(bestMove, 'X');
                    isPlayed = true;
                }
            }

            if (!isPlayed)
            {
                bestMove = findBestMove();
                if (bestMove != -1)
                {
                    makeMove(bestMove, 'X');
                    isPlayed = true;
                }
            }
        }

        private int findWinningMove(char i_Coin)
        {
            int columnToReturn = -1;
            int row;
            bool isPlayed;

            for (int column = 0; column < Columns; column++)
            {
                if (IsColumnValid(column))
                {
                    (row, isPlayed) = findLowestRowFreeCellToInsertForAI(column);
                    if (isPlayed)
                    {
                        GameBoard[row, column] = i_Coin;
                        if (CheckForWin() != 0)
                        {
                            GameBoard[row, column] = ' ';
                            columnToReturn = column;
                            break;
                        }

                        GameBoard[row, column] = ' ';
                    }
                }
            }

            return columnToReturn;
        }

        private int findBestMove()
        {
            int bestMove = -1;
            int highestScore = int.MinValue;
            int row;
            bool isPlayed;

            for (int column = 0; column < Columns; column++)
            {
                if (IsColumnValid(column))
                {
                    (row, isPlayed) = findLowestRowFreeCellToInsertForAI(column);
                    if (isPlayed)
                    {
                        GameBoard[row, column] = 'X';
                        int moveScore = scorePosition(row, column);
                        GameBoard[row, column] = ' ';
                        if (moveScore > highestScore)
                        {
                            highestScore = moveScore;
                            bestMove = column;
                        }
                    }
                }
            }

            return bestMove != -1 ? bestMove : randomMove();
        }

        private int scorePosition(int i_Row, int i_Column)
        {
            Random random = new Random();

            return random.Next(0, 100);
        }

        private int randomMove()
        {
            Random random = new Random();
            int column;

            do
            {
                column = random.Next(0, Columns);
            }
            while (!IsColumnValid(column));

            return column;
        }

        private void makeMove(int i_Column, char i_Coin)
        {
            (int row, bool isPlayed) = findLowestRowFreeCellToInsertForAI(i_Column);

            if (isPlayed)
            {
                InsertCellCoin(i_Coin, row, i_Column);
            }
        }

        private (int, bool) findLowestRowFreeCellToInsertForAI(int i_Column)
        {
            int row = -1;
            bool isFreeCellAvailable = false;

            for (int i = Rows - 1; i >= 0; i--)
            {
                if (GameBoard[i, i_Column] == ' ')
                {
                    row = i;
                    isFreeCellAvailable = true;
                    break;
                }
            }

            return (row, isFreeCellAvailable);
        }

        public bool IsColumnValid(int i_Column)
        {
            return GameBoard[0, i_Column] == ' ';
        }

        public int CheckForWin()
        {
            int winner = 0;

            if (checkFourInARow('O'))
            {
                winner = 1;
            }

            if (checkFourInARow('X'))
            {
                winner = 2;
            }

            return winner;
        }

        private bool checkFourInARow(char i_PlayerCoin)
        {
            int rows = Rows;
            int columns = Columns;
            bool fourFounded = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= columns - 4; col++)
                {
                    if (GameBoard[row, col] == i_PlayerCoin &&
                        GameBoard[row, col + 1] == i_PlayerCoin &&
                        GameBoard[row, col + 2] == i_PlayerCoin &&
                        GameBoard[row, col + 3] == i_PlayerCoin)
                    {
                        fourFounded = true;
                    }
                }
            }

            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row <= rows - 4; row++)
                {
                    if (GameBoard[row, col] == i_PlayerCoin &&
                        GameBoard[row + 1, col] == i_PlayerCoin &&
                        GameBoard[row + 2, col] == i_PlayerCoin &&
                        GameBoard[row + 3, col] == i_PlayerCoin)
                    {
                        fourFounded = true;
                    }
                }
            }

            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = 0; col <= columns - 4; col++)
                {
                    if (GameBoard[row, col] == i_PlayerCoin &&
                        GameBoard[row + 1, col + 1] == i_PlayerCoin &&
                        GameBoard[row + 2, col + 2] == i_PlayerCoin &&
                        GameBoard[row + 3, col + 3] == i_PlayerCoin)
                    {
                        fourFounded = true;
                    }
                }
            }

            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = 3; col < columns; col++)
                {
                    if (GameBoard[row, col] == i_PlayerCoin &&
                        GameBoard[row + 1, col - 1] == i_PlayerCoin &&
                        GameBoard[row + 2, col - 2] == i_PlayerCoin &&
                        GameBoard[row + 3, col - 3] == i_PlayerCoin)
                    {
                        fourFounded = true;
                    }
                }
            }

            return fourFounded;
        }

        public void ResetBoard()
        {
            InitializeGameBoard();
            CoinsInserted = 0;
        }
    }
}