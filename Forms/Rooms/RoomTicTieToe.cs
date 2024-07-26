using System.Drawing;
using System.Windows.Forms;

namespace Finale.Forms.Rooms {
    public partial class RoomTicTieToe : RoomBase {
        int BOARD_SIZE;
        Button[,] btns;
        TicTieToe.TicTieToe controller;
        FlowLayoutPanel rows;
        public RoomTicTieToe() {
            InitializeComponent();

            this.controller = new TicTieToe.TicTieToe();
            this.BOARD_SIZE = TicTieToe.TicTieToe.BOARD_SIZE;
            this.btns = new Button[this.BOARD_SIZE, this.BOARD_SIZE];
            Button _temp;
            for (int i = 0; i < this.BOARD_SIZE; i++) {
                for (int j = 0; j < this.BOARD_SIZE; j++) {
                    this.btns[i, j] = new Button();
                    _temp = this.btns[i, j];
                    _temp.Text = "";
                    _temp.Name = $"{i},{j}";
                    _temp.Size = new Size(50, 50);

                    _temp.Click += (sender, e) => {
                        ((Button)sender).Enabled = false;
                        int row = int.Parse(((Button)sender).Name.Split(',')[0]);
                        int col = int.Parse(((Button)sender).Name.Split(',')[1]);
                        this.controller.MakeMove(row, col);
                        ((Button)sender).Text = "X";
                        if (this.controller.GetWinner() != TicTieToe.State.Empty) {
                            MessageBox.Show(this.controller.GetWinner().ToString() + " wins");
                            DialogResult = this.controller.GetWinner() == TicTieToe.State.X ? DialogResult.Yes : DialogResult.No;
                            Close();
                        }
                        this.btns[this.controller.LastMove.X, this.controller.LastMove.Y].Enabled = false;
                        this.btns[this.controller.LastMove.X, this.controller.LastMove.Y].Text = "O";

                    };
                }
            }


            this.rows = new FlowLayoutPanel();
            this.rows.FlowDirection = FlowDirection.TopDown;
            this.rows.Padding = new Padding(0, 0, 0, 0);
            this.rows.Location = new Point(Width / 2 + this.rows.Width / 2, 0);
            this.rows.AutoSize = true;

            Controls.Add(this.rows);
            for (int i = 0; i < this.BOARD_SIZE; i++) {
                FlowLayoutPanel row = new FlowLayoutPanel();
                row.FlowDirection = FlowDirection.LeftToRight;
                row.AutoSize = true;
                for (int j = 0; j < this.BOARD_SIZE; j++) {
                    row.Controls.Add(this.btns[i, j]);
                }
                this.rows.Controls.Add(row);
            }
        }
    }
}
