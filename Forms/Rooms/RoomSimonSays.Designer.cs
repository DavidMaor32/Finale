using System;

namespace Finale.Forms.Rooms
{
    partial class RoomSimonSays
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simon_start_btn = new System.Windows.Forms.Button();
            this.game_timer = new System.Windows.Forms.Timer(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simon_start_btn
            // 
            this.simon_start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simon_start_btn.Location = new System.Drawing.Point(353, 374);
            this.simon_start_btn.Name = "simon_start_btn";
            this.simon_start_btn.Size = new System.Drawing.Size(91, 51);
            this.simon_start_btn.TabIndex = 0;
            this.simon_start_btn.Text = "Start";
            this.simon_start_btn.UseVisualStyleBackColor = true;
            this.simon_start_btn.Click += new System.EventHandler(this.ButtonClickEvent);
            // 
            // game_timer
            // 
            this.game_timer.Interval = 20;
            this.game_timer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(378, 335);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 24);
            this.lbl.TabIndex = 1;
            this.lbl.Click += new System.EventHandler(this.lbl_Click);
            // 
            // RoomSimonSays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(221)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.simon_start_btn);
            this.Name = "RoomSimonSays";
            this.Text = "RoomSimonSays";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lbl_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button simon_start_btn;
        private System.Windows.Forms.Timer game_timer;
        private System.Windows.Forms.Label lbl;
    }
}