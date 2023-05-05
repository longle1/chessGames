using chessgames.backPieces;
using chessgames.whitePieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public bool castlingBlackRock1 = true;
        public bool castlingBlackRock2 = true;
        public bool castlingBlackKing = true;
        public bool castlingWhiteRock1 = true;
        public bool castlingWhiteRock2 = true;
        public bool checkEnable = false;
        public bool castlingWhiteKing = true;
        #endregion
        #region integers
        int beforeMove_X;
        int beforeMove_Y;
        int getChangMove_X;
        int getChangMove_Y;
        int move;
        #endregion
        ChessBoard chessboard = new ChessBoard();
        userControlClick[,] tableBackground;
        public int[,] WhiteStaleArray = new int[8, 8];
        public int[,] BlackStaleArray = new int[8, 8];

        List<Button> buttonList = new List<Button>();
        button btn = new button();
        Button oldButton = new Button()
        {
            Height = 0,
            Width = 0
        };
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
        public Image choose(int i, int j)
        {
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
            return tableBackground[i, j].BackgroundImage;
        }
        //hàm hiển thị các quân cờ lên bàn cờ
        public void displayPieces()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //hiển thị các quân cờ lên trên giao diện
                    choose(i, j);
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
                    chessboard.PossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn, castlingBlackKing, castlingBlackRock1, castlingBlackRock2);
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
                    chessboard.PossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, otherPlayerTurn, castlingWhiteKing, castlingWhiteRock1, castlingWhiteRock2);
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

        //hàm thực hiện việc di chuyển khi người dùng chọn đúng vào nước đi hợp lệ
        public void succesfulMove(int posX, int posY)
        {
            if (choose(posY, posX) != null)
            {
                //đưa quân cờ bị ăn vào trong panel
                Button btn1 = null;
                if (buttonList.Count % 5 == 0)
                {
                    if (buttonList.Count != 0)
                        oldButton.Location = new Point(0, 30 + oldButton.Location.Y + 10);
                    btn1 = btn.createButton(oldButton, pnlContainPieces, choose(posY, posX), chessboard.Board[posY, posX].ToString(), whiteTurn);
                    btn1.Click += Btn1_Click;
                }
                else
                {
                    btn1 = btn.createButton(buttonList[buttonList.Count - 1], pnlContainPieces, choose(posY, posX), chessboard.Board[posY, posX].ToString(), whiteTurn);
                    btn1.Click += Btn1_Click;
                }
                btn.numberOfPiece = chessboard.Board[posY, posX];
                buttonList.Add(btn1);
            }
            //dùng cho việc nhập thành và khi quân tốt đến cuối bàn cờ địch thì sẽ được chọn quân mới
            castlingAndPawnPromotionChecker(posY, posX);

            //đây là vị trí cũ nơi mà ta sẽ gửi quân cờ đến vị trí mới
            chessboard.Board[posY, posX] = chessboard.Board[beforeMove_Y, beforeMove_X];



            //quân đen nhập thành
            if (chessboard.Board[beforeMove_Y, beforeMove_X] == 06)
            {
                if (posY == 0 && posX == 0)
                {
                    //hoán đổi vị trí của quân vua
                    chessboard.Board[0, 2] = 06;
                    chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                    //hoán đổi vị trí của quân xe
                    chessboard.Board[0, 3] = 02;
                    chessboard.Board[0, 0] = 00;
                }
                if (posY == 0 && posX == 7)
                {
                    //hoán đổi vị trí của quân vua
                    chessboard.Board[0, 6] = 06;
                    chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                    //hoán đổi vị trí của quân xe
                    chessboard.Board[0, 5] = 07;
                    chessboard.Board[0, 7] = 00;
                }
            }
            //quân trắng nhập thành
            if (chessboard.Board[beforeMove_Y, beforeMove_Y] == 16)
            {
                if (posY == 7 && posX == 0)
                {
                    //hoán đổi vị trí của quân vua
                    chessboard.Board[7, 2] = 16;
                    chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                    //hoán đổi vị trí của quân xe
                    chessboard.Board[7, 3] = 12;
                    chessboard.Board[7, 0] = 00;
                }
                if (posY == 7 && posX == 7)
                {
                    //hoán đổi vị trí của quân vua
                    chessboard.Board[7, 6] = 16;
                    chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                    //hoán đổi vị trí của quân xe
                    chessboard.Board[7, 5] = 17;
                    chessboard.Board[7, 7] = 00;
                }
            }


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
        //hàm được sử dụng cho việc nhập thành và khi quân tốt đến cuối bàn cờ địch thì sẽ được chọn quân mới
        public void castlingAndPawnPromotionChecker(int i, int j)
        {
            //khi người chơi tiến hành di chuyển quân xe hoặc vua của mình thì sẽ không thể nhập thành nữa
            switch (chessboard.Board[beforeMove_Y, beforeMove_X])
            {
                case 2:
                    castlingBlackRock1 = false;
                    break;
                case 6:
                    castlingBlackKing = false;
                    break;
                case 7:
                    castlingBlackRock2 = false;
                    break;
                case 12:
                    castlingWhiteRock1 = false;
                    break;
                case 16:
                    castlingWhiteKing = false;
                    break;
                case 17:
                    castlingWhiteRock2 = false;
                    break;
            }

            //Xử lý việc chọn quân cờ khi quân tốt ra khỏi bàn cờ vua
            if (chessboard.Board[beforeMove_Y, beforeMove_X] == 11) //kiểm tra xem tốt trắng đã lên cuối hàng hay chưa
            {
                if (i == 0)
                {
                    checkEnable = true;
                    getChangMove_X = j;
                    getChangMove_Y = i;
                    for (int index = 0; index < buttonList.Count; index++)
                    {
                        if (int.Parse(buttonList[index].Text) > 11)
                        {
                            buttonList[index].BackColor = Color.Red;
                        }
                    }
                    MessageBox.Show("Vui lòng chọn 1 quân trắng để thay thế");
                }
            }
            else if (chessboard.Board[beforeMove_Y, beforeMove_X] == 01) //kiểm tra xem tốt đen đã xuống cuối hàng hay chưa
            {
                if (i == 7)
                {
                    checkEnable = true;
                    getChangMove_X = j;
                    getChangMove_Y = i;
                    for (int index = 0; index < buttonList.Count; index++)
                    {
                        if (int.Parse(buttonList[index].Text) < 10 && int.Parse(buttonList[index].Text) > 1)
                        {
                            buttonList[index].BackColor = Color.Red;
                        }
                    }
                    MessageBox.Show("Vui lòng chọn 1 quân đen để thay thế");
                }
            }
        }
        //sự kiện người dùng chọn quân cờ mới để thay thế quân tốt
        private void Btn1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (checkEnable)
            {
                btn.BackColor = Color.Red;
                // đây là trường hợp dành cho quân trắng đi trước
                if (int.Parse(btn.Text) == 01 || int.Parse(btn.Text) == 11)
                {
                    MessageBox.Show("Bạn không được chọn quân tốt làm quân thay thế ");
                    return;
                }
                if (btn.BackColor == Color.Red)
                {
                    chessboard.Board[getChangMove_Y, getChangMove_X] = int.Parse(btn.Text);
                    //thực hiện việc xóa các nút có màu đỏ
                    for(int i = 0;i< buttonList.Count;i++)
                    {
                        if (buttonList[i].BackColor == Color.Red)
                            buttonList[i].BackColor = Color.Transparent;
                    }
                    //thay thế quân cờ đã chọn bằng quân tốt
                    if(btn.TabIndex == 1) //tương đương với quân tốt đen
                    {
                        btn.Image = null;
                        btn.BackgroundImage = Image.FromFile("Resources\\BlackPawn.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = "01";
                        MessageBox.Show("Thay đổi thành công");
                    }else if(btn.TabIndex == 0) //tương đương với quân tốt trắng
                    {
                        btn.Image = null;
                        btn.BackgroundImage = Image.FromFile("Resources\\WhitePawn.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = "11";
                        MessageBox.Show("Thay đổi thành công");
                    }
                    checkEnable = false;
                    displayPieces();
                }
            }
            else
            {
                MessageBox.Show("Bạn không thể thực hiện thao tác này");
                return;
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
                                    chessboard.AllPossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn, castlingBlackKing, castlingBlackRock1, castlingBlackRock2);
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
                                    chessboard.AllPossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, otherPlayerTurn, castlingWhiteKing, castlingWhiteRock1, castlingWhiteRock2);
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
                        //cập nhật lại các đường đi cho các mảng cũ
                        staleArrays();
                        //2 điều kiện này sẽ kiểm tra trong mảng cũ có chứa quân vua hay không
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 1 && whiteTurn)   //đây là trường hợp dành cho quân trắng
                            chessboard.PossibleMoves[i, j] = 0; //tiến hành xóa đi vị trí có thể đi của quân cờ
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 2 && !whiteTurn)  //đây là trường hợp dành cho quân đen
                            chessboard.PossibleMoves[i, j] = 0;
                        //thiết lập về lại vị trí ban đầu của quân cờ
                        chessboard.Board[i, j] = selectPiece;
                        chessboard.Board[posY, posX] = numberOfPiece;

                        //cập nhật lại các đường đi cho các mảng cũ
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
