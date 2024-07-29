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

            this.help_str = $"In Wordle you have {Wordle.Wordle.NUM_GUESSES} to guess a {Wordle.Wordle.WORD_LENGTH} letter word.\n" +
                        $"Green - the letter appear in the exact location.\n" +
                        $"Yellow - the letter appear in the word but at different location. \n" +
                        $"Gray - the letter is not in the word.";

            KeyDown += OnKeyDown;

            this._wordle = new Wordle.Wordle();

            this.guesses_viewer = new FlowLayoutPanel();
            this.guesses_viewer.FlowDirection = FlowDirection.TopDown;
            this.guesses_viewer.Padding = new Padding(0, 0, 0, 0);
            this.guesses_viewer.Location = new Point(Width / 2 - this.guesses_viewer.Width, Height / 4);
            this.guesses_viewer.AutoSize = true;
            this.guesses_viewer.Width = Width;
            for (int i = 0; i < Wordle.Wordle.NUM_GUESSES; i++)
                this.guesses_viewer.Controls.Add(new ViewerWord());
            Controls.Add(this.guesses_viewer);
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F9) {
                MessageBox.Show("You found this easter egg!\nyou won! but i can't tell you what was the word...\n\nLiterally, i can't.");
                DialogResult = DialogResult.Yes;
                Close();
                return;
            }
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
