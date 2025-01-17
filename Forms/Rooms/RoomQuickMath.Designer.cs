﻿namespace Finale.Forms.Rooms {
    partial class RoomQuickMath {
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
            this.components = new System.ComponentModel.Container();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_operand_1 = new System.Windows.Forms.Label();
            this.lbl_operand_2 = new System.Windows.Forms.Label();
            this.lbl_operator = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input_ans = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(328, 24);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(103, 29);
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "TIME:10";
            // 
            // lbl_operand_1
            // 
            this.lbl_operand_1.AutoSize = true;
            this.lbl_operand_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_operand_1.Location = new System.Drawing.Point(8, 8);
            this.lbl_operand_1.Name = "lbl_operand_1";
            this.lbl_operand_1.Size = new System.Drawing.Size(94, 52);
            this.lbl_operand_1.TabIndex = 1;
            this.lbl_operand_1.Text = "234";
            // 
            // lbl_operand_2
            // 
            this.lbl_operand_2.AutoSize = true;
            this.lbl_operand_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_operand_2.Location = new System.Drawing.Point(216, 8);
            this.lbl_operand_2.Name = "lbl_operand_2";
            this.lbl_operand_2.Size = new System.Drawing.Size(94, 52);
            this.lbl_operand_2.TabIndex = 2;
            this.lbl_operand_2.Text = "234";
            // 
            // lbl_operator
            // 
            this.lbl_operator.AutoSize = true;
            this.lbl_operator.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_operator.Location = new System.Drawing.Point(136, 8);
            this.lbl_operator.Name = "lbl_operator";
            this.lbl_operator.Size = new System.Drawing.Size(48, 52);
            this.lbl_operator.TabIndex = 3;
            this.lbl_operator.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "=";
            // 
            // input_ans
            // 
            this.input_ans.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_ans.Location = new System.Drawing.Point(384, 8);
            this.input_ans.Name = "input_ans";
            this.input_ans.Size = new System.Drawing.Size(200, 52);
            this.input_ans.TabIndex = 5;
            this.input_ans.Text = "234";
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.btn_start.Location = new System.Drawing.Point(256, 224);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(240, 96);
            this.btn_start.TabIndex = 6;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.input_ans);
            this.panel1.Controls.Add(this.lbl_operand_1);
            this.panel1.Controls.Add(this.lbl_operand_2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_operator);
            this.panel1.Location = new System.Drawing.Point(56, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 56);
            this.panel1.TabIndex = 7;
            // 
            // RoomQuickMath
            // this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lbl_time);
            this.Name = "RoomQuickMath";
            this.Text = "RoomQuickMath";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_operand_1;
        private System.Windows.Forms.Label lbl_operand_2;
        private System.Windows.Forms.Label lbl_operator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label input_ans;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
    }
}