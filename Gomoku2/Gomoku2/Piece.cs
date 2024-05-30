using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku2
{
    // 管理棋子用的class
    abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_WIDTH = 50;    // 宣告棋子圖片的大小，設定成唯讀靜態型態，也可以用來設定座標
        public Piece(int x, int y) 
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - IMAGE_WIDTH / 2, y - IMAGE_WIDTH / 2);
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
        }

        public abstract PieceType GetPieceType();
    }
}
