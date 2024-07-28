namespace Finale.Forms {
    partial class Entry {
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
            this.menu_panel = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_quit = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.intro_label = new System.Windows.Forms.Label();
            this.menu_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_panel
            // 
            this.menu_panel.BackgroundImage = global::Finale.Properties.Resources.image;
            this.menu_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menu_panel.Controls.Add(this.lbl_title);
            this.menu_panel.Controls.Add(this.btn_quit);
            this.menu_panel.Controls.Add(this.btn_start);
            this.menu_panel.Controls.Add(this.intro_label);
            this.menu_panel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.menu_panel.Location = new System.Drawing.Point(343, 26);
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(409, 608);
            this.menu_panel.TabIndex = 4;
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(38, 77);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(333, 36);
            this.lbl_title.TabIndex = 12;
            this.lbl_title.Text = "Mini-Games Maze";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_quit
            // 
            this.btn_quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.btn_quit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quit.Location = new System.Drawing.Point(130, 480);
            this.btn_quit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(155, 74);
            this.btn_quit.TabIndex = 10;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = false;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.btn_start.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(130, 389);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(155, 74);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // intro_label
            // 
            this.intro_label.BackColor = System.Drawing.Color.Transparent;
            this.intro_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intro_label.Location = new System.Drawing.Point(61, 194);
            this.intro_label.Name = "intro_label";
            this.intro_label.Size = new System.Drawing.Size(310, 99);
            this.intro_label.TabIndex = 13;
            this.intro_label.Text = "Welcome to The Mini-Games Maze!\r\nPress start to start a new game or continue a pr" +
    "evious one.";
            this.intro_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(221)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1096, 776);
            this.Controls.Add(this.menu_panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Entry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry";
            this.menu_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel menu_panel;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label intro_label;
    }
}