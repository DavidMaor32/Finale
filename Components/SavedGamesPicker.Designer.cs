namespace Finale.Components {
    partial class SavedGamesPicker {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.rb_select = new System.Windows.Forms.RadioButton();
            this.rb_new_file = new System.Windows.Forms.RadioButton();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lb_saves = new System.Windows.Forms.ListBox();
            this.tb_new_file = new System.Windows.Forms.TextBox();
            this.lb_name_exists = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rb_select
            // 
            this.rb_select.AutoSize = true;
            this.rb_select.Location = new System.Drawing.Point(4, 26);
            this.rb_select.Name = "rb_select";
            this.rb_select.Size = new System.Drawing.Size(55, 17);
            this.rb_select.TabIndex = 0;
            this.rb_select.TabStop = true;
            this.rb_select.Text = "Select";
            this.rb_select.UseVisualStyleBackColor = true;
            this.rb_select.CheckedChanged += new System.EventHandler(this.rb_select_CheckedChanged);
            // 
            // rb_new_file
            // 
            this.rb_new_file.AutoSize = true;
            this.rb_new_file.Checked = true;
            this.rb_new_file.Location = new System.Drawing.Point(4, 3);
            this.rb_new_file.Name = "rb_new_file";
            this.rb_new_file.Size = new System.Drawing.Size(66, 17);
            this.rb_new_file.TabIndex = 1;
            this.rb_new_file.TabStop = true;
            this.rb_new_file.Text = "New File";
            this.rb_new_file.UseVisualStyleBackColor = true;
            this.rb_new_file.CheckedChanged += new System.EventHandler(this.rb_new_file_CheckedChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Enabled = false;
            this.btn_ok.Location = new System.Drawing.Point(24, 171);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(160, 171);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // lb_saves
            // 
            this.lb_saves.Enabled = false;
            this.lb_saves.FormattingEnabled = true;
            this.lb_saves.Location = new System.Drawing.Point(24, 49);
            this.lb_saves.Name = "lb_saves";
            this.lb_saves.Size = new System.Drawing.Size(217, 95);
            this.lb_saves.Sorted = true;
            this.lb_saves.TabIndex = 4;
            this.lb_saves.SelectedIndexChanged += new System.EventHandler(this.lb_saves_SelectedIndexChanged);
            // 
            // tb_new_file
            // 
            this.tb_new_file.Location = new System.Drawing.Point(76, 3);
            this.tb_new_file.MaxLength = 25;
            this.tb_new_file.Name = "tb_new_file";
            this.tb_new_file.Size = new System.Drawing.Size(165, 20);
            this.tb_new_file.TabIndex = 5;
            this.tb_new_file.TextChanged += new System.EventHandler(this.tb_new_file_TextChanged);
            this.tb_new_file.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_new_file_KeyPress);
            // 
            // lb_name_exists
            // 
            this.lb_name_exists.AutoSize = true;
            this.lb_name_exists.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name_exists.ForeColor = System.Drawing.Color.Red;
            this.lb_name_exists.Location = new System.Drawing.Point(73, 26);
            this.lb_name_exists.Name = "lb_name_exists";
            this.lb_name_exists.Size = new System.Drawing.Size(171, 13);
            this.lb_name_exists.TabIndex = 6;
            this.lb_name_exists.Text = "NAME IS ALREADY EXISTS!";
            this.lb_name_exists.Visible = false;
            // 
            // SavedGamesPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 206);
            this.Controls.Add(this.lb_name_exists);
            this.Controls.Add(this.tb_new_file);
            this.Controls.Add(this.lb_saves);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.rb_new_file);
            this.Controls.Add(this.rb_select);
            this.Name = "SavedGamesPicker";
            this.ShowIcon = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SavedGamesPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_select;
        private System.Windows.Forms.RadioButton rb_new_file;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ListBox lb_saves;
        private System.Windows.Forms.TextBox tb_new_file;
        private System.Windows.Forms.Label lb_name_exists;
    }
}
