namespace Finale.Forms.Rooms {
    partial class RoomSimonSays {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_blue = new System.Windows.Forms.Button();
            this.btn_red = new System.Windows.Forms.Button();
            this.btn_yellow = new System.Windows.Forms.Button();
            this.btn_green = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_round = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_blue
            // 
            this.btn_blue.Location = new System.Drawing.Point(408, 208);
            this.btn_blue.Name = "btn_blue";
            this.btn_blue.Size = new System.Drawing.Size(150, 150);
            this.btn_blue.TabIndex = 3;
            this.btn_blue.Text = "Blue";
            this.btn_blue.UseVisualStyleBackColor = true;
            this.btn_blue.Click += new System.EventHandler(this.btn_blue_Click);
            // 
            // btn_red
            // 
            this.btn_red.Location = new System.Drawing.Point(408, 48);
            this.btn_red.Name = "btn_red";
            this.btn_red.Size = new System.Drawing.Size(150, 150);
            this.btn_red.TabIndex = 1;
            this.btn_red.Text = "Red";
            this.btn_red.UseVisualStyleBackColor = true;
            this.btn_red.Click += new System.EventHandler(this.btn_red_Click);
            // 
            // btn_yellow
            // 
            this.btn_yellow.Location = new System.Drawing.Point(248, 208);
            this.btn_yellow.Name = "btn_yellow";
            this.btn_yellow.Size = new System.Drawing.Size(150, 150);
            this.btn_yellow.TabIndex = 2;
            this.btn_yellow.Text = "Yellow";
            this.btn_yellow.UseVisualStyleBackColor = true;
            this.btn_yellow.Click += new System.EventHandler(this.btn_yellow_Click);
            // 
            // btn_green
            // 
            this.btn_green.Location = new System.Drawing.Point(248, 48);
            this.btn_green.Name = "btn_green";
            this.btn_green.Size = new System.Drawing.Size(150, 150);
            this.btn_green.TabIndex = 0;
            this.btn_green.Text = "Green";
            this.btn_green.UseVisualStyleBackColor = true;
            this.btn_green.Click += new System.EventHandler(this.btn_green_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(248, 376);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(152, 52);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(408, 376);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(152, 52);
            this.btn_next.TabIndex = 5;
            this.btn_next.Text = "Next Round";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Round:";
            // 
            // lbl_round
            // 
            this.lbl_round.AutoSize = true;
            this.lbl_round.Location = new System.Drawing.Point(80, 24);
            this.lbl_round.Name = "lbl_round";
            this.lbl_round.Size = new System.Drawing.Size(18, 20);
            this.lbl_round.TabIndex = 7;
            this.lbl_round.Text = "1";
            this.lbl_round.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RoomSimonSays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 725);
            this.Controls.Add(this.lbl_round);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_green);
            this.Controls.Add(this.btn_yellow);
            this.Controls.Add(this.btn_red);
            this.Controls.Add(this.btn_blue);
            this.Name = "RoomSimonSays";
            this.Text = "RoomSimonSays";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoomSimonSays_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_blue;
        private System.Windows.Forms.Button btn_red;
        private System.Windows.Forms.Button btn_yellow;
        private System.Windows.Forms.Button btn_green;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_round;
    }
}