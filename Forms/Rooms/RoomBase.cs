using System.Windows.Forms;

using Finale.Enums;

namespace Finale.Forms.Rooms {
    public abstract class RoomBase : FormBase {
        protected ResultRoom Result = ResultRoom.None;
        public RoomBase() {
            /*Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;*/

            ShowInTaskbar = false;
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {
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
            e.Handled = true;
        }
    }
}
