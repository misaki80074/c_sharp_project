using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku2
{
    internal class GameManager
    {
        Board board = new Board();
        private PieceType currentPlayer = PieceType.BLACK;

        private PieceType winnerPlayer = PieceType.NONE;
        private PieceType almostWinner = PieceType.NONE;
        public PieceType WinnerPlayer { get { return winnerPlayer; } }
        public PieceType AlmostWinner { get { return almostWinner; } }

        int[,] countPiece = new int[3, 3];

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                // 檢查現在下棋的人是否獲勝
                checkWinner();


                // 交換棋手
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;

                return piece;
            }
            return null;
        }

        private void checkWinner()
        {
            int centerX = board.LastPlacedNode.X;
            int centerY = board.LastPlacedNode.Y;

            // 檢查8個不同方向
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    // 排除中間的情況
                    if (xDir == 0 && yDir == 0)
                        continue;

                    // 記錄現在看到幾顆棋子
                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        // 檢查顏色是否相同，不同就跳出迴圈
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;

                        count++;
                    }

                    // 檢查是否看到5顆棋子
                    //if (count == 5)
                    //winnerPlayer = currentPlayer;
                    countPiece[xDir + 1, yDir + 1] = count - 1;

                    if (checkWinnerExist(countPiece) == 4)
                        winnerPlayer = currentPlayer;
                    else if (checkWinnerExist(countPiece) == 3)
                        almostWinner = currentPlayer;
                }
            }
        }

        // 檢查winner和快贏的是否存在
        private int checkWinnerExist(int[,] record)
        {
            int result1 = record[0, 1] + record[2, 1]; // 橫排
            int result2 = record[1, 0] + record[1, 2]; // 直排
            int result3 = record[0, 2] + record[2, 0]; // 斜排
            int result4 = record[0, 0] + record[2, 2]; // 反斜排

            if (result1 == 4 || result2 == 4 || result3 == 4 || result4 == 4)
                return 4;
            else if (result1 == 3 || result2 == 3 || result3 == 3 || result4 == 3)
                return 3;
            else
                return 0;

        }

        public void Reset()
        {
            board.Reset();
            winnerPlayer = PieceType.NONE;
        }


        public void ResetAlmostWinner()
        {
            almostWinner = PieceType.NONE;
        }
    }
}
