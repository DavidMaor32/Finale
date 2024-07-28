using System.Drawing;
using System.Windows.Forms;

using Finale.Wordle;

namespace Finale.UserControls {
    public partial class ViewerLetter : UserControl {

        private Label lbl_char;

        public char Character {
            get {
                return this.lbl_char.Text[0];
            }
            set {
                this.lbl_char.Text = value.ToString();
            }
        }
        public ViewerLetter() {
            InitializeComponent();
            this.lbl_char = new Label();
            this.lbl_char.AutoSize = false;
            this.lbl_char.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lbl_char.TextAlign = ContentAlignment.MiddleCenter;
            this.lbl_char.Height = this.lbl_char.Font.Height;
            this.lbl_char.Width = this.lbl_char.Font.Height;
            this.lbl_char.Name = "lbl_char";
            this.lbl_char.Padding = new Padding(4, 0, 4, 0);
            this.lbl_char.Text = "_";
            this.lbl_char.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(this.lbl_char);

        }
        public void SetColor(ResultWordle result) {
            switch (result) {
                case ResultWordle.Match:
                    this.lbl_char.BackColor = Color.Green;
                    break;
                case ResultWordle.Misplace:
                    this.lbl_char.BackColor = Color.Gold;
                    break;
                case ResultWordle.Wrong:
                    this.lbl_char.BackColor = Color.DarkGray;
                    break;
            }
            this.lbl_char.ForeColor = Color.White;
        }
    }
}
