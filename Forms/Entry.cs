using System.Windows.Forms;

using Finale.Components;
using Finale.Helpers;
using Finale.Models;

namespace Finale.Forms {
    public partial class Entry : FormBase {
        public Entry() {
            InitializeComponent();
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            this.lbl_title.Location = new System.Drawing.Point(Width / 2 - this.lbl_title.Width / 2, Height / 2 - this.lbl_title.Height / 2);
            this.btn_quit.Location = new System.Drawing.Point(Width / 2 - this.btn_quit.Width / 2, Height / 2 - this.btn_quit.Height / 2 + 50);
            this.btn_start.Location = new System.Drawing.Point(Width / 2 - this.btn_start.Width / 2, Height / 2 - this.btn_start.Height / 2 - 50);
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
                new FormMain(path).Show();
            }
            catch (System.Exception err) {
                MessageBox.Show(err.ToString() + "" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_quit_Click(object sender, System.EventArgs e) {
            Application.Exit();
        }

        protected override void OnKeyDown(object sender, KeyEventArgs e) {

        }
    }
}
