namespace Gomoku2
{
    public partial class Form1 : Form
    {
        private GameManager game = new GameManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);

                // 檢查是否有人獲勝
                if (game.WinnerPlayer == PieceType.BLACK)
                {
                    MessageBox.Show("黑棋獲勝");
                    Restart();
                }
                else if (game.WinnerPlayer == PieceType.WHITE)
                { 
                    MessageBox.Show("白棋獲勝");
                    Restart();
                }

                // 檢查是否有人快勝出
                if (game.AlmostWinner == PieceType.BLACK)
                {
                    MessageBox.Show("黑棋快獲勝了");
                    game.ResetAlmostWinner();
                }
                else if (game.AlmostWinner == PieceType.WHITE)
                {
                    MessageBox.Show("白棋快獲勝了");
                    game.ResetAlmostWinner();
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Restart()
        {
            game.Reset();
            Controls.Clear();
        }
    }
}
