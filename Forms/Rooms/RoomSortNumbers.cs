using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Finale.Forms.Rooms {
    public partial class RoomSortNumbers : RoomBase {
        int SIZE = 4;
        Button[][] buttons;
        int easter_egg = 10;
        public RoomSortNumbers() {
            InitializeComponent();

            BackColor = ColorTranslator.FromHtml("#D8DDEF");
            this.help_str = "Rearrange the numbers in ascending order by moving the empty cell to the right, left, up or down."
                + "so for example, 4x4 would be like that: \n1 2 3 4\n 5 6 7 8\n 9 10 11 12\n 13 14 15";

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            this.buttons = new Button[this.SIZE][];
            for (int i = 0; i < this.SIZE; i++) {
                this.buttons[i] = new Button[this.SIZE];
            }
            Button temp;
            this.panel_rows.Location = new System.Drawing.Point(Width / 2 - this.panel_rows.Width / 2, Height / 2 - this.panel_rows.Height / 2);
            for (int row = 0; row < this.SIZE; row++) {
                for (int col = 0; col < this.SIZE; col++) {
                    this.buttons[row][col] = this.panel_rows.Controls[row].Controls[col] as Button;
                    temp = this.buttons[row][col];
                    temp.Tag = $"{row},{col}";
                    temp.Click += OnClick;
                }
            }

            Shuffle();
        }
        private void OnClick(object sender, System.EventArgs e) {
            Button button = sender as Button;

            if (button.Equals(this.buttons[0][0])) {
                this.easter_egg--;
                if (this.easter_egg == 0) {
                    MessageBox.Show("You found the easter egg!");
                    MessageBox.Show("You win!");
                    DialogResult = DialogResult.Yes;
                    Close();
                }
            }
            else
                this.easter_egg = 10;

            if (button.Text == "")
                return;
            int row = int.Parse(button.Tag.ToString().Split(',')[0]);
            int col = int.Parse(button.Tag.ToString().Split(',')[1]);
            if (row > 0 && this.buttons[row - 1][col].Text == "") {
                this.buttons[row - 1][col].Text = button.Text;
                button.Text = "";
            }
            else if (row < this.SIZE - 1 && this.buttons[row + 1][col].Text == "") {
                this.buttons[row + 1][col].Text = button.Text;
                button.Text = "";
            }
            else if (col > 0 && this.buttons[row][col - 1].Text == "") {
                this.buttons[row][col - 1].Text = button.Text;
                button.Text = "";
            }
            else if (col < this.SIZE - 1 && this.buttons[row][col + 1].Text == "") {
                this.buttons[row][col + 1].Text = button.Text;
                button.Text = "";
            }
            if (IsSorted()) {
                MessageBox.Show("You win!");
                DialogResult = DialogResult.Yes;
                Close();
            }
        }
        private bool IsSorted() {
            int val = 1;
            for (int row = 0; row < this.SIZE - 1; row++) {
                for (int col = 0; col < this.SIZE; col++) {
                    if (this.buttons[row][col].Text != val.ToString())
                        return false;
                    val++;
                }
            }
            for (int col = 0; col < this.SIZE - 1; col++) {
                if (this.buttons[this.SIZE - 1][col].Text != val.ToString())
                    return false;
                val++;
            }
            return true;
        }

        private void Shuffle() {
            Random rand = new Random();
            List<int> numbers = new List<int>();
            int val,i=0;
            do {
                val = rand.Next(1, this.SIZE * this.SIZE);
                if (!numbers.Contains(val)) {
                    numbers.Add(val);
                }
            }
            while (numbers.Count < this.SIZE * this.SIZE - 1);

            int[] arr = numbers.ToArray();
            for (int row = 0; row < this.SIZE; row++) {
                for (int col = 0; col < this.SIZE; col++) {
                    if (row == this.SIZE - 1 && col == this.SIZE - 1) {
                        this.buttons[row][col].Text = "";
                    }
                    else {
                        this.buttons[row][col].Text = arr[i++].ToString();
                    }
                }
            }
        }

        private bool IsSolveable() {
            int inversions = 0;
            int[] arr = new int[this.SIZE * this.SIZE - 1];
            int i = 0;
            for (int row = 0; row < this.SIZE; row++) {
                for (int col = 0; col < this.SIZE; col++) {
                    if (this.buttons[row][col].Text != "") {
                        arr[i++] = int.Parse(this.buttons[row][col].Text);
                    }
                }
            }
            for (i = 0; i < arr.Length - 1; i++) {
                for (int j = i + 1; j < arr.Length; j++) {
                    if (arr[i] > arr[j])
                        inversions++;
                }
            }
            return inversions % 2 == 0;
        }
    }
}
