using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Finale.Enums;
using Finale.Forms.Rooms;
using Finale.Helpers;
using Finale.Models;

namespace Finale.Forms {
    public partial class FormMain : FormBase {
        private static readonly Color COLOR_DEFAULT =       SystemColors.Control;
        private static readonly Color COLOR_SELECTED =      Color.Green;
        private static readonly Color COLOR_WALL =          ColorTranslator.FromHtml("#2C3E50");
        private static readonly Color COLOR_GATE =          SystemColors.ControlDarkDark;
        private static readonly Color COLOR_GATE_SOLVER =   SystemColors.ControlLight;

        private static readonly int speed = 4;
        private static readonly int interval = 16;


        private Data    data;
        private Timer   EngineTimer;
        private string  path_save;

        private bool left, right, up, down;
        private bool is_playing = false, overlay = false;

        private List<Label> walls;
        private List<PictureBox> keys;

        public FormMain(string path) {
            InitializeComponent();
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            this.help_str = @"The main goal is to beat all the rooms to get to the end...";

            this.data = Data.Instance();

            this.path_save = path;
            this.walls = new List<Label>();
            this.keys = new List<PictureBox>();
            this.player.BringToFront();

            this.EngineTimer = new Timer();
            this.EngineTimer.Interval = interval;
            this.EngineTimer.Tick += OnTick;
            this.EngineTimer.Start();


            //scaling from designer
            int init_width = 569, init_height = 312;
            float dx = ((float)Width+1) / init_width, dy = ((float)Height+1) / init_height;
            int init_x = 0, init_y = 0;
            foreach (Control c in Controls) {
                init_x = (int)(c.Location.X * dx);
                init_y = (int)(c.Location.Y * dy);
                c.Location = new Point(init_x, init_y);
                c.Width = (int)(c.Width * dx);
                c.Width += c.Width % 8;
                c.Height = (int)(c.Height * dy);
                c.Height += c.Height % 8;
            }


            this.player.BackColor = Color.Transparent;


            this.lbl_name.Height = this.label8.Height;
            this.lbl_name.Location = new Point(this.label6.Width, 0);
            this.lbl_name.Text = this.data.Name;
            this.lbl_name.BackColor = COLOR_WALL;
            this.lbl_name.ForeColor = Color.White;
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new Font("Arial", 0.58f * this.label8.Height, FontStyle.Bold);

            //grouping based on tag
            foreach (Control control in Controls) {
                control.Margin = new Padding(0);
                if ((control.Tag.Equals("wall"))) {
                    this.walls.Add((Label)control);
                    control.BackColor = COLOR_WALL;
                }
                else if (control.Tag.Equals("key")) {
                    this.keys.Add((PictureBox)control);
                    control.BackColor = Color.Transparent;
                }
                if (control.Name.StartsWith("gate"))
                    control.BackColor = COLOR_GATE;
            }

            //eliminating obtained keys and walls
            foreach (RoomCode code in this.data.Solved) {
                Label wall = this.walls.Find(w => w.Name.Equals("wall"+(int)code));
                PictureBox key = this.keys.Find(k => k.Name.Equals("key"+(int)code));
                if (wall != null) {
                    Controls.Remove(wall);
                    wall.Dispose();
                    this.walls.Remove(wall);
                }
                if (key != null) {
                    Controls.Remove(key);
                    key.Dispose();
                    this.keys.Remove(key);
                }
                GC.Collect();
            }

            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
        }


