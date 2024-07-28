using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Finale.Forms.Rooms {
    public partial class RoomTicTacToe : RoomBase {

        public enum Player {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        List<Button> buttons;
        bool pause = false;

        public RoomTicTacToe() {
            InitializeComponent();
            StartGame();
        }

        private void CPUMove(object sender, EventArgs e) {
            if (this.buttons.Count > 0) {
                int index=this.random.Next(this.buttons.Count);
                this.buttons[index].Enabled = false;
                this.currentPlayer = Player.O;
                this.buttons[index].Text = this.currentPlayer.ToString();
                this.buttons[index].BackColor = Color.DarkSalmon;
                this.buttons.RemoveAt(index);
                CheckGame();
                this.CPUTimer.Stop();
                this.pause = false;
            }
        }

        private void PlayerClickButton(object sender, EventArgs e) {
            if (this.pause) {
                return;
            }
            var button = (Button)sender;
            this.currentPlayer = Player.X;
            button.Text = this.currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.LightPink;
            this.buttons.Remove(button);
            CheckGame();
            this.pause = true;
            this.CPUTimer.Start();
        }

        private void CheckGame() {
            if (this.button1.Text == "X" && this.button2.Text == "X" && this.button3.Text == "X"
                 || this.button4.Text == "X" && this.button5.Text == "X" && this.button6.Text == "X"
                 || this.button7.Text == "X" && this.button8.Text == "X" && this.button9.Text == "X"
                 || this.button1.Text == "X" && this.button4.Text == "X" && this.button7.Text == "X"
                 || this.button2.Text == "X" && this.button5.Text == "X" && this.button8.Text == "X"
                 || this.button3.Text == "X" && this.button6.Text == "X" && this.button9.Text == "X"
                 || this.button1.Text == "X" && this.button5.Text == "X" && this.button9.Text == "X"
                 || this.button3.Text == "X" && this.button5.Text == "X" && this.button7.Text == "X") {
                this.CPUTimer.Stop();
                MessageBox.Show("You WON!");
                DialogResult = DialogResult.Yes;
                Close();

            }
            else if (this.button1.Text == "O" && this.button2.Text == "O" && this.button3.Text == "O"
                || this.button4.Text == "O" && this.button5.Text == "O" && this.button6.Text == "O"
                || this.button7.Text == "O" && this.button8.Text == "O" && this.button9.Text == "O"
                || this.button1.Text == "O" && this.button4.Text == "O" && this.button7.Text == "O"
                || this.button2.Text == "O" && this.button5.Text == "O" && this.button8.Text == "O"
                || this.button3.Text == "O" && this.button6.Text == "O" && this.button9.Text == "O"
                || this.button1.Text == "O" && this.button5.Text == "O" && this.button9.Text == "O"
                || this.button3.Text == "O" && this.button5.Text == "O" && this.button7.Text == "O") {
                this.CPUTimer.Stop();
                MessageBox.Show("You LOST!");
                DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void StartGame() {
            this.buttons = new List<Button>{this.button1, this.button2, this.button3,
                                                    this.button4, this.button5, this.button6,
                                                    this.button7, this.button8, this.button9};
            foreach (Button x in this.buttons) {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }

        }
    }
}
