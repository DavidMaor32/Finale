namespace Finale.Components {
    partial class GetPlayerName {
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
            this.label1 = new System.Windows.Forms.Label();
            this.input_name = new System.Windows.Forms.TextBox();
            this.btn_leave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_empty_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Before we start, WHO ARE YOU??";
            // 
            // input_name
            // 
            this.input_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.input_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_name.Location = new System.Drawing.Point(136, 56);
            this.input_name.MaxLength = 25;
            this.input_name.Name = "input_name";
            this.input_name.Size = new System.Drawing.Size(160, 22);
            this.input_name.TabIndex = 1;
            this.input_name.Text = "Lord Farty Smelly the 2nd";
            this.input_name.TextChanged += new System.EventHandler(this.input_name_TextChanged);
            // 
            // btn_leave
            // 
            this.btn_leave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_leave.Location = new System.Drawing.Point(128, 224);
            this.btn_leave.Name = "btn_leave";
            this.btn_leave.Size = new System.Drawing.Size(184, 32);
            this.btn_leave.TabIndex = 2;
            this.btn_leave.Text = "I\'m not ready for commitment yet...";
            this.btn_leave.UseVisualStyleBackColor = true;
            this.btn_leave.Click += new System.EventHandler(this.btn_leave_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(144, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "START THE JOURNY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_empty_name
            // 
            this.lbl_empty_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_empty_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_empty_name.ForeColor = System.Drawing.Color.Red;
            this.lbl_empty_name.Location = new System.Drawing.Point(0, 88);
            this.lbl_empty_name.Name = "lbl_empty_name";
            this.lbl_empty_name.Size = new System.Drawing.Size(440, 48);
            this.lbl_empty_name.TabIndex = 4;
            this.lbl_empty_name.Text = "surely you have a name, forgot your nam? look at you ID maybe...";
            // 
            // GetPlayerName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(221)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(444, 262);
            this.Controls.Add(this.lbl_empty_name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_leave);
            this.Controls.Add(this.input_name);
            this.Controls.Add(this.label1);
            this.Name = "GetPlayerName";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_name;
        private System.Windows.Forms.Button btn_leave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_empty_name;
    }
}