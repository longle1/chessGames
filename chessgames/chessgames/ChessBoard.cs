using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace chessgames
{
    internal class ChessBoard
    {
        //chứa bàn cờ
        private int[,] board;
        public int[,] Board { get => board; set => board = value; }
        //các trạng thái có thể di chuyển
        private int[,] possibleMoves;
        public int[,] PossibleMoves { get => possibleMoves; set => possibleMoves = value; }
        public int[,] AllPossibleMoves { get => allPossibleMoves; set => allPossibleMoves = value; }
        private int[,] allPossibleMoves;

        public bool WhiteStaleUp = false;
        public bool BlackStaleUp = false;
        public bool CancelLastMove = false;

        //dùng cho quân cờ vua
        public bool markStale(userControlClick[,] tableBackground, int[,] board, int[,] WhiteStaleArray, int[,] BlackStaleArray)
        {

            int WhiteKingPositionI = 0;
            int WhiteKingPositionJ = 0;
            int BlackKingPositionI = 0;
            int BlackKingPositionJ = 0;
            WhiteStaleUp = false;
            BlackStaleUp = false;


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 16)
                    {
                        WhiteKingPositionI = i;
                        WhiteKingPositionJ = j;
                    }
                    if (board[i, j] == 06)
                    {
                        BlackKingPositionI = i;
                        BlackKingPositionJ = j;
                    }
                }
            }
            if (WhiteStaleArray[WhiteKingPositionI, WhiteKingPositionJ] == 2)
            {
                tableBackground[WhiteKingPositionI, WhiteKingPositionJ].BackColor = Color.Red;
                WhiteStaleUp = true;
                return true;
            }
            if (BlackStaleArray[BlackKingPositionI, BlackKingPositionJ] == 2)
            {
                tableBackground[BlackKingPositionI, BlackKingPositionJ].BackColor = Color.Red;
                BlackStaleUp = true;
                return true;
            }
            return false;
        }
        public int notValidMoveChecker(int[,] board, int[,] whiteStaleArrays, int[,] blackStaleArrays)
        {
            int WhitePositionKingI = 0;
            int WhitePositionKingJ = 0;
            int BlackPositionKingI = 0;
            int BlackPositionKingJ = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //black king
                    if (board[i, j] == 06)
                    {
                        BlackPositionKingI = i;
                        BlackPositionKingJ = j;
                    }
                    //white king
                    else if (board[i, j] == 16)
                    {
                        WhitePositionKingI = i;
                        WhitePositionKingJ = j;
                    }
                }
            }
            if (whiteStaleArrays[WhitePositionKingI, WhitePositionKingJ] == 2) return 1;
            if (blackStaleArrays[BlackPositionKingI, BlackPositionKingJ] == 2) return 2;
            return 0;
        }
    }
}
