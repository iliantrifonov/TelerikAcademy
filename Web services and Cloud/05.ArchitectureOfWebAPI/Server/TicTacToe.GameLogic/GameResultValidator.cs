namespace TicTacToe.GameLogic
{
    using System;
    public class GameResultValidator : IGameResultValidator
    {
        // O-X
        // O-X
        // --X
        public GameResult GetResult(string board)
        {
            var boardAsMatrix = new char[3, 3];
            var index = 0;
            var countX = 0;
            var countO = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    boardAsMatrix[i, j] = board[index];
                    if (board[index] == 'X')
                    {
                        countX++;
                    }
                    else if (board[index] == 'O')
                    {
                        countO++;
                    }

                    index++;
                }
            }

            if (Math.Abs(countO - countX) > 1)
            {
                return GameResult.Invalid;
            }

            var previous = ':';
            //check on each row
            for (int i = 0; i < 3; i++)
            {
                var firstChar = boardAsMatrix[i, 0];
                if (firstChar != 'X' && firstChar != 'O')
                {
                    continue;
                }

                var count = 1;
                for (int j = 1; j < 3; j++)
                {
                    if (firstChar == boardAsMatrix[i, j])
                    {
                        count++;
                    }
                }

                if (count == 3)
                {
                    if (firstChar == 'X')
                    {
                        return GameResult.WonByX;
                    }
                    else
                    {
                        return GameResult.WonByO;
                    }
                }
            }

            // check col
            for (int i = 0; i < 3; i++)
            {
                var firstCharCol = boardAsMatrix[0, i];
                if (firstCharCol != 'X' && firstCharCol != 'O')
                {
                    continue;
                }

                var countCol = 1;
                for (int j = 1; j < 3; j++)
                {
                    if (firstCharCol == boardAsMatrix[j, i])
                    {
                        countCol++;
                    }
                }

                if (countCol == 3)
                {
                    if (firstCharCol == 'X')
                    {
                        return GameResult.WonByX;
                    }
                    else
                    {
                        return GameResult.WonByO;
                    }
                }
            }


            var firstCharDiagonal = boardAsMatrix[0, 0];
            var countDiagonalOne = 1;
            for (int i = 1; i < 3; i++)
            {
                if (firstCharDiagonal != 'X' && firstCharDiagonal != 'O')
                {
                    break;
                }

                if (firstCharDiagonal == boardAsMatrix[i, i])
                {
                    countDiagonalOne++;
                }
            }

            if (countDiagonalOne == 3)
            {
                if (firstCharDiagonal == 'X')
                {
                    return GameResult.WonByX;
                }
                else
                {
                    return GameResult.WonByO;
                }
            }

            var row = 2;
            var col = 0;
            firstCharDiagonal = boardAsMatrix[row, col];
            var countDiagonalTwo = 1;
            for (int i = 1; i < 3; i++)
            {
                if (firstCharDiagonal != 'X' && firstCharDiagonal != 'O')
                {
                    break;
                }

                if (firstCharDiagonal == boardAsMatrix[row - i, col + i])
                {
                    countDiagonalTwo++;
                }
            }

            if (countDiagonalTwo == 3)
            {
                if (firstCharDiagonal == 'X')
                {
                    return GameResult.WonByX;
                }
                else
                {
                    return GameResult.WonByO;
                }
            }

            if (board.Contains("-"))
            {
                return GameResult.NotFinished;
            }

            return GameResult.Draw;
        }
    }
}
