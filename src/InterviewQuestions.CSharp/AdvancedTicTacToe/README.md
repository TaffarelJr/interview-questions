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
    /// <param name="n">n×n dimension for the game board</param>
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

## Comments

Since the game board size (<i>n</i>) appears to be a one-based number (as opposed to zero-based), I assume the `row` and `col` coordinates being passed in are also one-based for consistency. Internally, the method translates this to zero-based indexes for the jagged array that represents the game board.

While the instructions say all input to the game will be "valid moves," it also says I need to check if the game is over and not allow additional moves beyond that point. So clearly I must perform at least _some_ parameter validation. I opted to be thorough instead, and simply include all the validation. It was only a few extra lines; and I really dislike skipping parameter validation anyways. :) If this method were to be part of i.e. a high-performance game loop, I could take out several of the parameter validation checks and instead make sure the UI prevented out-of-range values. But the other validation must remain.

Each time a piece is placed on the game board, the code checks for win conditions in the current row & column. It also checks both diagnoals, but I included short-circuiting logic so it only does so if the coordinates are part of either diagnoal.

I broke out the win condition checks into private methods to make the main function more concise.

I created constants for the player numbers, to make them more visible.

I converted several internal fields into public read-only properties, so those values could be seen outside the class. This helped with visibility during testing, and might also be useful in UI displays. I did not expose the game board array itself, because doing so would expose it to alteration from outside the class. If that feature is necessary, some other means of exposing it would be required.
