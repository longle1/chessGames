using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames.whitePieces
{
    internal class WhiteKing
    {
        typeOfMovesChess type = new typeOfMovesChess();
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool whiteTurn, bool otherPlayerTurn)
        {
            if (!whiteTurn || otherPlayerTurn)
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
            return possibleMoves;
        }
    }
}
