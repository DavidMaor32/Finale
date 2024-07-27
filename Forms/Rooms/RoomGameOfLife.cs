using System.Windows.Forms;

using Finale.Games;

namespace Finale.Forms.Rooms {
    public partial class RoomGameOfLife : RoomBase {

        private static readonly uint DEFAULT_WIDTH = 40;
        private static readonly uint DEFAULT_HEIGHT = 30;

        GameOfLife controller;
        FlowLayoutPanel board;
        public RoomGameOfLife() {
            InitializeComponent();
            this.controller = new GameOfLife(DEFAULT_HEIGHT, DEFAULT_WIDTH);

            //initialize board
            this.board = new FlowLayoutPanel();
            this.board.FlowDirection = FlowDirection.TopDown;

            //initialize rows
            FlowLayoutPanel temp;
            for (int row = 0; row < DEFAULT_HEIGHT; row++) {
                temp = new FlowLayoutPanel();
                temp.FlowDirection = FlowDirection.LeftToRight;
                this.board.Controls.Add(temp);
            }

            //initialize buttons
            Button btn;
            for (int row = 0; row < DEFAULT_HEIGHT; row++) {
                for (int col = 0; col < DEFAULT_WIDTH; col++) {
                    btn = new Button();
                    btn.Tag = $"{row},{col}";
                    btn.Size = new System.Drawing.Size(20, 20);
                    btn.Margin = new Padding(0);
                    btn.Click += OnClick;
                    (this.board.Controls[row]).Controls.Add(btn);
                }
            }



            FlowLayoutPanel controls = new FlowLayoutPanel();
            controls.FlowDirection = FlowDirection.TopDown;
            controls.Location = new System.Drawing.Point(0, 0);

            Controls.Add(controls);
        }
        private void UpdateBoard() {
            bool[][] states = this.controller.Board;
            Button btn;
            for (int row = 0; row < DEFAULT_HEIGHT; row++) {
                for (int col = 0; col < DEFAULT_WIDTH; col++) {
                    btn = (Button)(this.board.Controls[row]).Controls[col];
                    btn.BackColor = states[row][col] ? System.Drawing.Color.Black : System.Drawing.Color.White;
                }
            }
        }

        private void OnClick(object sender, System.EventArgs e) {
            Button b = (Button)sender;
            b.BackColor = b.BackColor == System.Drawing.Color.Black ? System.Drawing.Color.White : System.Drawing.Color.Black;
            bool isAlive = b.BackColor == System.Drawing.Color.Black;
            int row = int.Parse(b.Tag.ToString().Split(',')[0]);
            int col = int.Parse(b.Tag.ToString().Split(',')[1]);
            this.controller.SetCell((uint)row, (uint)col, isAlive);
        }
    }
}
