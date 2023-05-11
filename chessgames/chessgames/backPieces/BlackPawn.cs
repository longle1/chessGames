using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames.backPieces
{
    internal class BlackPawn
    {
        public int[,] getPossibleMoves(int[,] board, int[,] possibleMoves, int j, int i, bool blackTurn)
        {
            if (!blackTurn)
                return possibleMoves;
            //Trường hợp quân cờ đi được 1 nút
            if (i + 1 < 8)
            {
                if (board[i + 1, j] == 0)
                {
                    possibleMoves[i + 1, j] = 2;
                }
                //đây là trường hợp ăn quân cờ của đối phương theo đường chéo bên trái
                if (j - 1 >= 0)
                {
                    if (board[i + 1, j - 1] > 10 && board[i + 1, j - 1] != 0)
                    {
                        possibleMoves[i + 1, j - 1] = 2;
                    }
                }
                //Đây là trường hợp ăn quân cờ ở đường chéo bên phải
                if (j + 1 < 8)
                {
                    if (board[i + 1, j + 1] > 10 && board[i + 1, j + 1] != 0)
                    {
                        possibleMoves[i + 1, j + 1] = 2;
                    }
                }
            }

            //Đây là trường hợp quân tốt đi được 2 ô 
            if (i == 1)
            {

                if (board[i + 1, j] == 0 && board[i + 2, j] == 0)
                {
                    possibleMoves[i + 2, j] = 2;
                }
            }
            return possibleMoves;
        }
        public int[,] isStale(int[,] board, int[,] possibleMoves)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 01)
                    {
                        if (i - 1 >= 0)
                            //Hất quân cờ của đối phương sang trái
                            if (j - 1 >= 0)
                                if (board[i + 1, j - 1] > 10)
                                    possibleMoves[i + 1, j - 1] = 2;
                        //Hất quân cờ của đối phương sang phải
                        if (j + 1 < 8)
                            if (board[i + 1, j + 1] > 10)
                                possibleMoves[i + 1, j + 1] = 2;
                    }
                }
            }
            return possibleMoves;
        }
    }
}
