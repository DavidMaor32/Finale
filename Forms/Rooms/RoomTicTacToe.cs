using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Finale.Forms.Rooms {
    public partial class RoomTicTacToe : RoomBase {
        public enum Player {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        List<Button> buttons;
        Button[,] board;

        public RoomTicTacToe() {
            InitializeComponent();
            this.help_str = "in case you are NOT familiar with the game, the goal is to get 3 of your symbols in a row, either horizontally, vertically or diagonally.\n\nyou are X, the computer is O.\n\nyou start first.\n\nGOOD LUCK!";


            StartGame();
        }

        private void CPUMove(object sender, EventArgs e) {
            DisableAllButtons();
            if (this.buttons.Count > 0) {
                int index = this.random.Next(this.buttons.Count);
                this.buttons[index].Enabled = false;
                this.currentPlayer = Player.O;
                this.buttons[index].Text = this.currentPlayer.ToString();
                this.buttons[index].BackColor = Color.DarkSalmon;
                this.buttons.RemoveAt(index);
                UpdateBoard();
                if (!CheckGame()) {
                    this.CPUTimer.Stop();
                    EnableEmptyButtons();
                }
            }
        }

        private void PlayerClickButton(object sender, EventArgs e) {
            var button = (Button)sender;
            this.currentPlayer = Player.X;
            button.Text = this.currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.LightPink;
            this.buttons.Remove(button);
            UpdateBoard();
            if (!CheckGame()) {
                DisableAllButtons();
                this.CPUTimer.Start();
            }
        }

        private bool CheckGame() {
            if (CheckWin(Player.X)) {
                this.CPUTimer.Stop();
                MessageBox.Show("You WON!");
                DialogResult = DialogResult.Yes;
                Close();
                return true;
            }
            else if (CheckWin(Player.O)) {
                this.CPUTimer.Stop();
                MessageBox.Show("You LOST!");
                DialogResult = DialogResult.No;
                Close();
                return true;
            }
            else if (IsFull()) {
                MessageBox.Show("Tie, no winners");
                DialogResult = DialogResult.Cancel;
                Close();
            }
            return false;
        }
        private bool IsFull() {
            return this.buttons.All(button => button.Enabled = false);
        }
        private bool CheckWin(Player player) {
            string playerSymbol = player.ToString();

            // Check rows and columns
            for (int i = 0; i < 3; i++) {
                if (this.board[i, 0].Text == playerSymbol && this.board[i, 1].Text == playerSymbol && this.board[i, 2].Text == playerSymbol)
                    return true;
                if (this.board[0, i].Text == playerSymbol && this.board[1, i].Text == playerSymbol && this.board[2, i].Text == playerSymbol)
                    return true;
            }

            // Check diagonals
            if (this.board[0, 0].Text == playerSymbol && this.board[1, 1].Text == playerSymbol && this.board[2, 2].Text == playerSymbol)
                return true;
            if (this.board[0, 2].Text == playerSymbol && this.board[1, 1].Text == playerSymbol && this.board[2, 0].Text == playerSymbol)
                return true;

            return false;
        }

        private void StartGame() {
            this.buttons = new List<Button> { this.button1, this.button2, this.button3,
                                         this.button4, this.button5, this.button6,
                                         this.button7, this.button8, this.button9 };
            this.board = new Button[3, 3] {
                { this.button1, this.button2, this.button3 },
                { this.button4, this.button5, this.button6 },
                { this.button7, this.button8, this.button9 }
            };

            foreach (Button x in this.buttons) {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }

        private void UpdateBoard() {
            this.board[0, 0] = this.button1;
            this.board[0, 1] = this.button2;
            this.board[0, 2] = this.button3;
            this.board[1, 0] = this.button4;
            this.board[1, 1] = this.button5;
            this.board[1, 2] = this.button6;
            this.board[2, 0] = this.button7;
            this.board[2, 1] = this.button8;
            this.board[2, 2] = this.button9;
        }

        private void DisableAllButtons() {
            foreach (Button button in this.board) {
                button.Enabled = false;
            }
        }

        private void EnableEmptyButtons() {
            foreach (Button button in this.buttons) {
                button.Enabled = true;
            }
        }
    }
}
