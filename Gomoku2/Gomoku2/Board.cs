using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku2
{
    // 管理棋盤用的class
    internal class Board
    {
        public static readonly int NODE_COUNT = 9;

        private static readonly int OFFSET = 75;
        private static readonly int NODE_R = 10;
        private static readonly int NODE_DIST = 75;

        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];

        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlacedNode  { get { return lastPlacedNode; } }

        // 取得指定座標位置上的棋子是黑棋還是白棋
        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }

        public bool CanBePlaced (int x, int y)
        {
            // 1. 找出最近的節點（Node）
            Point NodeId = findTheClosetNode (x, y);

            // 2. 如果沒有，回傳false
            if (NodeId == NO_MATCH_NODE)
                return false;

            // 3. 如果有，檢查是否已經有棋子存在
            if (pieces[NodeId.X, NodeId.Y] != null)
                return false;

            return true;
        }

        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            // 1. 找出最近的節點（Node）
            Point NodeId = findTheClosetNode(x, y);

            // 2. 如果沒有，回傳false
            if (NodeId == NO_MATCH_NODE)
                return null;                           // null = 沒有物件

            // 3. 如果有，檢查是否已經有棋子存在
            if (pieces[NodeId.X, NodeId.Y] != null)
                return null;

            // 4. 根據type產生對應的棋子
            Point formPos = convertToFormPosition(NodeId);
            if (type == PieceType.BLACK)
                pieces[NodeId.X, NodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            else if (type == PieceType.WHITE)
                pieces[NodeId.X, NodeId.Y] = new WhitePiece(formPos.X, formPos.Y);

            // 記錄最後下棋子的位置
            lastPlacedNode = NodeId;

            return pieces[NodeId.X, NodeId.Y];
        }

        // 計算棋盤視窗上的實際座標位置
        private Point convertToFormPosition(Point nodeId)      
        {
            Point formPosition = new Point();
            formPosition.X = NODE_DIST * nodeId.X + OFFSET;
            formPosition.Y = NODE_DIST * nodeId.Y + OFFSET;
            return formPosition;
        }

        // 判斷按下的點座標(x, y)
        private Point findTheClosetNode(int x, int y)
        {
            int NodeIdX = findTheClosetNode(x);
            if (NodeIdX == -1 || NodeIdX >= NODE_COUNT)
                return NO_MATCH_NODE;

            int NodeIdY = findTheClosetNode(y);
            if (NodeIdY == -1 || NodeIdY >= NODE_COUNT)
                return NO_MATCH_NODE;

            return new Point(NodeIdX, NodeIdY);
        }

        // 計算按下的點跟棋盤節點的距離，判斷跟哪個節點比較近
        private int findTheClosetNode(int pos)
        {
            if (pos < OFFSET - NODE_DIST)                // 先判斷按下的點是否在邊界跟棋盤第一條線之間
                return -1;

            pos -= OFFSET;                               // 扣除邊界

            int quotient = pos / NODE_DIST;
            int remainder = pos % NODE_DIST;

            if (remainder <= NODE_R)                     // 是否靠近左邊的節點
                return quotient;
            else if ( remainder >= NODE_DIST - NODE_R)   // 是否靠近右邊的節點
                return quotient + 1;
            else                                         // 都不符合
                return -1;
        }

        public void Reset()
        {
            Array.Clear(pieces, 0, pieces.Length);
            pieces = new Piece[NODE_COUNT, NODE_COUNT];
        }

        
    }
}
