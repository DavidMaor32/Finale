using System;
using System.Windows.Forms;

using Finale.Games;

namespace Finale.Forms.Rooms {
    public partial class RoomQuickMath : RoomBase {

        private static readonly int GOAL = 10;
        private static readonly int TIME_SEC = 15;
        private static readonly TimeSpan COUNTDOWN = TimeSpan.FromSeconds(TIME_SEC);
        private TimeSpan _time;

        private int _score = 0;
        private int _failed = 0;

        bool isFrozen = false;
        Timer timer;
        MathQuiz controller;

        public RoomQuickMath() {
            InitializeComponent();

            this.controller = new MathQuiz();
            this._time = COUNTDOWN;

            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += (sender, e) => {
                this._time = this._time.Subtract(TimeSpan.FromSeconds(1));
                UpdateTime();
                if (this._time == TimeSpan.Zero) {
                    this.timer.Stop();
                    foreach (var c in Controls) {
                        if (c is Button) {
                            ((Button)c).Enabled = false;
                        }
                    }
                    MessageBox.Show("Time's up!");
                    /*DialogResult = DialogResult.Abort;
                    Close();*/
                }
            };

            Load += (sender, e) => {
                Timer timer = new Timer();
                timer.Interval = 1000;
            };


        }

        private void UpdateTime() {
            this.lbl_time.Text = "TIME:" + this._time.ToString(@"mm\:ss");
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;

            if (char.IsDigit((char)e.KeyCode)) {
                if (this.input_ans.Text == "0") {
                    MessageBox.Show("Numbers only in Decimal, NOT Octal!");
                }
                else
                    this.input_ans.Text += (char)e.KeyCode;

                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Subtract) {
                if (this.input_ans.Text.Length == 0) {
                    this.input_ans.Text = "-";
                }
                else
                    MessageBox.Show("`-` can only appear once, at left side of number!");
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Back) {
                if (this.input_ans.Text.Length > 0) {
                    this.input_ans.Text = this.input_ans.Text.Substring(0, this.input_ans.Text.Length - 1);
                }
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Enter) {
                if (this.input_ans.Text.Length == 0) {
                    MessageBox.Show("Please enter a number!");
                    e.Handled = true;
                    return;
                }
            }



            e.Handled = true;
        }

        private void input_ans_KeyDown(object sender, KeyEventArgs e) {
            if (e.Handled || !(char.IsDigit((char)e.KeyCode)) && e.KeyCode != Keys.Subtract) {
                return;
            }

            if (e.KeyCode == Keys.Subtract) {
                if (this.input_ans.Text.Length == 0) {
                    this.input_ans.Text = "-";
                }
                else
                    MessageBox.Show("`-` can only appear once, at left side of number!");
                e.Handled = true;
                return;
            }
            else if (this.input_ans.Text == "0") {
                MessageBox.Show("Numbers only in Decimal, NOT Octal!");
                e.Handled = true;
                return;
            }
            else {
                this.input_ans.Text += (char)e.KeyCode;
            }

            e.Handled = true;
        }

        private void btn_start_Click(object sender, EventArgs e) {
            this.btn_start.Dispose();
            this.timer.Start();
        }
    }
}
