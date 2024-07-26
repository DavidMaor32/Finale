using System;
using System.Drawing;
using System.Windows.Forms;

using Finale.Forms.Rooms;
using Finale.Helpers;
using Finale.Models;

namespace Finale.Forms {
    public partial class FormMain : FormBase {
        private static readonly Color COLOR_DEFAULT = SystemColors.Control;
        private static readonly Color COLOR_SELECTED = Color.Green;

        Data data;
        private Timer timer;
        private string path_save;

        private RoomBase room;
        private RoomBase[] rooms;
        Button selected;

        public FormMain(string path) {
            InitializeComponent();

            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += (sender, e) => {
                this.data.AddInterval(new TimeSpan(0, 0, 1));
            };

            this.help_str = @"The main goal is to beat all the rooms to get to the end...";

            this.data = Data.Instance();
            this.timer.Start();
            MessageBox.Show(this.data.ToString());

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            RoomBase[] rms = { new RoomWordle() };
            this.rooms = rms;
            this.path_save = path;

            KeyDown += OnKeyDown;

            //=======================Wordle=======================
            Button btn_wordle = new Button();
            btn_wordle.Text = "Wordle";
            btn_wordle.Click += (sender, e) => {
                this.room = new RoomWordle();
                if (this.selected != null)
                    this.selected.BackColor = COLOR_DEFAULT;
                this.selected = btn_wordle;
                this.selected.BackColor = COLOR_SELECTED;
            };
            Controls.Add(btn_wordle);
            //========================Math========================
            Button btn_math = new Button();
            btn_math.Location = new Point(btn_wordle.Width, 0);
            btn_math.Text = "Math";
            btn_math.Click += (sender, e) => {
                this.room = new RoomQuickMath();
                this.selected = btn_math;
                if (this.selected != null)
                    this.selected.BackColor = COLOR_DEFAULT;
                this.selected = btn_math;
                this.selected.BackColor = COLOR_SELECTED;
            };
            Controls.Add(btn_math);
            //========================Start=======================
            Button btn_start = new Button();
            btn_start.Location = new Point(Width / 2 - btn_start.Width / 2, Height - btn_start.Height);
            btn_start.Text = "start";
            btn_start.Click += (sender, e) => {
                if (this.room == null) {
                    MessageBox.Show("Please choose a room to play");
                    return;
                }
                Enabled = false;
                HandleResult(this.room.ShowDialog(this));
                this.room = null;
                Enabled = true;
            };
            Controls.Add(btn_start);
        }
        protected override void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;
            if (e.KeyCode == Keys.Escape) {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    if (MessageBox.Show("save progress?", "save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        FileHelper.SaveGame(this.path_save, this.data.Record());
                    DialogResult = DialogResult.Abort;
                    this.timer.Stop();
                    Close();
                }
            }
            else
                base.OnKeyDown(sender, e);
            e.Handled = true;
        }
        private void HandleResult(DialogResult result) {
            string msg, room_name, result_str = "";

            room_name = this.room.GetType().Name.Substring(4);

            switch (result) {
                case DialogResult.Abort:
                    msg = $"Didn't like {room_name}?";
                    MessageBox.Show(msg);
                    return;
                case DialogResult.Yes:
                    result_str = "won";
                    break;
                case DialogResult.No:
                    result_str = "lost";
                    break;
            }

            msg = $"You {result_str} {room_name}!";

            MessageBox.Show(msg);
        }
    }
}
