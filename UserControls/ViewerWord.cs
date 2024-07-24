using System.Windows.Forms;

using Finale.Wordle;

namespace Finale.UserControls {
    public partial class ViewerWord : UserControl {
        private string word;
        private FlowLayoutPanel letters;
        public ViewerWord() {
            InitializeComponent();

            this.letters = new FlowLayoutPanel();
            this.letters.FlowDirection = FlowDirection.LeftToRight;
            this.letters.AutoSize = true;
            for (int i = 0; i < Wordle.Wordle.WORD_LENGTH; i++) {
                this.letters.Controls.Add(new ViewerLetter());
            }
            this.letters.Height = this.letters.Controls[0].Height;
            Controls.Add(this.letters);
        }

        public void SetWord(string word) {
            this.word = word;
            int i;
            for (i = 0; i < word.Length; i++) {
                ((ViewerLetter)this.letters.Controls[i]).Character = word[i];
            }
            for (; i < this.letters.Controls.Count; i++)
                ((ViewerLetter)this.letters.Controls[i]).Character = '_';
        }

        public void SetColor(ResultWordle[] res) {
            for (int i = 0; i < this.letters.Controls.Count; i++) {
                ((ViewerLetter)this.letters.Controls[i]).SetColor(res[i]);
            }
        }

        public void Reset() {
            for (int i = 0; i < this.letters.Controls.Count; i++) {
                ((ViewerLetter)this.letters.Controls[i]).Reset();
            }
        }
    }
}
