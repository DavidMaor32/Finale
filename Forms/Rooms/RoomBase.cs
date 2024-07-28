using System.Windows.Forms;

namespace Finale.Forms.Rooms {
    public class RoomBase : FormBase {
        public RoomBase() {
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

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
                default:
                    base.OnKeyDown(sender, e);
                    break;
            }
            e.Handled = true;
        }
    }
}
