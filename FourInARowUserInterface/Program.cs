namespace FourInARow
{
    // Pseudo:
    // 1. Use printer for main menu screen.                                                                                              <---- /// <DONE> ///
    // 2. Get the user input for start game or exit.                                                                                     <---- /// <DONE> ///
    // 3. While starting new game:                                                                                                       <---- /// <DONE> ///
    //  3.1. Get user board size by from 4x4 to 8x8 (also rectangle is possible).                                                        <---- /// <DONE> ///
    //  3.2. Get user choice of playing against PC or Local-2Players.                                                                    <---- /// <DONE> ///
    // 4. Start Game with empty matrix (Spaces for every cell) and animate a flip coin (random bts) to choose who start the game.        <---- /// <DONE> ///
    // 5. On player's turn, he need to choose a column to insert his coin or 'q' to surrender.                                           <---- /// <DONE> ///
    //  5.1. Check if user input is 'q' then end the game and let the other player win!.                                                 <---- /// <DONE> ///
    //  5.2. Check if number in board.                                                                                                   <---- /// <DONE> ///
    //  5.3. Check if column is full.                                                                                                    <---- /// <DONE> ///
    //  5.4. If possible -> insert coin by changing the most bottom empty cell in the column to "X" or "O" (Player Coin Type).           <---- /// <DONE> ///
    //  5.5. Check for 4 in a row.                                                                                                       <---- /// <DONE> ///
    //   5.5.1. True -> Current Player Won!                                                                                              <---- /// <DONE> ///
    //   5.5.2. Flase If -> Check if counter of coins equals to matrix cells amount and if true end the game as a draw!                  <---- /// <DONE> ///
    //   5.5.3. False Else -> Next Player Turn.                                                                                          <---- /// <DONE> ///
    // 6. While game end ask for restart on the same size of board against the same opponent.                                            <---- /// <DONE> ///

    public class FourInARow
    {
        public static void Main()
        {
            GameManager gameManager = new GameManager();
            gameManager.RunFourInARowGame();
        }
    }
}