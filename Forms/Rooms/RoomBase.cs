using System.Windows.Forms;

using Finale.Enums;

namespace Finale.Forms.Rooms {
    public partial class RoomBase : Form {
        protected ResultRoom Result = ResultRoom.None;
        public RoomBase() {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            ShowInTaskbar = false;
            KeyPreview = true;
        }

        protected virtual void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)//to avoid bubbling events.
                return;
            switch (e.KeyCode) {
                case Keys.Escape:
                    if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        DialogResult = DialogResult.Abort;
                        Close();
                    }
                    break;
            }
        }
    }
}
