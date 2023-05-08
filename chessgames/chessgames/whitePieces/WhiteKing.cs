using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames.whitePieces
{
    internal class WhiteKing
    {
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool whiteTurn, bool castlingWhiteKing, bool castlingWhiteRock1, bool castlingWhiteRock2)
        {
            if (!whiteTurn)
                return possibleMoves;
            //di chuyển thẳng lên trên
            if (i - 1 >= 0)
                if (board[i - 1, j] == 0 || board[i - 1, j] < 10) possibleMoves[i - 1, j] = 2;
            //di chuyển thằng xuống dưới
            if (i + 1 < 8)
                if (board[i + 1, j] == 0 || board[i + 1, j] < 10) possibleMoves[i + 1, j] = 2;
            //di chuyển ngang bên trái
            if (j - 1 >= 0)
                if (board[i, j - 1] == 0 || board[i, j - 1] < 10) possibleMoves[i, j - 1] = 2;
            //di chuyển ngang bên phải
            if (j + 1 < 8)
                if (board[i, j + 1] == 0 || board[i, j + 1] < 10) possibleMoves[i, j + 1] = 2;
            //di chuyển chéo lên trên phía trái
            if (i - 1 >= 0)
                if (j - 1 >= 0)
                    if (board[i - 1, j - 1] == 0 || board[i - 1, j - 1] < 10) possibleMoves[i - 1, j - 1] = 2;
            //di chuyển chéo lên trên phía phải
            if (i - 1 >= 0)
                if (j + 1 < 8)
                    if (board[i - 1, j + 1] == 0 || board[i - 1, j + 1] < 10) possibleMoves[i - 1, j + 1] = 2;
            //di chuyển chéo xuống dưới phía trái
            if (i + 1 < 8)
                if (j - 1 >= 0)
                    if (board[i + 1, j - 1] == 0 || board[i + 1, j - 1] < 10) possibleMoves[i + 1, j - 1] = 2;
            //di chuyển chéo xuống dưới phái phải
            if (i + 1 < 8)
                if (j + 1 < 8)
                    if (board[i + 1, j + 1] == 0 || board[i + 1, j + 1] < 10) possibleMoves[i + 1, j + 1] = 2;

            //xử lý cho việc nhập thành
            //nhập thành xa
            if (castlingWhiteKing && castlingWhiteRock1)
            {
                if (board[7, 1] == 0 && board[7, 2] == 0 && board[7, 3] == 0)
                {
                    for (int pos = 1; pos < 8; pos++)
                    {
                        if (j - pos >= 0)
                        {
                            if (pos == 1 && board[i, j - pos] == 0)
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
            if (castlingWhiteKing && castlingWhiteRock2)
            {
                if (board[7, 5] == 0 && board[7, 6] == 0)
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
