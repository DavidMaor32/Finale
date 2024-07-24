using System.Windows.Forms;

using Finale.Forms.Rooms;

namespace Finale.Forms {
    public partial class FormMain : Form {
        private RoomBase room;
        private RoomBase[] rooms;

        public FormMain() {
            InitializeComponent();

            RoomBase[] rms = { new RoomWordle() };
            this.rooms = rms;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            Button btn_wordle = new Button();
            btn_wordle.Text = "Wordle";
            btn_wordle.Click += (sender, e) => this.room = new RoomWordle();
            Controls.Add(btn_wordle);


            Button btn_math = new Button();
            btn_math.Location = new System.Drawing.Point(btn_wordle.Width, 0);
            btn_math.Text = "Math";
            btn_math.Click += (sender, e) => this.room = new RoomQuickMath();
            Controls.Add(btn_math);


            Button btn_start = new Button();
            btn_start.Location = new System.Drawing.Point(Width / 2 - btn_start.Width / 2, Height - btn_start.Height);
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

            KeyPreview = true;
            KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Escape)
                    Close();
            };
        }

        private void HandleResult(DialogResult result) {
            string s="";
            switch (result) {
                case DialogResult.Yes:
                    s = "you won here";
                    break;
                case DialogResult.No:
                    s = "you lost here";
                    break;

            }
            //MessageBox.Show(s);
        }

    }
}
