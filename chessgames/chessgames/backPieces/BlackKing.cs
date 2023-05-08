using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames.backPieces
{
    internal class BlackKing
    {
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool blackTurn, bool castlingBlackKing, bool castlingBlackRock1, bool castlingBlackRock2)
        {
            if (!blackTurn)
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

            //xử lý cho việc nhập thành
            //nhập thành xa
            if (castlingBlackKing && castlingBlackRock1)
            {
                if (board[0, 1] == 0 && board[0, 2] == 0 && board[0, 3]  == 0)
                {
                    for (int pos = 1; pos < 8; pos++)
                    {
                        if (j - pos >= 0)
                        {
                            if(pos == 1 && board[i, j - pos] == 0)
                            {
                                possibleMoves[i, j - pos] = 2;
                                continue;
                            }
                            possibleMoves[i, j - pos] = 4;
                        }
                    }
                }
            }
            //nhập thành gần
            if (castlingBlackKing && castlingBlackRock2)
            {
                if (board[0, 5] == 0 && board[0, 6] == 0)
                {
                    for (int pos = 1; pos < 8; pos++)
                    {
                        if (j + pos < 8)
                        {
                            if (pos == 1 && board[i, j + pos] == 0)
                            {
                                possibleMoves[i, j + pos] = 2;
                                continue;
                            }
                            possibleMoves[i, j + pos] = 4;
                        }
                    }

                }
            }
            return possibleMoves;
        }
    }
}
