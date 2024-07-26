using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Finale.Values;


namespace Finale.Components {
    public partial class SavedGamesPicker : Form {
        private string selectedSave;
        private string[] saves;


        private SavedGamesPicker() {
            InitializeComponent();

            foreach (Control control in Controls) {
                if (control is TextBox)
                    continue;
                control.Text = "&" + control.Text;
            }
        }

        private void SavedGamesPicker_Load(object sender, EventArgs e) {
            string savedGamesPath = Paths.s_games;

            if (!Directory.Exists(savedGamesPath)) {
                Directory.CreateDirectory(savedGamesPath);
            }

            this.saves = Directory.GetFiles(savedGamesPath, "*.game");

            this.saves = Array.ConvertAll(this.saves, (save) => Path.GetFileNameWithoutExtension(save));

            this.lb_saves.Items.AddRange(this.saves);

            if (this.saves.Length == 0) {
                this.rb_new_file.Checked = true;
                this.rb_select.Enabled = false;
            }
        }
        private void rb_select_CheckedChanged(object sender, EventArgs e) {
            if (this.saves.Length == 0) {
                return;
            }


            this.lb_saves.Enabled = this.rb_select.Checked;

            this.lb_saves.ClearSelected();
            this.btn_ok.Enabled = false;
        }

        private void lb_saves_SelectedIndexChanged(object sender, EventArgs e) {
            this.btn_ok.Enabled = this.lb_saves.SelectedIndex != -1;

            if (!this.btn_ok.Enabled) {
                return;
            }

            this.selectedSave = this.lb_saves.SelectedItem.ToString();
        }

        private void tb_new_file_KeyPress(object sender, KeyPressEventArgs e) {
            Regex regex = new Regex(@"[a-zA-Z0-9_-]");

            e.Handled = !regex.IsMatch("" + e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void rb_new_file_CheckedChanged(object sender, EventArgs e) {
            this.tb_new_file.Enabled = this.rb_new_file.Checked;

        }

        private void tb_new_file_TextChanged(object sender, EventArgs e) {
            this.lb_name_exists.Visible = false;
            this.btn_ok.Enabled = this.tb_new_file.Text.Length > 0;
            this.selectedSave = this.tb_new_file.Text;
        }

        private void btn_ok_Click(object sender, EventArgs e) {
            if (!this.rb_new_file.Checked) {
                DialogResult = DialogResult.OK;
                return;
            }

            foreach (string save in this.saves) {
                if (save == this.selectedSave) {
                    this.lb_name_exists.Visible = true;
                    this.btn_ok.Enabled = false;
                    DialogResult = DialogResult.None;
                }
            }

        }
        /// <summary>
        /// Displays a dialog to select a saved game file and returns the path of the selected file
        /// </summary>
        /// <param name="savePath">gets the selected path if return DialogResult.OK. else, gets empty string.</param>
        /// <returns>DialogResult.OK if confirmed the selected save. else, returnDialogResult.Cancel</returns>
        public static DialogResult Show(out string savePath) {
            SavedGamesPicker picker = new SavedGamesPicker();
            DialogResult result = picker.ShowDialog();

            switch (result) {
                case DialogResult.OK:
                    savePath = picker.selectedSave;
                    break;
                case DialogResult.Cancel:
                    savePath = "";
                    break;
                default:
                    savePath = null;
                    break;

            }

            savePath = Path.Combine(Paths.s_games, savePath + ".game");

            return result;
        }


    }
}
