using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    internal class typeOfMovesChess
    {
        // di chuyển theo chiều dọc và chiều đối với quân cờ đen
        public int[,] BlackVerticalAndHorizontalMoves(int[,] board, int[,] possibleMoves, int i, int j)
        {
            //di chuyển theo chiều dọc 
            for (int posY = i - 1; posY >= 0; posY--)
            {
                if (board[posY, j] == 0)
                {
                    possibleMoves[posY, j] = 2;
                }
                else
                {
                    if (board[posY, j] < 10) break;
                    else
                    {
                        possibleMoves[posY, j] = 2;
                        if (board[posY, j] > 10) break;
                    }
                }
            }
            for (int posY = i + 1; posY < 8; posY++)
            {
                if (board[posY, j] == 0)
                {
                    possibleMoves[posY, j] = 2;
                }
                else
                {
                    if (board[posY, j] < 10) break;
                    else
                    {
                        possibleMoves[posY, j] = 2;
                        if (board[posY, j] > 10) break;
                    }
                }
            }
            //tiến hành di chuyển theo chiều ngang
            for (int posX = j - 1; posX >= 0; posX--)
            {
                if (board[i, posX] == 0)
                {
                    possibleMoves[i, posX] = 2;
                }
                else
                {
                    if (board[i, posX] < 10) break;
                    else
                    {
                        possibleMoves[i, posX] = 2;
                        if (board[i, posX] > 10) break;
                    }
                }
            }
            for (int posX = j + 1; posX < 8; posX++)
            {
                if (board[i, posX] == 0)
                {
                    possibleMoves[i, posX] = 2;
                }
                else
                {
                    if (board[i, posX] < 10) break;
                    else
                    {
                        possibleMoves[i, posX] = 2;
                        if (board[i, posX] > 10) break;
                    }
                }
            }
            return possibleMoves;
        }
        //di chuyển dọc và ngang đối với quân cờ trắng
        public int[,] WhiteVerticalAndHorizontalMoves(int[,] board, int[,] possibleMoves, int i, int j)
        {
            //di chuyển theo chiều dọc
            for (int posY = i - 1; posY >= 0; posY--)
            {
                if (board[posY, j] == 0)
                {
                    possibleMoves[posY, j] = 2;
                }
                else
                {
                    if (board[posY, j] > 10) break;
                    else
                    {
                        possibleMoves[posY, j] = 2;
                        if (board[posY, j] < 10) break;
                    }
                }
            }
            for (int posY = i + 1; posY < 8; posY++)
            {
                if (board[posY, j] == 0)
                {
                    possibleMoves[posY, j] = 2;
                }
                else
                {
                    if (board[posY, j] > 10) break;
                    else
                    {
                        possibleMoves[posY, j] = 2;
                        if (board[posY, j] < 10) break;
                    }
                }
            }
            //tiến hành di chuyển theo chiều ngang
            for (int posX = j - 1; posX >= 0; posX--)
            {
                if (board[i, posX] == 0)
                {
                    possibleMoves[i, posX] = 2;
                }
                else
                {
                    if (board[i, posX] > 10) break;
                    else
                    {
                        possibleMoves[i, posX] = 2;
                        if (board[i, posX] < 10) break;
                    }
                }
            }
            for (int posX = j + 1; posX < 8; posX++)
            {
                if (board[i, posX] == 0)
                {
                    possibleMoves[i, posX] = 2;
                }
                else
                {
                    if (board[i, posX] > 10) break;
                    else
                    {
                        possibleMoves[i, posX] = 2;
                        if (board[i, posX] < 10) break;
                    }
                }
            }
            return possibleMoves;
        }
        // di chuyển hình chữ L với quân cờ đen
        public int[,] BlackHorseMove(int[,] board, int[,] possibleMoves, int i, int j)
        {
            //di chuyển xuống
            if (i - 2 >= 0)
            {
                //di chuyển sang bên trái
                if (j - 1 >= 0)
                {
                    if (board[i - 2, j - 1] == 0 || board[i - 2, j - 1] > 10)
                    {
                        possibleMoves[i - 2, j - 1] = 2;
                    }
                }
                //di chuyển sang bên phải
                if (j + 1 < 8)
                {
                    if (board[i - 2, j + 1] == 0 || board[i - 2, j + 1] > 10)
                    {
                        possibleMoves[i - 2, j + 1] = 2;
                    }
                }
            }
            //di chuyển lên
            if (i + 2 < 8)
            {
                //di chuyển sang bên trái
                if (j - 1 >= 0)
                {
                    if (board[i + 2, j - 1] == 0 || board[i + 2, j - 1] > 10)
                    {
                        possibleMoves[i + 2, j - 1] = 2;
                    }
                }
                //di chuyển sang bên phải
                if (j + 1 < 8)
                {
                    if (board[i + 2, j + 1] == 0 || board[i + 2, j + 1] > 10)
                    {
                        possibleMoves[i + 2, j + 1] = 2;
                    }
                }
            }

            //di chuyển sang trái
            if (j - 2 >= 0)
            {
                //di chuyển xuống dưới
                if (i - 1 >= 0)
                {
                    if (board[i - 1, j - 2] == 0 || board[i - 1, j - 2] > 10)
                    {
                        possibleMoves[i - 1, j - 2] = 2;
                    }
                }
                //di chuyển lên trên
                if (i + 1 < 8)
                {
                    if (board[i + 1, j - 2] == 0 || board[i + 1, j - 2] > 10)
                    {
                        possibleMoves[i + 1, j - 2] = 2;
                    }
                }
            }
            //di chuyển sang phải
            if (j + 2 < 8)
            {
                //di chuyển xuống dưới
                if (i - 1 >= 0)
                {
                    if (board[i - 1, j + 2] == 0 || board[i - 1, j + 2] > 10)
                    {
                        possibleMoves[i - 1, j + 2] = 2;
                    }
                }
                //di chuyển lên trên
                if (i + 1 < 8)
                {
                    if (board[i + 1, j + 2] == 0 || board[i + 1, j + 2] > 10)
                    {
                        possibleMoves[i + 1, j + 2] = 2;
                    }
                }
            }

            return possibleMoves;
        }
        // di chuyển hình chữ L với quân cờ trắng
        public int[,] WhiteHorseMove(int[,] board, int[,] possibleMoves, int i, int j)
        {
            //di chuyển xuống
            if (i - 2 >= 0)
            {
                //di chuyển sang bên trái
                if (j - 1 >= 0)
                {
                    if (board[i - 2, j - 1] == 0 || board[i - 2, j - 1] < 10)
                    {
                        possibleMoves[i - 2, j - 1] = 2;
                    }
                }
                //di chuyển sang bên phải
                if (j + 1 < 8)
                {
                    if (board[i - 2, j + 1] == 0 || board[i - 2, j + 1] < 10)
                    {
                        possibleMoves[i - 2, j + 1] = 2;
                    }
                }
            }
            //di chuyển lên
            if (i + 2 < 8)
            {
                //di chuyển sang bên trái
                if (j - 1 >= 0)
                {
                    if (board[i + 2, j - 1] == 0 || board[i + 2, j - 1] < 10)
                    {
                        possibleMoves[i + 2, j - 1] = 2;
                    }
                }
                //di chuyển sang bên phải
                if (j + 1 < 8)
                {
                    if (board[i + 2, j + 1] == 0 || board[i + 2, j + 1] < 10)
                    {
                        possibleMoves[i + 2, j + 1] = 2;
                    }
                }
            }

            //di chuyển sang trái
            if (j - 2 >= 0)
            {
                //di chuyển xuống dưới
                if (i - 1 >= 0)
                {
                    if (board[i - 1, j - 2] == 0 || board[i - 1, j - 2] < 10)
                    {
                        possibleMoves[i - 1, j - 2] = 2;
                    }
                }
                //di chuyển lên trên
                if (i + 1 < 8)
                {
                    if (board[i + 1, j - 2] == 0 || board[i + 1, j - 2] < 10)
                    {
                        possibleMoves[i + 1, j - 2] = 2;
                    }
                }
            }
            //di chuyển sang phải
            if (j + 2 < 8)
            {
                //di chuyển xuống dưới
                if (i - 1 >= 0)
                {
                    if (board[i - 1, j + 2] == 0 || board[i - 1, j + 2] < 10)
                    {
                        possibleMoves[i - 1, j + 2] = 2;
                    }
                }
                //di chuyển lên trên
                if (i + 1 < 8)
                {
                    if (board[i + 1, j + 2] == 0 || board[i + 1, j + 2] < 10)
                    {
                        possibleMoves[i + 1, j + 2] = 2;
                    }
                }
            }

            return possibleMoves;
        }
        //di chuyển chéo với quân cờ đen
        public int[,] BlackDiagonalMoves(int[,] board, int[,] possibleMoves, int i, int j)
        {
            //di chuyển từ trái lên
            for (int pos = 1; pos < 8; pos++)
            {
                if (i - pos >= 0 && j - pos >= 0)
                {
                    if (board[i - pos, j - pos] == 0 || board[i - pos, j - pos] > 10)
                    {
                        possibleMoves[i - pos, j - pos] = 2;
                        if (board[i - pos, j - pos] > 10)
                            break;
                    }
                    else
                        break;
                }
            }
            //trường hợp di chuyển chéo trái
            for (int pos = 1; pos < 8; pos++)
            {
                if (i + pos < 8 && j - pos >= 0)
                {
                    if (board[i + pos, j - pos] == 0 || board[i + pos, j - pos] > 10)
                    {
                        possibleMoves[i + pos, j - pos] = 2;
                        if (board[i + pos, j - pos] > 10)
                            break;
                    }
                    else
                        break;
                }
            }
            //trường hợp di chuyển chéo trái
            for (int pos = 1; pos < 8; pos++)
            {
                if (i - pos >= 0 && j + pos < 8)
                {
                    if (board[i - pos, j + pos] == 0 || board[i - pos, j + pos] > 10)
                    {
                        possibleMoves[i - pos, j + pos] = 2;
                        if (board[i - pos, j + pos] > 10)
                            break;
                    }
                    else
                        break;
                }
            }
            for (int pos = 1; pos < 8; pos++)
            {
                if (i + pos < 8 && j + pos < 8)
                {
                    if (board[i + pos, j + pos] == 0 || board[i + pos, j + pos] > 10)
                    {
                        possibleMoves[i + pos, j + pos] = 2;
                        if (board[i + pos, j + pos] > 10) break;
                    }
                    else
                        break;
                }
            }
            return possibleMoves;
        }
        //di chuyển chéo với quân cờ trắng
        public int[,] WhiteDiagonalMoves(int[,] board, int[,] possibleMoves, int i, int j)
        {
            //di chuyển từ trái lên
            for (int pos = 1; pos < 8; pos++)
            {
                if (i - pos >= 0 && j - pos >= 0)
                {
                    if (board[i - pos, j - pos] == 0 || board[i - pos, j - pos] < 10)
                    {
                        possibleMoves[i - pos, j - pos] = 2;
                        if (board[i - pos, j - pos] < 10 && board[i - pos, j - pos] != 0)
                            break;
                    }
                    else
                        break;
                }
            }
            //trường hợp di chuyển chéo trái
            for (int pos = 1; pos < 8; pos++)
            {
                if (i + pos < 8 && j - pos >= 0)
                {
                    if (board[i + pos, j - pos] == 0 || board[i + pos, j - pos] < 10)
                    {
                        possibleMoves[i + pos, j - pos] = 2;
                        if (board[i + pos, j - pos] < 10 && board[i + pos, j - pos] != 0)
                            break;
                    }
                    else
                        break;
                }
            }
            //trường hợp di chuyển chéo trái
            for (int pos = 1; pos < 8; pos++)
            {
                if (i - pos >= 0 && j + pos < 8)
                {
                    if (board[i - pos, j + pos] == 0 || board[i - pos, j + pos] < 10)
                    {
                        possibleMoves[i - pos, j + pos] = 2;
                        if (board[i - pos, j + pos] < 10 && board[i - pos, j + pos] != 0)
                            break;
                    }
                    else
                        break;
                }
            }
            for (int pos = 1; pos < 8; pos++)
            {
                if (i + pos < 8 && j + pos < 8)
                {
                    if (board[i + pos, j + pos] == 0 || board[i + pos, j + pos] < 10)
                    {
                        possibleMoves[i + pos, j + pos] = 2;
                        if (board[i + pos, j + pos] < 10 && board[i + pos, j + pos] != 0)
                            break;
                    }
                    else
                        break;
                }
            }
            return possibleMoves;
        }
    }
}
