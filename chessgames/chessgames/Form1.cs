﻿using chessgames.backPieces;
using chessgames.whitePieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace chessgames
{
    public partial class Form1 : Form
    {
        #region pieces
        //khai báo các quân cờ đen
        BlackPawn blackPawn = new BlackPawn();
        BlackRock1 blackRock1 = new BlackRock1();
        BlackRock2 blackRock2 = new BlackRock2();
        BlackKnight1 blackKnight1 = new BlackKnight1();
        BlackKnight2 blackKnight2 = new BlackKnight2();
        BlackBiShop1 blackBiShop1 = new BlackBiShop1();
        BlackBiShop2 blackBiShop2 = new BlackBiShop2();
        BlackQueen blackQueen = new BlackQueen();
        BlackKing blackKing = new BlackKing();
        //khai báo các quân cờ trắng
        WhitePawn whitePawn = new WhitePawn();
        WhiteKnight1 whiteKnight1 = new WhiteKnight1();
        WhiteKnight2 whiteKnight2 = new WhiteKnight2();
        WhiteBiShop1 whiteBiShop1 = new WhiteBiShop1();
        WhiteBiShop2 whiteBiShop2 = new WhiteBiShop2();
        WhiteKing whiteKing = new WhiteKing();
        WhiteQueen whiteQueen = new WhiteQueen();
        WhiteRock1 whiteRock1 = new WhiteRock1();
        WhiteRock2 whiteRock2 = new WhiteRock2();
        #endregion
        #region boolsChess
        public bool whiteTurn = true;
        public bool otherPlayerTurn = false;
        public bool gameOver = false;
        #endregion
        #region integers
        int beforeMove_X;
        int beforeMove_Y;
        int move;
        #endregion
        ChessBoard chessboard = new ChessBoard();
        userControlClick[,] tableBackground;
        public int[,] WhiteStaleArray = new int[8, 8];
        public int[,] BlackStaleArray = new int[8, 8];
        public Form1()
        {
            InitializeComponent();

            //tạo một ma trận có kích thước 8 * 8
            chessboard.Board = new int[8, 8]
            {
                { 02, 03, 04, 05, 06, 09, 08, 07},
                { 01, 01, 01, 01, 01, 01, 01, 01},
                { 00, 00, 00, 00, 00, 00, 00, 00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 11, 11, 11, 11, 11, 11, 11, 11},
                { 12, 13, 14, 15, 16, 19, 18, 17},
            };
            chessboard.PossibleMoves = new int[8, 8];
            tableBackground = new userControlClick[8, 8];
            for (int i = 0; i < 8; i++) // tượng trưng cho các dòng
            {
                for (int j = 0; j < 8; j++) //tượng trưng cho các cột
                {
                    tableBackground[i, j] = new userControlClick();
                    tableBackground[i, j].Parent = this;
                    tableBackground[i, j].Location = new Point(j * 50 + 50, i * 50 + 50);
                    tableBackground[i, j].posX = j;
                    tableBackground[i, j].posY = i;
                    tableBackground[i, j].Size = new Size(50, 50);
                    tableBackground[i, j].Click += tableBackground_Click;
                    if (i % 2 == 0)
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                        else tableBackground[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                    else tableBackground[i, j].BackColor = Color.Brown;
                    tableBackground[i, j].BackgroundImageLayout = ImageLayout.Center;
                }
            }

            // hàm kiểm tra ô nào chứa quân cờ
            getPiecesOnBoard();
            // hiển thị danh sách các quân cờ
            displayPieces();
        }
        // hàm kiểm tra ô nào chứa quân cờ
        void getPiecesOnBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    // kiểm tra xem thử các quân cờ nào có thể được quyền di chuyển
                    if (chessboard.Board[i, j] != 0)
                        chessboard.PossibleMoves[i, j] = 1;
                    else
                        chessboard.PossibleMoves[i, j] = 0;
        }

        //hàm hiển thị các quân cờ lên bàn cờ
        void displayPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //hiển thị các quân cờ lên trên giao diện
                    switch (chessboard.Board[i, j])
                    {
                        case 00: tableBackground[i, j].BackgroundImage = null; break;
                        //Đây là trường hợp của các quân cờ đen
                        case 01: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackPawn.png"); break;
                        case 02: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackRock.png"); break;
                        case 03: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackKnight.png"); break;
                        case 04: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackBiShop.png"); break;
                        case 05: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackQueen.png"); break;
                        case 06: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackKing.png"); break;
                        case 07: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackRock.png"); break;
                        case 08: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackKnight.png"); break;
                        case 09: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\BlackBiShop.png"); break;
                        //đây là trường hợp của các quân cờ trắng
                        case 11: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhitePawn.png"); break;
                        case 12: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteRock.png"); break;
                        case 13: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteKnight.png"); break;
                        case 14: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteBiShop.png"); break;
                        case 15: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteQueen.png"); break;
                        case 16: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteKing.png"); break;
                        case 17: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteRock.png"); break;
                        case 18: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteKnight.png"); break;
                        case 19: tableBackground[i, j].BackgroundImage = Image.FromFile("Resources\\WhiteBiShop.png"); break;
                    }
                }
            }
            //lưu lại tất cả các nước di chuyển của các quân cờ
            staleArrays();
            //kiểm tra xem quân vua có đang bị chiếu tướng hay không
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        //hàm lưu lại vị trí di chuyển của các quân cờ
        public void staleArrays()
        {
            //dùng để lưu mọi nước đi của người chơi
            //đối với các quân cờ đen
            BlackStaleArray = new int[8, 8];
            BlackStaleArray = whitePawn.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteKnight1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteKnight2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteBiShop1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteBiShop2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteRock1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteRock2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteQueen.isStale(chessboard.Board, BlackStaleArray);
            //đối với các quân cờ trắng
            WhiteStaleArray = new int[8, 8];
            WhiteStaleArray = blackPawn.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackKnight1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackKnight2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackBiShop1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackBiShop2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackRock1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackRock2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackQueen.isStale(chessboard.Board, WhiteStaleArray);
        }
        /*
        Xuất hiện 3 trường hợp với trường possibleMoves:
           + 0: tương đương với các ô trống
           + 1: tương đương với các quân cờ có thể chọn
           + 2: tương đương với những ô quân cờ có thể di chuyển
           + 3: tương đương với quân cờ được chọn
        */
        private void tableBackground_Click(object sender, EventArgs e)
        {
            //sự kiện khi click vào 1 quân cờ bất kỳ
            afterClickOnTable((sender as userControlClick).posX, (sender as userControlClick).posY);
        }
        //xử lý sự kiện nhận tọa độ của quân cờ trên board
        public void afterClickOnTable(int j, int i)
        {
            // i tương đương với posY, j tương đương với posX
            switch (chessboard.PossibleMoves[i, j])
            {
                // dùng để lưu lại việc tính toán các đường đi có sẵn của quân cờ
                // lưu lại vị trí của các quân cờ đã chọn 
                case 1:
                    possibleMovesByPieces(chessboard.Board[i, j], j, i);
                    beforeMove_Y = i;
                    beforeMove_X = j;
                    break;
                case 2:
                    move = 0;
                    succesfulMove(j, i);
                    break;
                // khi người dùng hủy việc chọn quân thì vị trí trên bàn cờ sẽ bị xóa
                case 3:
                    clearMove();
                    break;
            }
            //kiểm tra việc chiếu tướng
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        //numberOfPiece là số kí hiệu của quân cờ trên bàn cờ và X, Y là vị trí của quân cờ đó trên bàn cờ
        void possibleMovesByPieces(int numberOfPiece, int posX, int posY)
        {
            //khi chọn vào 1 quân cờ mới thì vị trí của quân cờ cũ sẽ bị clear đi
            clearMove();
            switch (numberOfPiece)
            {
                //thuật toán đường di chuyển của quân tốt
                case 1:
                    chessboard.PossibleMoves = blackPawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 2:
                    chessboard.PossibleMoves = blackRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 3:
                    chessboard.PossibleMoves = blackKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 4:
                    chessboard.PossibleMoves = blackBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 5:
                    chessboard.PossibleMoves = blackQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 6:
                    chessboard.PossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 7:
                    chessboard.PossibleMoves = blackRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 8:
                    chessboard.PossibleMoves = blackKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 9:
                    chessboard.PossibleMoves = blackBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 11:
                    chessboard.PossibleMoves = whitePawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 12:
                    chessboard.PossibleMoves = whiteRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 13:
                    chessboard.PossibleMoves = whiteKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 14:
                    chessboard.PossibleMoves = whiteBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 15:
                    chessboard.PossibleMoves = whiteQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 16:
                    chessboard.PossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 17:
                    chessboard.PossibleMoves = whiteRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 18:
                    chessboard.PossibleMoves = whiteKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
                case 19:
                    chessboard.PossibleMoves = whiteBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                    break;
            }
            //những vị trí mà quân cờ được lựa chọn sẽ có giá trị là 3
            chessboard.PossibleMoves[posY, posX] = 3;
            removeMoveThatNotPossible(numberOfPiece, posY, posX);
            //hiển thị các vị trí mà quân cờ có thể di chuyển
            showPossibleMoves();
        }

        //hiển thị ra đường đi chỉ dẫn cho các quân cờ
        public void showPossibleMoves()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.PossibleMoves[i, j] == 2)
                    {
                        tableBackground[i, j].BackColor = Color.Yellow;
                        move++;
                    }    
                    if (chessboard.PossibleMoves[i, j] == 3)
                        tableBackground[i, j].BackColor = Color.Blue;
                }
            }
            //kiểm tra xem quân vua có đang bị chiếu tướng hay không
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        //xóa đường đi của các quân cờ trước đó
        public void clearMove()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (chessboard.Board[i, j] != 0) chessboard.PossibleMoves[i, j] = 1;
                    else chessboard.PossibleMoves[i, j] = 0;
            //thay đổi lại màu của bàn cờ sau khi người dùng hủy việc chọn quân cờ
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (i % 2 == 0)
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                        else tableBackground[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                    else tableBackground[i, j].BackColor = Color.Brown;
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }

        //xảy ra khi người dùng chọn đúng vào nước đi hợp lệ
        public void succesfulMove(int posX, int posY)
        {
            //đây là vị trí cũ nơi mà ta sẽ gửi quân cờ đến vị trí mới
            chessboard.Board[posY, posX] = chessboard.Board[beforeMove_Y, beforeMove_X];
            //dùng cho việc nhập thành

            //thiết lập vị trí cũ quân cờ là 0
            chessboard.Board[beforeMove_Y, beforeMove_X] = 0;
            //vẽ lại bàn
            displayPieces();
            clearMove();
            everyPossibleMoves();
            //kiểm tra xem có bị chiếu tướng hay không
            checkmateChecker(posY, posX);

            //chuyển lượt người chơi
            whiteTurn = !whiteTurn;
        }
        //hiển thị bị chiếu tướng và kết thúc game
        public void checkmateChecker(int i, int j)
        {
            if (move == 0)
            {
                gameOver = true;
                MessageBox.Show("You win");
            }
        }

        public void everyPossibleMoves()
        {
            chessboard.AllPossibleMoves = new int[8, 8];
            whiteTurn = !whiteTurn;
            for (int numberOfPiece = 1; numberOfPiece < 20; numberOfPiece++)
            {
                for (int posY = 0; posY < 8; posY++)
                {
                    for (int posX = 0; posX < 8; posX++)
                    {
                        if (chessboard.Board[posY, posX] == numberOfPiece)
                        {
                            switch (numberOfPiece)
                            {
                                case 1:
                                    chessboard.AllPossibleMoves = blackPawn.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 2:
                                    chessboard.AllPossibleMoves = blackRock1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 3:
                                    chessboard.AllPossibleMoves = blackKnight1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 4:
                                    chessboard.AllPossibleMoves = blackBiShop1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 5:
                                    chessboard.AllPossibleMoves = blackQueen.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 6:
                                    chessboard.AllPossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 7:
                                    chessboard.AllPossibleMoves = blackRock2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 8:
                                    chessboard.AllPossibleMoves = blackKnight2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 9:
                                    chessboard.AllPossibleMoves = blackBiShop2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 11:
                                    chessboard.AllPossibleMoves = whitePawn.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 12:
                                    chessboard.AllPossibleMoves = whiteRock1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 13:
                                    chessboard.AllPossibleMoves = whiteKnight1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 14:
                                    chessboard.AllPossibleMoves = whiteBiShop1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 15:
                                    chessboard.AllPossibleMoves = whiteQueen.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 16:
                                    chessboard.AllPossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 17:
                                    chessboard.AllPossibleMoves = whiteRock2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 18:
                                    chessboard.AllPossibleMoves = whiteKnight2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                                case 19:
                                    chessboard.AllPossibleMoves = whiteBiShop2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn);
                                    break;
                            }
                            removeMoveThatNotPossible2(numberOfPiece, posY, posX);
                        }
                    }
                }
            }
            //đổi lượt lại cho người chơi khác
            whiteTurn = !whiteTurn;
        }
        public void removeMoveThatNotPossible(int numberOfPiece, int posY, int posX)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.PossibleMoves[i, j] == 2)
                    {
                        int selectPiece = chessboard.Board[i, j];
                        // mô phỏng vị trí mới của quân cờ
                        chessboard.Board[i, j] = numberOfPiece;
                        chessboard.Board[posY, posX] = 0;
                        staleArrays();
                        //2 điều kiện này sẽ kiểm tra trong mảng cũ có chứa quân vua hay không
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 1 && whiteTurn)   //đây là trường hợp dành cho quân trắng
                            chessboard.PossibleMoves[i, j] = 0; //tiến hành xóa đi vị trí có thể đi của quân cờ
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 2 && !whiteTurn)  //đây là trường hợp dành cho quân đen
                            chessboard.PossibleMoves[i, j] = 0;
                        //thiết lập về lại vị trí ban đầu của quân cờ
                        chessboard.Board[i, j] = selectPiece;
                        chessboard.Board[posY, posX] = numberOfPiece;
                        staleArrays();
                    }
                }
            }

        }
        public void removeMoveThatNotPossible2(int numberOfPiece, int posY, int posX)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.AllPossibleMoves[i, j] == 2)
                    {
                        int lastHitPiece = chessboard.Board[i, j];

                        chessboard.Board[i, j] = numberOfPiece;
                        chessboard.Board[posY, posX] = 0;
                        staleArrays();
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 1 && whiteTurn)
                            chessboard.AllPossibleMoves[i, j] = 0;
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 2 && whiteTurn)
                            chessboard.AllPossibleMoves[i, j] = 0;
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 0)
                        {
                            move++;
                        }
                        chessboard.Board[i, j] = lastHitPiece;
                        chessboard.Board[posY, posX] = numberOfPiece;
                        staleArrays();
                    }
                }
            }
            chessboard.AllPossibleMoves = new int[8, 8];
        }
    }
}
