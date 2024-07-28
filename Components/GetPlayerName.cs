using System.Drawing;
using System.Windows.Forms;

namespace Finale.Components {
    public partial class GetPlayerName : Form {
        string name;
        private GetPlayerName() {
            InitializeComponent();

            this.name = "";
            this.lbl_empty_name.Visible = false;
            foreach (Control c in Controls) {
                c.Location = new Point(Width / 2 - c.Width / 2, c.Location.Y);
            }
        }

        private void input_name_TextChanged(object sender, System.EventArgs e) {
            if (this.input_name.Text.Length == 0) {
                return;
            }
            this.lbl_empty_name.Visible = false;
            if (char.IsLetterOrDigit(this.input_name.Text[this.input_name.Text.Length - 1]))
                this.name = this.input_name.Text;
            else {
                this.input_name.Text = this.name;
                this.input_name.Select(this.input_name.Text.Length, 0);
            }

        }

        private void button1_Click(object sender, System.EventArgs e) {
            if (this.input_name.Text.Length == 0) {
                this.lbl_empty_name.Visible = true;
                return;
            }
            DialogResult = DialogResult.OK;
            this.name = this.input_name.Text;
            Close();
        }

        private void btn_leave_Click(object sender, System.EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static DialogResult ShowDialog(out string name) {
            GetPlayerName form = new GetPlayerName();
            var result = form.ShowDialog();
            name = form.name;
            return result;
        }
    }
}
