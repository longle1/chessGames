﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames.whitePieces
{
    internal class WhiteRock2
    {
        typeOfMovesChess type = new typeOfMovesChess();
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool whiteTurn)
        {
            if (!whiteTurn)
                return possibleMoves;
            possibleMoves = type.WhiteVerticalAndHorizontalMoves(board, possibleMoves, i, j);
            return possibleMoves;
        }
        public int[,] isStale(int[,] board, int[,] possibleMoves)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (board[i, j] == 17)
                        possibleMoves = type.WhiteVerticalAndHorizontalMoves(board, possibleMoves, i, j);
            return possibleMoves;
        }
    }
}
