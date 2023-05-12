using chessgames.backPieces;
using chessgames.whitePieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        public bool whiteTurn;
        public bool blackTurn;
        public bool gameOver = false;
        public bool castlingBlackRock1 = true;
        public bool castlingBlackRock2 = true;
        public bool castlingBlackKing = true;
        public bool castlingWhiteRock1 = true;
        public bool castlingWhiteRock2 = true;
        public bool checkEnable = false;
        public bool castlingWhiteKing = true;
        public bool isCreated;
        public bool isWin = false;
        public bool canNotMove = false; // ngăn không cho đối phương di chuyển khi user chọn thành công quân cờ mới
        public bool isChoose = true; //trường này khi quân tốt di chuyển tới cuối bàn cờ thì nếu chọn quân mới rồi mới được quyền đánh
        public bool setUpTimer = false;
        public bool setUpTimerThread = false;
        #endregion

        #region integers
        public int beforeMove_X;
        public int beforeMove_Y;
        public int getChangMove_X;
        public int getChangMove_Y;
        public int move;
        public int portConnect = 8080;
        public int playerMoved = 0;
        public int castlingPiece = 0;
        public int changePieceValue = 0;
        public int piece = -1;
        public int countTime = 60;
        public int setUpTime = 60;
        #endregion

        #region infoUser
        public string userName;
        public int port;
        public int portDif;
        #endregion

        #region variable
        ChessBoard chessboard = new ChessBoard();
        userControlClick[,] tableBackground;
        public int[,] WhiteStaleArray = new int[8, 8];
        public int[,] BlackStaleArray = new int[8, 8];
        Thread serverRcvData = null;
        Thread clientRcvData = null;
        Thread threadWaiting = null;
        Stream stream = null;
        TcpClient client = null;
        TcpListener server = null;
        List<Button> buttonList = new List<Button>();
        button btn = new button();
        Button oldButton = new Button()
        {
            Height = 0,
            Width = 0
        };
        UdpClient clientUDP = null;
        Thread rcvDataUDPThread = null;
        IPEndPoint ipEndPoint = null;
        System.Windows.Forms.Timer timer = null;
        #endregion
        public void displayAnncount(bool turn)
        {
            if (turn)
                MessageBox.Show("Đến lượt bạn");
            else
                MessageBox.Show("Đến lượt của đối thủ");
        }
        public Form1()
        {
            InitializeComponent();



            txtCountTime.ReadOnly = true;
            txtCountTime.BorderStyle = BorderStyle.None;
            txtCountTime.Text = countTime.ToString();

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

            CheckForIllegalCrossThreadCalls = false;

            for (int i = 0; i < 8; i++) // tượng trưng cho các dòng
            {
                for (int j = 0; j < 8; j++) //tượng trưng cho các cột
                {
                    tableBackground[i, j] = new userControlClick();
                    tableBackground[i, j].Parent = this;
                    tableBackground[i, j].Location = new Point(j * 50 + 310, i * 50 + 50);
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
        }
        public Form1(string userName, int port, int portDif, bool isCreated, bool turn, int piece) : this()
        {
            this.isCreated = isCreated;
            this.userName = userName;
            this.port = port;
            this.portDif = portDif;
            txtUsername.Text = userName;
            txtPort.Text = port.ToString();
            clientUDP = new UdpClient(port);
            listChat.ReadOnly = true;
            ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            rcvDataUDPThread = new Thread(new ThreadStart(rcvDataUDP));
            rcvDataUDPThread.Start();
            if (isCreated) // đây là người tạo phòng cũng tương đương với server
            {
                //đây là lượt mà chủ phòng sẽ được đánh trước
                whiteTurn = turn;
                blackTurn = !turn;
                //chủ phòng sẽ là cờ trắng và biến piece = 0
                this.piece = piece;
                server = new TcpListener(IPAddress.Any, portConnect);
                server.Start();
                threadWaiting = new Thread(new ThreadStart(waitingAnotherClient));
                threadWaiting.Start();

            }
            else //đây sẽ là người sẽ tham gia vào phòng chơi
            {
                try
                {
                    //đây là lượt mà người còn lại sẽ được đánh
                    blackTurn = turn;
                    whiteTurn = !turn;
                    //người chơi sẽ là cờ đen và biến piece = 1
                    this.piece = piece;
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse("127.0.0.1"), portConnect);
                    clientRcvData = new Thread(new ThreadStart(rcvData));
                    clientRcvData.Start();
                    timer = new System.Windows.Forms.Timer();
                    timer.Tick += Timer_Tick;
                    timer.Interval = 1;
                    setUpTimer = true;
                    setUpTimerThread = true;
                    timer.Start();
                    user.players += 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                    return;
                }
            }
            // hàm kiểm tra ô nào chứa quân cờ
            getPiecesOnBoard();
            // hiển thị danh sách các quân cờ
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //hiển thị các quân cờ lên trên giao diện
                    choose(i, j);
                }
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (setUpTimer)
            {
                timer.Interval = 1000;
            }
            txtCountTime.Text = countTime.ToString();
            sendMove(0, 0, 1, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ

            countTime--;
            if (countTime == 0)
            {
                whiteTurn = !whiteTurn;
                blackTurn = !blackTurn;
                countTime = setUpTime;
                clearMove();
                //thực hiện việc xóa các nút có màu đỏ trong list view nếu có
                for (int i = 0; i < buttonList.Count; i++)
                {
                    if (buttonList[i].BackColor == Color.Red)
                        buttonList[i].BackColor = Color.Transparent;
                }
            }
            if (setUpTimerThread)
            {
                timer.Interval = 1;
                setUpTimerThread = false;
            }
        }

        public void waitingAnotherClient()
        {
            while (true)
            {

                if (user.players == 2)
                {
                    client = server.AcceptTcpClient();
                    serverRcvData = new Thread(new ThreadStart(rcvData));
                    serverRcvData.Start();
                    break;
                }
            }
        }
        public void sendMove(int posY, int posX, int mode, int countAgain)
        {
            //ta sẽ gửi 1 mảng byte chứa stt của quân cờ, vị trí hiện tại của quân cờ, vị trí mới mà quân cờ sẽ di chuyển
            //giá trị để kiểm tra xem quân vua có bị chiếu tướng hay không, giá trị nhập thành và giá trị quân cờ mới sẽ thay khi tốt đến cuối bàn cờ
            byte[] dataSends = { (byte)playerMoved, (byte)beforeMove_Y, (byte)beforeMove_X, (byte)posY, (byte)posX, (byte)move, (byte)castlingPiece, (byte)changePieceValue, (byte)mode, (byte)countTime, (byte)countAgain };
            stream = client.GetStream();
            stream.Write(dataSends, 0, dataSends.Length);
        }
        public void rcvData()
        {
            while (true)
            {
                byte[] buffers = new byte[11];
                stream = client.GetStream();
                int length = stream.Read(buffers, 0, buffers.Length);
                if (length > 0)
                {
                    if (buffers[8] == 0)
                    {
                        //chứa danh sách các quân cờ sau khi bị loại khỏi danh sách
                        listPieceKilled(buffers[3], buffers[4], buffers[1], buffers[2]);
                        //đổi lượt
                        whiteTurn = !whiteTurn;
                        blackTurn = !blackTurn;
                        if (buffers[6] == 0)
                        {
                            //thay đổi lại vị trí của người chơi cũ
                            chessboard.Board[buffers[1], buffers[2]] = 0;
                            //cập nhật lại vị trí mới
                            chessboard.Board[buffers[3], buffers[4]] = buffers[0];
                        }
                        //dùng cho việc nhập thành
                        if (buffers[6] == 1) //dành cho nhập thành quân đen
                        {
                            if (buffers[3] == 0 && buffers[4] == 0 && chessboard.Board[buffers[3], buffers[4]] == 02)
                            {
                                //hoán đổi vị trí của quân vua
                                chessboard.Board[0, 2] = 06;
                                chessboard.Board[buffers[1], buffers[2]] = 00;
                                //hoán đổi vị trí của quân xe
                                chessboard.Board[0, 3] = 02;
                                chessboard.Board[0, 0] = 00;

                                //vẽ lại vị trí của quân vua
                                displayPieces(0, 2, buffers[1], buffers[2]);
                                //vẽ lại vị trí của quân xe
                                displayPieces(0, 3, 0, 0);
                            }
                            if (buffers[3] == 0 && buffers[4] == 7 && chessboard.Board[buffers[3], buffers[4]] == 07)
                            {
                                //hoán đổi vị trí của quân vua
                                chessboard.Board[0, 6] = 06;
                                chessboard.Board[buffers[1], buffers[2]] = 00;
                                //hoán đổi vị trí của quân xe
                                chessboard.Board[0, 5] = 07;
                                chessboard.Board[0, 7] = 00;

                                //vẽ lại vị trí của quân vua
                                displayPieces(0, 6, buffers[1], buffers[2]);
                                //vẽ lại vị trí của quân xe
                                displayPieces(0, 5, 0, 7);
                            }
                            staleArrays();
                            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
                            continue;
                        }
                        else if (buffers[6] == 2)//dành cho nhập thành quân trắng
                        {
                            if (buffers[3] == 7 && buffers[4] == 0 && chessboard.Board[buffers[3], buffers[4]] == 12)
                            {
                                //hoán đổi vị trí của quân vua
                                chessboard.Board[7, 2] = 16;
                                chessboard.Board[buffers[1], buffers[2]] = 00;
                                //hoán đổi vị trí của quân xe
                                chessboard.Board[7, 3] = 12;
                                chessboard.Board[7, 0] = 00;

                                //vẽ lại vị trí của quân vua
                                displayPieces(7, 2, buffers[1], buffers[2]);
                                //vẽ lại vị trí của quân xe
                                displayPieces(7, 3, 7, 0);
                            }
                            if (buffers[3] == 7 && buffers[4] == 7 && chessboard.Board[buffers[3], buffers[4]] == 17)
                            {
                                //hoán đổi vị trí của quân vua
                                chessboard.Board[7, 6] = 16;
                                chessboard.Board[buffers[1], buffers[2]] = 00;
                                //hoán đổi vị trí của quân xe
                                chessboard.Board[7, 5] = 17;
                                chessboard.Board[7, 7] = 00;

                                //vẽ lại vị trí của quân vua
                                displayPieces(7, 6, buffers[1], buffers[2]);
                                //vẽ lại vị trí của quân xe
                                displayPieces(7, 5, 7, 7);

                            }

                            staleArrays();
                            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
                            continue;
                        }

                        //dùng cho việc hoán đổi quân cờ khi quân tốt di chuyển đến cuối bàn cờ
                        if (buffers[7] != 0)
                        {
                            chessboard.Board[buffers[3], buffers[4]] = buffers[7];
                        }

                        displayPieces(buffers[3], buffers[4], buffers[1], buffers[2]);
                        staleArrays();

                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                                if (i % 2 == 0)
                                    if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                                    else tableBackground[i, j].BackColor = Color.White;
                                else
                                    if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                                else tableBackground[i, j].BackColor = Color.Brown;
                        chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);

                        if (buffers[5] == 0)
                        {
                            MessageBox.Show(userName + " đã thua");
                            StopGame();
                        }
                    }
                    else if (buffers[8] == 1)
                    {
                        if (buffers[10] == setUpTime)
                        {
                            countTime = buffers[10] + 1;
                            setUpTimerThread = true;
                            setUpTimer = true;
                        }
                        else
                        {
                            if (buffers[9] - 1 == 0)
                            {
                                whiteTurn = !whiteTurn;
                                blackTurn = !blackTurn;
                                clearMove();
                            }
                            //hiển thị lên giao diện
                            txtCountTime.Text = buffers[9].ToString();
                        }
                    }
                }
            }
        }
        public void StopGame()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessboard.PossibleMoves[i, j] = 0;
                }
            }
            //kết thúc timer
            if (timer != null)
                timer.Stop();
            //đóng server
            if (server != null)
                server.Stop();
            if (client != null)
                client.Close();
            if (serverRcvData != null)
                serverRcvData.Abort();
            if (clientRcvData != null)
                clientRcvData.Abort();
            if (threadWaiting != null)
                threadWaiting.Abort();

        }
        public void getPiecesOnBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // kiểm tra xem thử các quân cờ nào có thể được quyền di chuyển
                    if (chessboard.Board[i, j] != 0)
                    {
                        if (piece == 0)
                        {
                            if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                        else if (piece == 1)
                        {
                            if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                    }
                    else
                    {
                        chessboard.PossibleMoves[i, j] = 0;
                    }
                }
            }
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
        public void displayPieces(int posY, int posX, int beforeY, int beforeX)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if ((posY == i && posX == j) || ((beforeY == i && beforeX == j)))
                        //hiển thị các quân cờ lên trên giao diện
                        choose(i, j);
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
        private void tableBackground_Click(object sender, EventArgs e)
        {
            //sự kiện khi click vào 1 quân cờ bất kỳ
            afterClickOnTable((sender as userControlClick).posX, (sender as userControlClick).posY);
        }
        //xử lý sự kiện nhận tọa độ của quân cờ trên board
        public void afterClickOnTable(int j, int i)
        {
            // khi client chưa tham gia phòng đấu thì không được phép làm gì cả
            if (isCreated && client == null)
            {
                MessageBox.Show("Game chưa bắt đầu, vui lòng đợi người chơi còn lại");
                return;
            }
            else
            {
                if (isChoose)
                {
                    // i tương đương với posY, j tương đương với posX
                    switch (chessboard.PossibleMoves[i, j])
                    {
                        // dùng để lưu lại việc tính toán các đường đi có sẵn của quân cờ
                        // lưu lại vị trí của các quân cờ đã chọn 
                        case 1: //1: tương đương với các quân cờ có thể chọn
                            possibleMovesByPieces(chessboard.Board[i, j], j, i);
                            beforeMove_Y = i;
                            beforeMove_X = j;
                            break;
                        case 2: //2: tương đương với những ô quân cờ có thể di chuyển
                            move = 0;
                            succesfulMove(j, i);
                            break;
                        // khi người dùng hủy việc chọn quân thì vị trí trên bàn cờ sẽ bị xóa
                        case 3: //3: tương đương với quân cờ được chọn
                            clearMove();
                            break;
                        case 4:
                            handleCastling(j, i);
                            break;
                    }
                    //kiểm tra việc chiếu tướng
                    chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn quân cờ thay thế");
                    return;
                }
            }
        }
        public void handleCastling(int posX, int posY)
        {

            if (chessboard.Board[posY, posX] == 2 || chessboard.Board[posY, posX] == 7 || chessboard.Board[posY, posX] == 12 || chessboard.Board[posY, posX] == 17)
            {
                //lưu lại nước di chuyển để gửi cho đối phương
                for (int index = 0; index < 20; index++)
                {
                    if (chessboard.Board[beforeMove_Y, beforeMove_X] == index)
                    {
                        playerMoved = index;
                    }
                }
                //quân đen nhập thành
                if (chessboard.Board[beforeMove_Y, beforeMove_X] == 06)
                {
                    castlingPiece = 1; //quân đen nhập thành
                    //sau khi đã lưu lại nước di chuyển thì sẽ gửi cho đối phương
                    if (!gameOver)
                        sendMove(posY, posX, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
                    if (posY == 0 && posX == 0 && chessboard.Board[posY, posX] == 02)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[0, 2] = 06;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[0, 3] = 02;
                        chessboard.Board[0, 0] = 00;

                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(0, 2, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xe
                        displayPieces(0, 3, 0, 0);
                    }
                    if (posY == 0 && posX == 7 && chessboard.Board[posY, posX] == 07)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[0, 6] = 06;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[0, 5] = 07;
                        chessboard.Board[0, 7] = 00;
                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(0, 6, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xe
                        displayPieces(0, 5, 0, 7);
                    }
                }
                //quân trắng nhập thành
                if (chessboard.Board[beforeMove_Y, beforeMove_X] == 16)
                {
                    castlingPiece = 2; //quân trắng nhập thành
                    //sau khi đã lưu lại nước di chuyển thì sẽ gửi cho đối phương
                    if (!gameOver)
                        sendMove(posY, posX, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
                    if (posY == 7 && posX == 0 && chessboard.Board[posY, posX] == 12)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[7, 2] = 16;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[7, 3] = 12;
                        chessboard.Board[7, 0] = 00;

                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(7, 2, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xe
                        displayPieces(7, 3, 7, 0);
                    }
                    if (posY == 7 && posX == 7 && chessboard.Board[posY, posX] == 17)
                    {
                        //hoán đổi vị trí của quân vua
                        chessboard.Board[7, 6] = 16;
                        chessboard.Board[beforeMove_Y, beforeMove_X] = 00;
                        //hoán đổi vị trí của quân xe
                        chessboard.Board[7, 5] = 17;
                        chessboard.Board[7, 7] = 00;

                        //vẽ lại bàn cờ vị trí quân vua
                        displayPieces(7, 6, beforeMove_Y, beforeMove_X);
                        //vẽ lại vị trí quân xe
                        displayPieces(7, 5, 7, 7);
                    }
                }


                if (timer != null)
                {
                    //cập nhật lại thời gian
                    setUpTimer = true;
                    timer.Interval = 1;
                    countTime = setUpTime;
                }
                else
                {
                    //cập nhật lại thời gian
                    sendMove(0, 0, 1, setUpTime);
                }
                clearMove();
                everyPossibleMoves();
                //kiểm tra xem có bị chiếu tướng hay không
                checkmateChecker(posY, posX);
                //chuyển lượt người chơi
                whiteTurn = !whiteTurn;
                blackTurn = !blackTurn;
            }
        }
        //numberOfPiece là số kí hiệu của quân cờ trên bàn cờ và X, Y là vị trí của quân cờ đó trên bàn cờ
        void possibleMovesByPieces(int numberOfPiece, int posX, int posY)
        {
            //khi chọn vào 1 quân cờ mới thì vị trí của quân cờ cũ sẽ bị clear đi
            clearMove();

            //kiểm tra nếu đang bị chiếu tướng thì không thể nhập thành
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tableBackground[i, j].BackColor == Color.Red && chessboard.Board[i, j] == 06)
                    {
                        castlingBlackKing = false;
                    }
                    else if (tableBackground[i, j].BackColor == Color.Red && chessboard.Board[i, j] == 16)
                    {
                        castlingWhiteKing = false;
                    }
                }
            }
            switch (numberOfPiece)
            {
                //thuật toán đường di chuyển của quân tốt
                case 1:
                    chessboard.PossibleMoves = blackPawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 2:
                    chessboard.PossibleMoves = blackRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 3:
                    chessboard.PossibleMoves = blackKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 4:
                    chessboard.PossibleMoves = blackBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 5:
                    chessboard.PossibleMoves = blackQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 6:
                    chessboard.PossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn, castlingBlackKing, castlingBlackRock1, castlingBlackRock2);
                    break;
                case 7:
                    chessboard.PossibleMoves = blackRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 8:
                    chessboard.PossibleMoves = blackKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 9:
                    chessboard.PossibleMoves = blackBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 11:
                    chessboard.PossibleMoves = whitePawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 12:
                    chessboard.PossibleMoves = whiteRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 13:
                    chessboard.PossibleMoves = whiteKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 14:
                    chessboard.PossibleMoves = whiteBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 15:
                    chessboard.PossibleMoves = whiteQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 16:
                    chessboard.PossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, castlingWhiteKing, castlingWhiteRock1, castlingWhiteRock2);
                    break;
                case 17:
                    chessboard.PossibleMoves = whiteRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 18:
                    chessboard.PossibleMoves = whiteKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 19:
                    chessboard.PossibleMoves = whiteBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
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
                    if (chessboard.PossibleMoves[i, j] == 4)
                    {
                        tableBackground[i, j].BackColor = Color.Green;
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
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessboard.Board[i, j] != 0)
                    {
                        if (piece == 0)
                        {
                            if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                        else if (piece == 1)
                        {
                            if (chessboard.Board[i, j] < 10)
                            {
                                chessboard.PossibleMoves[i, j] = 1;
                            }
                            else if (chessboard.Board[i, j] > 10)
                            {
                                chessboard.PossibleMoves[i, j] = 0;
                            }
                        }
                    }
                    else
                    {
                        chessboard.PossibleMoves[i, j] = 0;
                    }
                }
            }
            //thay đổi lại màu của bàn cờ sau khi người dùng hủy việc chọn quân cờ
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                        else tableBackground[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                    else tableBackground[i, j].BackColor = Color.Brown;
                }
            }
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        public void listPieceKilled(int posY, int posX, int beforeMove_Y, int beforeMove_X)
        {
            //loại bỏ trường hợp khi nhập thành
            bool checkCastlingBlackPiece = chessboard.Board[beforeMove_Y, beforeMove_X] == 06 && (chessboard.Board[posY, posX] == 2 || chessboard.Board[posY, posX] == 7);
            bool checkCastlingWhitePiece = chessboard.Board[beforeMove_Y, beforeMove_X] == 16 && (chessboard.Board[posY, posX] == 12 || chessboard.Board[posY, posX] == 17);
            if (checkCastlingBlackPiece) { }
            else if (checkCastlingWhitePiece) { }
            else
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
            }
        }
        //hàm thực hiện việc di chuyển khi người dùng chọn đúng vào nước đi hợp lệ
        public void succesfulMove(int posX, int posY)
        {
            castlingPiece = 0;
            changePieceValue = 0;
            if (timer != null)
            {
                //cập nhật lại thời gian
                setUpTimer = true;
                timer.Interval = 1;
                countTime = setUpTime;
            }
            else
            {
                //cập nhật lại thời gian
                sendMove(0, 0, 1, setUpTime);
            }

            //lưu lại nước di chuyển để gửi cho đối phương
            for (int index = 0; index < 20; index++)
            {
                if (chessboard.Board[beforeMove_Y, beforeMove_X] == index)
                {
                    playerMoved = index;
                }
            }

            bool checkCanMove = false;
            //kiểm tra xem người dùng đã thay thế quân tốt bằng quân khác hay chưa mà đã di chuyển
            if (buttonList.Count != 0)
            {
                for (int index = 0; index < buttonList.Count; index++)
                {
                    if (buttonList[index].BackColor == Color.Red)
                    {
                        checkCanMove = true;
                        break;
                    }
                }
            }

            if (checkCanMove)
            {
                MessageBox.Show("Bạn không thể di đánh khi chưa thay thế quân cờ mới");
                clearMove();
                return;
            }

            //chứa danh sách các quân cờ sau khi bị loại khỏi danh sách
            listPieceKilled(posY, posX, beforeMove_Y, beforeMove_X);

            //dùng cho việc nhập thành và khi quân tốt đến cuối bàn cờ địch thì sẽ được chọn quân mới
            castlingAndPawnPromotionChecker(posY, posX);

            //đây là vị trí cũ nơi mà ta sẽ gửi quân cờ đến vị trí mới
            chessboard.Board[posY, posX] = chessboard.Board[beforeMove_Y, beforeMove_X];

            //thiết lập vị trí cũ quân cờ là 0
            chessboard.Board[beforeMove_Y, beforeMove_X] = 0;
            //vẽ lại bàn cờ
            displayPieces(posY, posX, beforeMove_Y, beforeMove_X);
            clearMove();
            everyPossibleMoves();
            ////kiểm tra xem có bị chiếu tướng hay không
            checkmateChecker(posY, posX);

            ////sau khi đã lưu lại nước di chuyển thì sẽ gửi cho đối phương
            if (!gameOver && !canNotMove)
                sendMove(posY, posX, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
            if (!canNotMove)
            {
                //chuyển lượt người chơi
                whiteTurn = !whiteTurn;
                blackTurn = !blackTurn;
            }

        }
        //hiển thị bị chiếu tướng và kết thúc game
        public void checkmateChecker(int i, int j)
        {
            if (move == 0)
            {
                MessageBox.Show(userName + " đã thắng");
                gameOver = true;
                sendMove(i, j, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ
                StopGame();
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
                    bool checkCanChange = false;
                    for (int index = 0; index < buttonList.Count; index++)
                    {
                        if (int.Parse(buttonList[index].Text) > 11)
                        {
                            buttonList[index].BackColor = Color.Red;
                            checkCanChange = true;
                        }
                    }
                    if (checkCanChange)
                    {
                        canNotMove = true;
                        isChoose = false;
                        MessageBox.Show("Vui lòng chọn 1 quân trắng để thay thế");
                    }
                    else
                    {
                        isChoose = true;
                        if (timer != null)
                        {
                            //cập nhật lại thời gian
                            setUpTimer = true;
                            timer.Interval = 1;
                            countTime = setUpTime;
                        }
                        else
                        {
                            //cập nhật lại thời gian
                            sendMove(0, 0, 1, setUpTime);
                        }
                        checkEnable = false;
                    }
                }
            }
            else if (chessboard.Board[beforeMove_Y, beforeMove_X] == 01) //kiểm tra xem tốt đen đã xuống cuối hàng hay chưa
            {
                if (i == 7)
                {
                    checkEnable = true;
                    getChangMove_X = j;
                    getChangMove_Y = i;
                    bool checkCanChange = false;
                    for (int index = 0; index < buttonList.Count; index++)
                    {
                        if (int.Parse(buttonList[index].Text) < 10 && int.Parse(buttonList[index].Text) > 1)
                        {
                            buttonList[index].BackColor = Color.Red;
                            checkCanChange = true;
                        }
                    }
                    if (checkCanChange)
                    {
                        canNotMove = true;
                        isChoose = false;
                        MessageBox.Show("Vui lòng chọn 1 quân đen để thay thế");
                    }
                    else
                    {
                        isChoose = true;
                        if (timer != null)
                        {
                            //cập nhật lại thời gian
                            setUpTimer = true;
                            timer.Interval = 1;
                            countTime = setUpTime;
                        }
                        else
                        {
                            //cập nhật lại thời gian
                            sendMove(0, 0, 1, setUpTime);
                        }
                        checkEnable = false;
                    }
                }
            }
        }
        //sự kiện người dùng chọn quân cờ mới để thay thế quân tốt
        private void Btn1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (checkEnable)
            {
                // đây là trường hợp dành cho quân trắng đi trước
                if (int.Parse(btn.Text) == 01 || int.Parse(btn.Text) == 11)
                {
                    MessageBox.Show("Bạn không được chọn quân tốt làm quân thay thế");
                    return;
                }
                if (btn.BackColor == Color.Red)
                {
                    chessboard.Board[getChangMove_Y, getChangMove_X] = int.Parse(btn.Text);
                    changePieceValue = int.Parse(btn.Text);

                    //thực hiện việc xóa các nút có màu đỏ
                    for (int i = 0; i < buttonList.Count; i++)
                    {
                        if (buttonList[i].BackColor == Color.Red)
                            buttonList[i].BackColor = Color.Transparent;
                    }
                    //thay thế quân cờ đã chọn bằng quân tốt
                    if (btn.TabIndex == 1) //tương đương với quân tốt đen
                    {
                        btn.Image = null;
                        btn.BackgroundImage = Image.FromFile("Resources\\BlackPawn.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = "01";
                    }
                    else if (btn.TabIndex == 0) //tương đương với quân tốt trắng
                    {
                        btn.Image = null;
                        btn.BackgroundImage = Image.FromFile("Resources\\WhitePawn.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = "11";
                    }
                    if (timer != null)
                    {
                        //cập nhật lại thời gian
                        setUpTimer = true;
                        timer.Interval = 1;
                        countTime = setUpTime;
                    }
                    else
                    {
                        //cập nhật lại thời gian
                        sendMove(0, 0, 1, setUpTime);
                    }
                    checkEnable = false;
                    //chuyển lượt người chơi
                    whiteTurn = !whiteTurn;
                    blackTurn = !blackTurn;
                    //sau khi đã chọn quân mới
                    isChoose = true;

                    //gửi giá trị trị này tới bàn cờ đối phương
                    sendMove(getChangMove_Y, getChangMove_X, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ

                    canNotMove = false;//cập nhật lại sau khi chọn
                    displayPieces(getChangMove_Y, getChangMove_X, beforeMove_Y, beforeMove_X);
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
            blackTurn = !blackTurn;
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
                                    chessboard.AllPossibleMoves = blackPawn.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 2:
                                    chessboard.AllPossibleMoves = blackRock1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 3:
                                    chessboard.AllPossibleMoves = blackKnight1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 4:
                                    chessboard.AllPossibleMoves = blackBiShop1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 5:
                                    chessboard.AllPossibleMoves = blackQueen.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 6:
                                    chessboard.AllPossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn, castlingBlackKing, castlingBlackRock1, castlingBlackRock2);
                                    break;
                                case 7:
                                    chessboard.AllPossibleMoves = blackRock2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 8:
                                    chessboard.AllPossibleMoves = blackKnight2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 9:
                                    chessboard.AllPossibleMoves = blackBiShop2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, blackTurn);
                                    break;
                                case 11:
                                    chessboard.AllPossibleMoves = whitePawn.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 12:
                                    chessboard.AllPossibleMoves = whiteRock1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 13:
                                    chessboard.AllPossibleMoves = whiteKnight1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 14:
                                    chessboard.AllPossibleMoves = whiteBiShop1.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 15:
                                    chessboard.AllPossibleMoves = whiteQueen.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 16:
                                    chessboard.AllPossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn, castlingWhiteKing, castlingWhiteRock1, castlingWhiteRock2);
                                    break;
                                case 17:
                                    chessboard.AllPossibleMoves = whiteRock2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 18:
                                    chessboard.AllPossibleMoves = whiteKnight2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                                case 19:
                                    chessboard.AllPossibleMoves = whiteBiShop2.getPossibleMoves(chessboard.Board, chessboard.AllPossibleMoves, posX, posY, whiteTurn);
                                    break;
                            }
                            removeMoveThatNotPossible2(numberOfPiece, posY, posX);
                        }
                    }
                }
            }
            //đổi lượt lại cho người chơi khác
            whiteTurn = !whiteTurn;
            blackTurn = !blackTurn;
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
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 1 && whiteTurn && !blackTurn)
                            chessboard.AllPossibleMoves[i, j] = 0;
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 2 && blackTurn && !whiteTurn)
                            chessboard.AllPossibleMoves[i, j] = 0;
                        if (chessboard.notValidMoveChecker(chessboard.Board, WhiteStaleArray, BlackStaleArray) == 0)
                            move++;
                        chessboard.Board[i, j] = lastHitPiece;
                        chessboard.Board[posY, posX] = numberOfPiece;
                        staleArrays();
                    }
                }
            }
            chessboard.AllPossibleMoves = new int[8, 8];
        }
        private void writeData(Image image, string msg, int mode, string userName)
        {
            try
            {

                if (mode == 1)
                {
                    if (msg.Trim() == "")
                        return;
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        if (userName == this.userName)
                            listChat.SelectionAlignment = HorizontalAlignment.Right;
                        else
                            listChat.SelectionAlignment = HorizontalAlignment.Left;
                        listChat.AppendText(userName + "\n" + msg + "\n");
                    });
                    this.Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        if (userName == this.userName)
                            listChat.SelectionAlignment = HorizontalAlignment.Right;
                        else
                            listChat.SelectionAlignment = HorizontalAlignment.Left;
                        listChat.AppendText(msg + '\n');
                        listChat.ReadOnly = false;
                        // Hiển thị hình ảnh trong giao diện người dùng
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = image; // Thay thế yourImage bằng hình ảnh bạn muốn hiển thị
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                        pictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
                        Clipboard.SetImage(bitmap);
                        listChat.Paste();
                        listChat.ReadOnly = true;
                        listChat.AppendText("\n");
                    });
                    this.Invoke(invoker);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ghi dữ liệu thất bại, vui lòng thực hiện lại");
                return;
            }
        }
        public void rcvDataUDP()
        {
            while (true)
            {
                ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receive_buffer = clientUDP.Receive(ref ipEndPoint);
                string data = Encoding.UTF8.GetString(receive_buffer);
                string[] strs = data.Split(':');
                if (strs[0].Contains("(1)"))    //đây là chat 
                {
                    writeData(null, strs[1], 1, strs[0].Substring(0, strs[0].Length - 3));
                }
                else if (strs[0].Contains("(2)")) // đây là gửi icon
                {
                    string imageData = strs[1];
                    byte[] convertedBytes = Convert.FromBase64String(imageData);
                    // Chuyển đổi mảng byte thành hình ảnh
                    using (MemoryStream stream = new MemoryStream(convertedBytes))
                    {
                        Image image = Image.FromStream(stream);
                        writeData(image, "", 2, strs[0].Substring(0, strs[0].Length - 3));
                    }
                }
            }
        }

        private void btnSendIcon_Click(object sender, EventArgs e)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), portDif);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "") return;

            string path = openFileDialog.FileName;
            byte[] imageBytes = File.ReadAllBytes(path);
            byte[] data = Encoding.UTF8.GetBytes(userName + "(2):" + Convert.ToBase64String(imageBytes));

            clientUDP.Send(data, data.Length, ipEndPoint);
            listChat.ReadOnly = false;

            writeData(Image.FromFile(path), "", 2, userName);
            listChat.ReadOnly = true;
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (user.players == 2)
            {
                if (txtMessage.Text.Trim() == "")
                    return;
                string data = $"{userName}(1):" + txtMessage.Text;
                ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), portDif);
                byte[] send_buffer = Encoding.UTF8.GetBytes(data);
                clientUDP.Send(send_buffer, send_buffer.Length, ipEndPoint);
                writeData(null, txtMessage.Text, 1, userName);
            }
            txtMessage.Clear();
        }
    }
}
