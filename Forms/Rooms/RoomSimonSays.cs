using System.Drawing;
using System.Windows.Forms;

using Finale.Simon;

namespace Finale.Forms.Rooms {
    public partial class RoomSimonSays : RoomBase {
        private static readonly int     ms =            1000;

        private static readonly Color   DARK_BLUE =     Color.DarkBlue;
        private static readonly Color   LIGHT_BLUE =    Color.Blue;

        private static readonly Color   DARK_YELLOW =   Color.Gold;
        private static readonly Color   LIGHT_YELLOW =  Color.Yellow;

        private static readonly Color   DARK_RED =      Color.DarkRed;
        private static readonly Color   LIGHT_RED =     Color.Red;

        private static readonly Color   DARK_GREEN =    Color.DarkGreen;
        private static readonly Color   LIGHT_GREEN =   Color.Green;

        private SimonSays   controller;
        public RoomSimonSays() {
            InitializeComponent();


            this.controller = new SimonSays();

            this.btn_blue.BackColor = DARK_BLUE;
            this.btn_yellow.BackColor = DARK_YELLOW;
            this.btn_red.BackColor = DARK_RED;
            this.btn_green.BackColor = DARK_GREEN;

            int size = (int)(Width * 0.2);

            this.btn_blue.Size = new Size(size, size);
            this.btn_yellow.Size = new Size(size, size);
            this.btn_red.Size = new Size(size, size);
            this.btn_green.Size = new Size(size, size);

            this.btn_green.Location = new Point(Width - size * 2, Height - size * 2);
            this.btn_red.Location = new Point(Width - size * 2, Height - size);
            this.btn_yellow.Location = new Point(Width - size, Height - size * 2);
            this.btn_blue.Location = new Point(Width - size, Height - size);
            Refresh();

        }
        private void Guess(ColorSimon color) {
            ResultSimon res = this.controller.Guess(color);
            switch (res) {
                case ResultSimon.Empty:
                    this.controller.NextRound();
                    ShowColors();
                    break;
                case ResultSimon.Correct:
                    if (!this.controller.EndOfRound())
                        break;
                    this.controller.NextRound();
                    ShowColors();
                    break;
                case ResultSimon.Wrong:
                    MessageBox.Show("You lose!");

                    break;
            }
        }
        private void ShowColors() {
            IsEnabled(false);
            this.controller.ShowColors(glow);
            IsEnabled(true);
        }
        private void glow(ColorSimon color) {
            Button btn = null;
            Color color_dark = default, color_light = default;
            switch (color) {
                case ColorSimon.Yellow:
                    btn = this.btn_yellow;
                    color_dark = DARK_YELLOW;
                    color_light = LIGHT_YELLOW;
                    break;
                case ColorSimon.Blue:
                    btn = this.btn_blue;
                    color_dark = DARK_BLUE;
                    color_light = LIGHT_BLUE;
                    break;
                case ColorSimon.Red:
                    btn = this.btn_red;
                    color_dark = DARK_RED;
                    color_light = LIGHT_RED;
                    break;
                case ColorSimon.Green:
                    btn = this.btn_green;
                    color_dark = DARK_GREEN;
                    color_light = LIGHT_GREEN;
                    break;
            }
            btn.BackColor = color_light;
            System.Threading.Thread.Sleep(ms);
            btn.BackColor = color_dark;

        }

        private void IsEnabled(bool flag) {
            this.btn_blue.Enabled = flag;
            this.btn_yellow.Enabled = flag;
            this.btn_red.Enabled = flag;
            this.btn_green.Enabled = flag;
        }

        private void Reset() {
            this.controller.Reset();
            this.lbl_round.Text = this.controller.Round.ToString();
            ShowColors();
        }
        private void btn_green_Click(object sender, System.EventArgs e) {
            Guess(ColorSimon.Green);
            glow(ColorSimon.Green);
        }

        private void btn_red_Click(object sender, System.EventArgs e) {
            Guess(ColorSimon.Red);
            glow(ColorSimon.Red);
        }

        private void btn_yellow_Click(object sender, System.EventArgs e) {
            Guess(ColorSimon.Yellow);
            glow(ColorSimon.Yellow);
        }

        private void btn_blue_Click(object sender, System.EventArgs e) {
            Guess(ColorSimon.Blue);
            glow(ColorSimon.Blue);
        }

        private void btn_start_Click(object sender, System.EventArgs e) {
            this.controller.Reset();
            ShowColors();
        }

        protected void RoomSimonSays_KeyDown(object sender, KeyEventArgs e) {
            OnKeyDown(sender, e);
            MessageBox.Show("simon Key pressed" + e.ToString());
        }

        private void btn_next_Click(object sender, System.EventArgs e) {
            this.controller.NextRound();
            ShowColors();
        }
    }
}
