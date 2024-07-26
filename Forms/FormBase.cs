using System.Windows.Forms;

namespace Finale.Forms {
    public abstract class FormBase : Form {
        protected string help_str = "help.";
        public FormBase() {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Size = Screen.PrimaryScreen.Bounds.Size;
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            //AutoSize = false;
            KeyPreview = true;
        }

        protected virtual void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;

            if (e.KeyCode == Keys.OemQuestion) {
                MessageBox.Show(this.help_str, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            e.Handled = true;
        }
    }
}
