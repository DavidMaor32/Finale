using System;
using System.Windows.Forms;

using Finale.Games;

namespace Finale.Forms.Rooms {
    public partial class RoomQuickMath : RoomBase {

        private static readonly int GOAL = 5;
        private static readonly int TIME_SEC = 15;
        private static readonly TimeSpan COUNTDOWN = TimeSpan.FromSeconds(TIME_SEC);
        private TimeSpan _time;

        private Expr expr;

        private int _score = 0;
        private int _failed = 0;

        bool isFrozen = false;
        MathQuiz controller;

        public RoomQuickMath() {
            InitializeComponent();
            this.help_str = $"to win you need a score of minimum {GOAL} within {TIME_SEC} seconds. \n\neach correct answer is 1.\n each wrong answer is -1.";

            this.lbl_time.Location = new System.Drawing.Point(Width / 2 - this.lbl_time.Width / 2, (int)(0.1 * Height));
            this.panel1.Location = new System.Drawing.Point(Width / 2 - this.panel1.Width / 2, (int)(0.3 * Height));
            /*this.btn_start.Location = this.panel1.Location;
            this.btn_start.Text = "START";
            this.btn_start.Bounds = this.panel1.Bounds;
            */
            this.btn_start.BringToFront();

            this.lbl_time.Text = "TIME:" + COUNTDOWN.ToString(@"mm\:ss");
            this.controller = new MathQuiz();
            this._time = COUNTDOWN;

            this.timer.Tick += (sender, e) => {
                if (this.isFrozen) {
                    return;
                }
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
                    MessageBox.Show($"score:{this._score - this._failed}\ncorrect:{this._score} miss:{this._failed}");
                    DialogResult = this._score - this._failed >= GOAL ? DialogResult.Yes : DialogResult.No;
                    Close();
                }
            };

            KeyDown += OnKeyDown;
        }

        private void UpdateTime() {
            this.lbl_time.Text = "TIME:" + this._time.ToString(@"mm\:ss");
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;
            if (e.KeyCode == Keys.Escape) {
                this.isFrozen = true;
                base.OnKeyDown(sender, e);
                if (DialogResult == DialogResult.Abort)
                    this.timer.Stop();
                this.isFrozen = false;
            }
            if (char.IsDigit((char)e.KeyCode)) {
                if (this.input_ans.Text == "0") {
                    this.isFrozen = true;
                    MessageBox.Show("Numbers only in Decimal, NOT Octal!");
                    this.isFrozen = false;
                }
                else
                    this.input_ans.Text += (char)e.KeyCode;

                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract) {
                if (this.input_ans.Text.Length == 0) {
                    this.input_ans.Text = "-";
                }
                else {
                    this.isFrozen = true;
                    MessageBox.Show("`-` can only appear once, at left side of number!");
                    this.isFrozen = false;
                }
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
                    this.isFrozen = true;
                    MessageBox.Show("Please enter a number!");
                    this.isFrozen = false;
                    e.Handled = true;
                    return;
                }
                else {
                    Console.WriteLine(this.expr.ToString() + "ans: " + this.input_ans.Text);
                    if (int.Parse(this.input_ans.Text) == this.expr.Val()) {
                        Console.WriteLine("good");
                        this._score++;
                    }
                    else {
                        Console.WriteLine("bad");
                        this._failed++;
                    }
                    this.expr = this.controller.GetRandomExpression();
                    UpdateExpr();
                    this.input_ans.Text = "";
                    e.Handled = true;
                    return;
                }
            }
            else {
                base.OnKeyDown(sender, e);
            }


            e.Handled = true;
        }
        private void btn_start_Click(object sender, EventArgs e) {
            this.btn_start.Dispose();
            this.timer.Start();
            this.expr = this.controller.GetRandomExpression();
            UpdateExpr();
        }
        private void UpdateExpr() {
            this.input_ans.Text = "";
            this.lbl_operand_1.Text = this.expr.operand1.ToString();
            this.lbl_operand_2.Text = this.expr.operand2.ToString();
            switch (this.expr.op) {
                case MathOperator.Add:
                    this.lbl_operator.Text = "+";
                    break;
                case MathOperator.Sub:
                    this.lbl_operator.Text = "-";
                    break;
                case MathOperator.Mul:
                    this.lbl_operator.Text = "*";
                    break;
                case MathOperator.Div:
                    this.lbl_operator.Text = "/";
                    break;
                default:
                    break;
            }
        }
    }
}
