using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Finale.UserControls;
using Finale.Wordle;
namespace Finale.Forms.Rooms {
    public partial class RoomWordle : RoomBase {

        private FlowLayoutPanel guesses_viewer;
        private int guess_num = 0;
        private string guess = "";
        private Wordle.Wordle _wordle;
        public RoomWordle() {
            InitializeComponent();

            KeyDown += OnKeyDown;
            KeyPreview = true;

            this._wordle = new Wordle.Wordle();

            this.guesses_viewer = new FlowLayoutPanel();
            this.guesses_viewer.FlowDirection = FlowDirection.TopDown;
            this.guesses_viewer.Padding = new Padding(0, 0, 0, 0);
            this.guesses_viewer.Location = new Point(Width / 2 + this.guesses_viewer.Width / 2, 0);
            this.guesses_viewer.AutoSize = true;
            this.guesses_viewer.Width = Width;
            for (int i = 0; i < Wordle.Wordle.NUM_GUESSES; i++)
                this.guesses_viewer.Controls.Add(new ViewerWord());
            Controls.Add(this.guesses_viewer);


            Button btn = new Button();
            btn.Text = "New Game";
            btn.Location = new Point(Width / 2 - btn.Width / 2, Height - btn.Height);
            btn.Click += (object sender, EventArgs e) => {
                this._wordle.Start();
                this.guess_num = 0;
                this.guess = "";
                foreach (Control control in this.guesses_viewer.Controls)
                    ((ViewerWord)control).Reset();
                this.guesses_viewer.Focus();
            };
            Controls.Add(btn);
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;
            if (char.IsLetter((char)e.KeyCode)) {
                AddLetter((char)e.KeyCode);
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Back && this.guess.Length > 0) {
                this.guess = this.guess.Substring(0, this.guess.Length - 1);
                UpdateGuess(this.guess);
                this.guesses_viewer.Controls[this.guess_num].Refresh();
            }

            if (e.KeyCode == Keys.Enter) {
                try {
                    UpdateGuess(this.guess);
                    ResultWordle[] res = this._wordle.Guess(this.guess);
                    UpdateColor(res);
                    this.guess_num++;
                    this.guess = "";
                    if (IsWin(res)) {
                        MessageBox.Show("YOU WIN!");
                        DialogResult = DialogResult.Yes;
                        Close();
                        //return;
                    }
                }
                catch (InvalidOperationException ex) {
                    MessageBox.Show(ex.Message);
                    DialogResult = DialogResult.No;
                    Close();
                    //return;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                base.OnKeyDown(sender, e);
            }
            e.Handled = true;
        }

        private void AddLetter(char c) {
            if (this.guess.Length < Wordle.Wordle.WORD_LENGTH) {
                this.guess += c;
                UpdateGuess(this.guess);
            }

        }

        private void UpdateGuess(string str) => ((ViewerWord)this.guesses_viewer.Controls[this.guess_num]).SetWord(this.guess);
        private void UpdateColor(ResultWordle[] res) => ((ViewerWord)this.guesses_viewer.Controls[this.guess_num]).SetColor(res);
        private bool IsWin(ResultWordle[] res) => res.All(r => r == ResultWordle.Match);
    }
}