        private void OnTick(object sender, EventArgs e) {
            this.data.AddInterval(new TimeSpan(0, 0, 1));
            this.lbl_name.Text = this.data.Name + " " + this.data.Record().time.ToString("hh':'mm':'ss");
            if (this.is_playing)
                return;

            //if obtained all keys
            bool end = this.data.Solved.Length == Enum.GetValues(typeof(RoomCode)).Length;
            bool touch_end = this.player.Bounds.IntersectsWith(this.gate_final.Bounds);
            UpdateLocation();

            PictureBox key = GetIntersectedKey();


            if (key == null && !touch_end) {
                this.overlay = false;
                return;
            }

            //to disable recalling the room while playing
            if (this.overlay)
                return;
            this.left = this.right = this.up = this.down = false;

            this.is_playing = true;
            this.overlay = true;
            DialogResult res = DialogResult.None;
            Point p = this.player.Location;




            if (touch_end && !end) {
                this.player.Location = new Point(this.player.Location.X - speed, this.player.Location.Y);
                this.overlay = false;
                this.is_playing = false;
                return;
            }
            else if (touch_end) {
                this.left = this.right = this.up = this.down = false;
                this.is_playing = true;
                if (MessageBox.Show($"Congratulations! You have completed the game!\n\"{this.data.Name} spent only {this.data.Record().time.ToString()}playing...\"", "Game Over", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    DialogResult = DialogResult.OK;
                    Dispose();
                }
                this.player.Location = new Point(p.X - 2 * speed, p.Y);
                this.is_playing = false;
                return;
            }


            //room tic tac toe
            if (key == this.key1) {
                res = new RoomTicTacToe().ShowDialog();
                if (res == DialogResult.Yes)
                    this.data.AddRoom(RoomCode.TicTacToe);
                else
                    p = new Point(p.X - speed, p.Y);
            }
            //room math
            if (key == this.key2) {
                res = new RoomQuickMath().ShowDialog();
                if (res == DialogResult.Yes)
                    this.data.AddRoom(RoomCode.Math);
                else
                    p = new Point(p.X - speed, p.Y);
            }
            //room wordle
            if (key == this.key3) {
                res = new RoomWordle().ShowDialog();
                if (res == DialogResult.Yes)
                    this.data.AddRoom(RoomCode.Wordle);
                else
                    p = new Point(p.X - speed, p.Y);
            }
            //room sort
            if (key == this.key4) {
                res = new RoomSortNumbers().ShowDialog();
                if (res == DialogResult.Yes)
                    this.data.AddRoom(RoomCode.Sort);
                else
                    p = new Point(p.X - speed, p.Y + speed);
            }
            //room SimonSays
            if (key == this.key5) {
                res = new RoomSimonSays().ShowDialog();
                if (res == DialogResult.Yes)
                    this.data.AddRoom(RoomCode.SimonSays);
                else
                    p = new Point(p.X + speed, p.Y);
            }

            //eliminating obtained keys and walls
            if (res == DialogResult.Yes) {
                Label wall = this.walls.Find(w => w.Name.Equals("wall"+key.Name.Substring(3).ToString().ToLower()));
                if (wall != null) {
                    Controls.Remove(wall);
                    wall.Dispose();
                    this.walls.Remove(wall);
                }
                if (key != null) {
                    Controls.Remove(key);
                    key.Dispose();
                    this.keys.Remove(key);
                }
                GC.Collect();
            }
            this.player.Location = p;
            this.is_playing = false;
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e) {
            throw new NotImplementedException();
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;
            if (e.KeyCode == Keys.Escape) {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    if (MessageBox.Show("save progress?", "save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        FileHelper.SaveGame(this.path_save, this.data.Record());
                    DialogResult = DialogResult.Abort;
                    Dispose();
                }
            }
            if ("W A S D UP DOWN LEFT RIGHT".Contains(e.KeyCode.ToString().ToUpper())) {
                Toggle(e.KeyCode.ToString().ToUpper(), true);
                e.Handled = true;
                return;
            }
            else
                base.OnKeyDown(sender, e);
            e.Handled = true;
        }

        private void Toggle(string dir, bool state) {
            if (dir == "W" || dir == "UP")
                this.up = state;
            else if (dir == "A" || dir == "LEFT")
                this.left = state;
            else if (dir == "S" || dir == "DOWN")
                this.down = state;
            else if (dir == "D" || dir == "RIGHT")
                this.right = state;
        }

        private void OnKeyUp(Object sender, KeyEventArgs e) {
            if ("W A S D UP DOWN LEFT RIGHT".Contains(e.KeyCode.ToString().ToUpper())) {
                Toggle(e.KeyCode.ToString().ToUpper(), false);
                e.Handled = true;
                return;
            }
        }


        private void UpdateLocation() {
            Point p = new Point(this.player.Location.X, this.player.Location.Y);
            Rectangle r = this.player.Bounds;

            if (this.left) {
                if (this.walls.TrueForAll(wall => !wall.Bounds.IntersectsWith(new Rectangle(p.X - speed, p.Y, r.Width, r.Height))))
                    p.X -= speed;

            }
            if (this.right) {
                if (this.walls.TrueForAll(wall => !wall.Bounds.IntersectsWith(new Rectangle(p.X + speed, p.Y, r.Width, r.Height))))
                    p.X += speed;
            }
            if (this.up) {
                if (this.walls.TrueForAll(wall => !wall.Bounds.IntersectsWith(new Rectangle(p.X, p.Y - speed, r.Width, r.Height))))
                    p.Y -= speed;
            }
            if (this.down) {
                if (this.walls.TrueForAll(wall => !wall.Bounds.IntersectsWith(new Rectangle(p.X, p.Y + speed, r.Width, r.Height))))
                    p.Y += speed;
            }
            this.player.Location = p;
        }

        private PictureBox GetIntersectedKey() {
            foreach (PictureBox p in this.keys) {
                if (p.Bounds.IntersectsWith(this.player.Bounds)) {
                    return p;
                }
            }
            return null;
        }


        private Control GetControl(string name) {
            foreach (Control c in Controls) {
                if (c.Name == name)
                    return c;
            }
            return null;
        }
    }
}
