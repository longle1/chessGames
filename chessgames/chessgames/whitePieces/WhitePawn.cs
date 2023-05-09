using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames.whitePieces
{
    internal class WhitePawn
    {
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool whiteTurn)
        {
            if (!whiteTurn)
                return possibleMoves;
            if (i - 1 >= 0)
                //đối với trường hợp di chuyển 1 ô lên trên
                if (board[i - 1, j] == 0) possibleMoves[i - 1, j] = 2;
                //trường hợp ăn quân cờ chéo bên trái
                if (j - 1 >= 0)
                    if (board[i - 1, j - 1] < 10 && board[i - 1, j - 1] != 0)
                        possibleMoves[i - 1, j - 1] = 2;
                //trường hợp ăn quân cờ chéo bên phải
                if (j + 1 < 8)
                    if (board[i - 1, j + 1] < 10 && board[i - 1, j + 1] != 0)
                        possibleMoves[i - 1, j + 1] = 2;
            //trường hợp quân cờ di chuyển 2 ô nhưng khi ở vị trí đầu tiên
            if (i == 6)
                if (board[i - 2, j] == 0 && board[i - 1, j] == 0) possibleMoves[i - 2, j] = 2;

            return possibleMoves;
        }
        public int[,] isStale(int[,] board, int[,] possibleMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 11)
                    {
                        if(i - 1 >= 0)
                        {
                            if (j - 1 >= 0)
                                if (board[i - 1, j - 1] < 10 && board[i - 1, j - 1] != 0)
                                    possibleMoves[i - 1, j - 1] = 2;
                            if (j + 1 < 8)
                                if (board[i - 1, j + 1] < 10 && board[i - 1, j + 1] != 0)
                                    possibleMoves[i - 1, j + 1] = 2;
                        }
                    }    
                }
            }
            return possibleMoves;
        }
    }
}
