# Advanced Tic-Tac-Toe

Design a Tic-Tac-Toe game that can be played on an _n×n_ grid by two players.

It can be assumed that all inputs into the game will be valid moves.

After a winning condition is reached, no more moves will be allowed.

The winning condition is to place n pieces either horizontally, vertically or diagonally.

## Starting Point

The structure of this game will be as follows:

```csharp
public class TicTacToe
{
    /// <summary>
    /// Created a Tic Tac Tow game board
    /// </summary>
    /// <param name="n">nxn dimension for the game board</param>
    public TicTacToe(int n)
    {

    }

    /// <summary>
    /// Place a piece on the game board
    /// </summary>
    /// <param name="row">row to place a piece</param>
    /// <param name="col">column to place a piece</param>
    /// <param name="player">the player (1 or 2) the piece is for</param>
    /// <returns>0 = no winner, 1 = player 1 won, 2 = player 2 won</returns>
    public int PlacePiece(int row, int col, int player)
    {

    }
}
```
