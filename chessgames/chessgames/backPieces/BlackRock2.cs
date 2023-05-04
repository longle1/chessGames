using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames.backPieces
{
    internal class BlackRock2
    {
        typeOfMovesChess type = new typeOfMovesChess();
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool whiteTurn, bool otherPlayerTurn)
        {
            if (whiteTurn || otherPlayerTurn)
                return possibleMoves;

            possibleMoves = type.BlackVerticalAndHorizontalMoves(board, possibleMoves, i, j);
            return possibleMoves;
        }
        public int[,] isStale(int[,] board, int[,] possibleMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 07)
                    {
                        possibleMoves = type.BlackVerticalAndHorizontalMoves(board, possibleMoves, i, j);
                    }
                }
            }
            return possibleMoves;
        }
    }
}
