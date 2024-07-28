using System.Drawing;
using System.Windows.Forms;

namespace Finale.Forms {
    public class FormBase : Form {
        protected string help_str = "";
        public FormBase() {

            BackColor = ColorTranslator.FromHtml("#D8DDEF");
            FormBorderStyle = FormBorderStyle.None;
            Size = Screen.PrimaryScreen.Bounds.Size;
            WindowState = FormWindowState.Maximized;
            KeyPreview = true;

            Shown += (sender, e) => {
                System.Threading.Thread.Sleep(500);
                if (this.help_str != "")
                    MessageBox.Show(this.help_str);
            };
            KeyDown += OnKeyDown;
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
