using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Finale.Forms.Rooms {
    public partial class RoomSimonSays : RoomBase {
        int blocksX = 160;
        int blocksY = 80;
        int score = 0, level = 3, done=0;

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PictureBox> chosenBoxes = new List<PictureBox>();
        Random rand = new Random();

        Color temp;

        int index = 0;
        int tries = 0;

        int timeLimit = 0;
        bool selectingColors = false;
        string correctOrder = string.Empty;
        string playerOrder = string.Empty;

        public RoomSimonSays() {
            InitializeComponent();
            SetUpBlocks();
            Resize += new EventHandler(RoomSimonSays_Resize);
            CenterElements();
            help_str = "Click on the boxes in the same order as they light up!\n you need to pass 3 levels in order to WIN!";
        }

        private void GameTimerEvent(object sender, EventArgs e) {
            if (this.selectingColors) {
                this.timeLimit++;

                switch (this.timeLimit) {
                    case 10:
                        this.temp = this.chosenBoxes[this.index].BackColor;
                        this.chosenBoxes[this.index].BackColor = Color.White;
                        break;
                    case 20:
                        this.chosenBoxes[this.index].BackColor = this.temp;
                        break;
                    case 30:
                        this.chosenBoxes[this.index].BackColor = Color.White;
                        break;
                    case 40:
                        this.chosenBoxes[this.index].BackColor = this.temp;
                        break;
                    case 50:
                        if (this.index < this.chosenBoxes.Count - 1) {
                            this.index++;
                            this.timeLimit = 0;
                        }
                        else {
                            this.selectingColors = false;
                        }
                        break;
                }
            }
            if (this.tries >= this.level) {
                if (this.correctOrder == this.playerOrder) {
                    this.tries = 0;
                    this.game_timer.Stop();
                    MessageBox.Show("Well Done! you got it right! LEVEL UP!");
                    this.done++;
                    this.score++;
                    if (this.done == 3) {
                        MessageBox.Show("Well Done! you finished the game!");
                        DialogResult = DialogResult.Yes;
                        Close();
                    }
                }
                else {
                    this.tries = 0;
                    this.game_timer.Stop();
                    MessageBox.Show("Sorry, you got it wrong!");
                    DialogResult = DialogResult.No;
                    Close();
                }

            }
            this.lbl.Text = "Click on " + this.level + " boxes in the same order";
        }

        private void ButtonClickEvent(object sender, EventArgs e) {
            if (this.score == 1 && this.level < 5) {
                this.level++;
                this.score = 0;
            }

            this.correctOrder = string.Empty;
            this.playerOrder = string.Empty;
            this.chosenBoxes.Clear();
            this.chosenBoxes = this.pictureBoxes.OrderBy(x => this.rand.Next()).Take(this.level).ToList();

            for (int i = 0; i < this.chosenBoxes.Count; i++) {
                this.correctOrder += this.chosenBoxes[i].Name + " ";
            }

            foreach (PictureBox pic in this.pictureBoxes) {
                pic.BackColor = Color.FromArgb(this.rand.Next(256), this.rand.Next(256), this.rand.Next(256));
            }

            this.index = 0;
            this.timeLimit = 0;
            this.selectingColors = true;
            this.game_timer.Start();
        }

        private void SetUpBlocks() {
            int gridWidth = 4 * 60 + 3 * 5;
            int gridHeight = 4 * 60 + 3 * 5;

            this.blocksX = (ClientSize.Width - gridWidth) / 2;
            this.blocksY = (ClientSize.Height - gridHeight) / 2;

            for (int i = 1; i <= 16; i++) {
                PictureBox newPic = new PictureBox
                {
                    Name = "pic_" + i,
                    Height = 60,
                    Width = 60,
                    BackColor = Color.Black,
                    Left = this.blocksX,
                    Top = this.blocksY
                };
                newPic.Click += ClickOnPictureBox;

                Controls.Add(newPic);
                this.pictureBoxes.Add(newPic);
            }
        }

        private void CenterElements() {
            int gridWidth = 4 * 60 + 3 * 5;
            int gridHeight = 4 * 60 + 3 * 5;

            this.blocksX = (ClientSize.Width - gridWidth) / 2;
            this.blocksY = (ClientSize.Height - gridHeight) / 2;

            for (int i = 0; i < this.pictureBoxes.Count; i++) {
                this.pictureBoxes[i].Left = this.blocksX + (i % 4) * 65;
                this.pictureBoxes[i].Top = this.blocksY + (i / 4) * 65;
            }

            this.simon_start_btn.Location = new Point((ClientSize.Width - this.simon_start_btn.Width) / 2,
                this.blocksY + gridHeight + 50);

            this.lbl.Location = new Point(((ClientSize.Width) / 2) - 150,
                this.simon_start_btn.Top - 30);
        }

        private void RoomSimonSays_Resize(object sender, EventArgs e) {
            CenterElements();
        }

        private void ClickOnPictureBox(object sender, EventArgs e) {
            if (!this.selectingColors && this.chosenBoxes.Count > 1) {
                PictureBox temp = sender as PictureBox;
                temp.BackColor = Color.Black;
                this.playerOrder += temp.Name + " ";
                this.tries++;
            }
        }
    }
}
