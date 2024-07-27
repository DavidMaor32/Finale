using System.Drawing;
using System.Windows.Forms;

using Finale.Components;
using Finale.Helpers;
using Finale.Models;

namespace Finale.Forms {
    public partial class Entry : FormBase {
        public Entry() {
            InitializeComponent();

            this.BackColor = ColorTranslator.FromHtml("#D8DDEF");

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            menu_panel.Height = (int)(this.Height * 0.8);
            menu_panel.Width = (int)(this.Width * 0.3);

            this.menu_panel.Location = new System.Drawing.Point(Width / 2 - this.menu_panel.Width / 2, Height / 2 - this.menu_panel.Height / 2);
            this.lbl_title.Location = new System.Drawing.Point(this.menu_panel.Width / 2 - this.lbl_title.Width / 2,
                this.menu_panel.Top + 10);
            this.intro_label.Location = new System.Drawing.Point(this.menu_panel.Width / 2 - this.intro_label.Width / 2,
                this.lbl_title.Bottom + 70);
            this.btn_start.Location = new System.Drawing.Point(this.menu_panel.Width / 2 - this.btn_start.Width / 2,
                this.intro_label.Bottom + 70);
            this.btn_quit.Location = new System.Drawing.Point(this.menu_panel.Width / 2 - this.btn_quit.Width / 2,
                this.btn_start.Bottom + 250);


        }

        private void btn_start_Click(object sender, System.EventArgs e) {
            string path;
            DialogResult result = SavedGamesPicker.Show(out path);
            if (result == DialogResult.Cancel)
                return;
            Data data = Data.Instance();
            try {
                RecordData rec= FileHelper.LoadGame(path);
                data.Update(rec);
                ShowInTaskbar = false;
                new FormMain(path).ShowDialog();
                ShowInTaskbar = true;
            }
            catch (System.Exception err) {
                MessageBox.Show(err.ToString() + "" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_quit_Click(object sender, System.EventArgs e) {
            Application.Exit();
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {
            if (e.Handled)
                return;
            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            base.OnKeyDown(sender, e);
            e.Handled = true;
        }

        private void Entry_Load(object sender, System.EventArgs e)
        {

        }
    }
}
