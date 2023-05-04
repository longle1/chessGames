﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames.backPieces
{
    internal class BlackKing
    {
        typeOfMovesChess type = new typeOfMovesChess();
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool whiteTurn, bool otherPlayerTurn)
        {
            if (whiteTurn || otherPlayerTurn)
                return possibleMoves;

            //di chuyển quân vua sang trái
            if (i >= 0)
            {
                if (j - 1 >= 0)
                {
                    if (board[i, j - 1] == 0 || board[i, j - 1] > 10)
                    {
                        possibleMoves[i, j - 1] = 2;
                    }
                }
            }
            //di chuyển sang phải
            if (i >= 0)
            {
                if (j + 1 < 8)
                {
                    if (board[i, j + 1] == 0 || board[i, j + 1] > 10)
                    {
                        possibleMoves[i, j + 1] = 2;
                    }
                }
            }
            //di chuyển thằng lên trên
            if (j >= 0)
            {
                if (i + 1 < 8)
                {
                    if (board[i + 1, j] == 0 || board[i + 1, j] > 10)
                    {
                        possibleMoves[i + 1, j] = 2;
                    }
                }
            }
            //di chuyển thẳng xuống dưới
            if (j >= 0)
            {
                if (i - 1 >= 0)
                {
                    if (board[i - 1, j] == 0 || board[i - 1, j] > 10)
                    {
                        possibleMoves[i - 1, j] = 2;
                    }
                }
            }
            //di chuyển góc chéo xuống bên trái
            if (i - 1 >= 0)
            {
                if (j - 1 >= 0)
                {
                    if (board[i - 1, j - 1] == 0 || board[i - 1, j - 1] > 10)
                    {
                        possibleMoves[i - 1, j - 1] = 2;
                    }
                }
            }
            //di chuyển góc chéo xuống bên phải
            if (i - 1 >= 0)
            {
                if (j + 1 < 8)
                {
                    if (board[i - 1, j + 1] == 0 || board[i - 1, j + 1] > 10)
                    {
                        possibleMoves[i - 1, j + 1] = 2;
                    }
                }
            }
            //di chuyển góc chéo lên bên trái
            if (i + 1 < 8)
            {
                if (j - 1 >= 0)
                {
                    if (board[i + 1, j - 1] == 0 || board[i + 1, j - 1] > 10)
                    {
                        possibleMoves[i + 1, j - 1] = 2;
                    }
                }
            }
            //di chuyển góc chéo lên bên phải
            if (i + 1 < 8)
            {
                if (j + 1 < 8)
                {
                    if (board[i + 1, j + 1] == 0 || board[i + 1, j + 1] > 10)
                    {
                        possibleMoves[i + 1, j + 1] = 2;
                    }
                }
            }
            return possibleMoves;
        }
    }
}
