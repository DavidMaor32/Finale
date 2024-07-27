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
        private static readonly Color COLOR_PLAYER =        Color.Tan;

        private static readonly int speed = 5;
        private static readonly int interval = 16;


        private Data    data;
        private Timer   EngineTimer;
        private string  path_save;

        private bool left, right, up, down;
        private bool is_playing = false, overlay = false;

        private RoomBase room;
        private List<Label> walls;
        private List<Label> gates;

        public FormMain(string path) {
            InitializeComponent();
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            this.help_str = @"The main goal is to beat all the rooms to get to the end...";

            this.path_save = path;
            this.walls = new List<Label>();
            this.gates = new List<Label>();
            this.data = Data.Instance();


            int init_width = 569, init_height = 312;
            float dx = ((float)Width+1) / init_width, dy = ((float)Height+1) / init_height;
            int init_x = 0, init_y = 0;
            foreach (Control c in Controls) {
                init_x = (int)(c.Location.X * dx);
                init_y = (int)(c.Location.Y * dy);
                c.Location = new Point(init_x, init_y);
                c.Width = (int)(c.Width * dx);
                c.Height = (int)(c.Height * dy);
            }


            foreach (Control control in Controls) {
                control.Anchor = AnchorStyles.None;
                control.Margin = new Padding(0);
                if ((control.Tag.Equals("wall"))) {
                    this.walls.Add((Label)control);
                    control.BackColor = COLOR_WALL;
                }
                else if (control.Tag.Equals("gate")) {
                    this.gates.Add((Label)control);
                }
            }

            foreach (RoomCode code in this.data.Solved) {
                GetGate(code).BackColor = COLOR_GATE_SOLVER;
            }


            this.EngineTimer = new Timer();
            this.EngineTimer.Interval = interval;
            this.EngineTimer.Tick += OnTick;
            this.EngineTimer.Start();


            KeyDown += OnKeyDown;
            KeyPress += OnKeyPress;
            KeyUp += OnKeyUp;
        }


        private void OnTick(object sender, EventArgs e) {
            this.data.AddInterval(new TimeSpan(0, 0, 1));
            if (this.is_playing)
                return;

            UpdateLocation();
            Label gate = GetIntersectedGate();

            if (gate == null) {
                this.overlay = false;
                return;
            }
            if (this.overlay)
                return;
            this.left = this.right = this.up = this.down = false;

            this.is_playing = true;
            this.overlay = true;
            DialogResult res = DialogResult.None;
            Point p = this.player.Location;
            //room wordle
            if (gate == this.gate_wordle) {
                if (!this.data.Exists(RoomCode.Wordle)) {
                    res = new RoomWordle().ShowDialog();
                    if (res == DialogResult.Yes)
                        this.data.AddRoom(RoomCode.Wordle);
                    else
                        p = new Point(p.X - speed, p.Y);
                }
                else {
                    if (MessageBox.Show("You already won, wanna play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        new RoomWordle().ShowDialog();
                }
            }
            //room math
            if (gate == this.gate_math) {
                if (!this.data.Exists(RoomCode.Math)) {
                    res = new RoomQuickMath().ShowDialog();
                    if (res == DialogResult.Yes)
                        this.data.AddRoom(RoomCode.Math);
                    else
                        p = new Point(p.X, p.Y + speed);
                }
                else {
                    if (MessageBox.Show("You already won, wanna play again?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        new RoomQuickMath().ShowDialog();
                }
            }




            if (res == DialogResult.Yes)
                gate.BackColor = COLOR_GATE_SOLVER;
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
            if ("WASD".Contains(e.KeyCode.ToString())) {
                e.Handled = true;
                return;
            }
            else
                base.OnKeyDown(sender, e);
            e.Handled = true;
        }

        private void OnKeyPress(Object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case 'w':
                case 'W':
                case (char)Keys.Up:
                    this.up = true;
                    break;
                case 'a':
                case 'A':
                case (char)Keys.Left:
                    this.left = true;
                    break;
                case 's':
                case 'S':
                case (char)Keys.Down:
                    this.down = true;
                    break;
                case 'd':
                case 'D':
                case (char)Keys.Right:
                    this.right = true;
                    break;
            }
        }

        private void OnKeyUp(Object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.W:
                case Keys.Up:
                    this.up = false;
                    break;
                case Keys.A:
                case Keys.Left:
                    this.left = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    this.down = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    this.right = false;
                    break;
            }
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e) {

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

        private Label GetIntersectedGate() {
            foreach (Label gate in this.gates) {
                if (gate.Bounds.IntersectsWith(this.player.Bounds)) {
                    return gate;
                }
            }
            return null;
        }

        private Label GetGate(RoomCode code) {
            foreach (Label gate in this.gates) {
                if (gate.Name.ToLower().EndsWith(code.ToString().ToLower())) {
                    return gate;
                }
            }
            return null;
        }
    }
}
