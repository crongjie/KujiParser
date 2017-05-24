namespace KujiParser
{
    partial class Form1
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
            this.btn_open = new System.Windows.Forms.Button();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.btn_process = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.btn_process2 = new System.Windows.Forms.Button();
            this.tb_file2 = new System.Windows.Forms.TextBox();
            this.btn_open2 = new System.Windows.Forms.Button();
            this.btn_process3 = new System.Windows.Forms.Button();
            this.btn_process4 = new System.Windows.Forms.Button();
            this.cb_csv = new System.Windows.Forms.CheckBox();
            this.btn_process_save = new System.Windows.Forms.Button();
            this.btn_process5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(12, 12);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(161, 31);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "Open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // tb_output
            // 
            this.tb_output.Location = new System.Drawing.Point(16, 85);
            this.tb_output.MaxLength = 3276700;
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_output.Size = new System.Drawing.Size(1028, 396);
            this.tb_output.TabIndex = 1;
            // 
            // btn_process
            // 
            this.btn_process.Location = new System.Drawing.Point(140, 501);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(118, 27);
            this.btn_process.TabIndex = 2;
            this.btn_process.Text = "Process";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(926, 501);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(118, 27);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "kuji100";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.FileName = "output";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // tb_file
            // 
            this.tb_file.Location = new System.Drawing.Point(192, 21);
            this.tb_file.Name = "tb_file";
            this.tb_file.ReadOnly = true;
            this.tb_file.Size = new System.Drawing.Size(556, 19);
            this.tb_file.TabIndex = 4;
            // 
            // btn_process2
            // 
            this.btn_process2.Location = new System.Drawing.Point(16, 501);
            this.btn_process2.Name = "btn_process2";
            this.btn_process2.Size = new System.Drawing.Size(118, 27);
            this.btn_process2.TabIndex = 5;
            this.btn_process2.Text = "Process 2";
            this.btn_process2.UseVisualStyleBackColor = true;
            this.btn_process2.Click += new System.EventHandler(this.btn_process2_Click);
            // 
            // tb_file2
            // 
            this.tb_file2.Location = new System.Drawing.Point(192, 57);
            this.tb_file2.Name = "tb_file2";
            this.tb_file2.ReadOnly = true;
            this.tb_file2.Size = new System.Drawing.Size(556, 19);
            this.tb_file2.TabIndex = 7;
            // 
            // btn_open2
            // 
            this.btn_open2.Location = new System.Drawing.Point(12, 48);
            this.btn_open2.Name = "btn_open2";
            this.btn_open2.Size = new System.Drawing.Size(161, 31);
            this.btn_open2.TabIndex = 6;
            this.btn_open2.Text = "Open";
            this.btn_open2.UseVisualStyleBackColor = true;
            this.btn_open2.Click += new System.EventHandler(this.btn_open2_Click);
            // 
            // btn_process3
            // 
            this.btn_process3.Location = new System.Drawing.Point(264, 501);
            this.btn_process3.Name = "btn_process3";
            this.btn_process3.Size = new System.Drawing.Size(125, 27);
            this.btn_process3.TabIndex = 8;
            this.btn_process3.Text = "2text(type1)";
            this.btn_process3.UseVisualStyleBackColor = true;
            this.btn_process3.Click += new System.EventHandler(this.btn_process3_Click);
            // 
            // btn_process4
            // 
            this.btn_process4.Location = new System.Drawing.Point(395, 501);
            this.btn_process4.Name = "btn_process4";
            this.btn_process4.Size = new System.Drawing.Size(125, 27);
            this.btn_process4.TabIndex = 9;
            this.btn_process4.Text = "2text(hydcd-word)";
            this.btn_process4.UseVisualStyleBackColor = true;
            this.btn_process4.Click += new System.EventHandler(this.btn_process4_Click);
            // 
            // cb_csv
            // 
            this.cb_csv.AutoSize = true;
            this.cb_csv.Location = new System.Drawing.Point(939, 59);
            this.cb_csv.Name = "cb_csv";
            this.cb_csv.Size = new System.Drawing.Size(47, 16);
            this.cb_csv.TabIndex = 10;
            this.cb_csv.Text = "CSV";
            this.cb_csv.UseVisualStyleBackColor = true;
            // 
            // btn_process_save
            // 
            this.btn_process_save.Location = new System.Drawing.Point(789, 501);
            this.btn_process_save.Name = "btn_process_save";
            this.btn_process_save.Size = new System.Drawing.Size(118, 27);
            this.btn_process_save.TabIndex = 11;
            this.btn_process_save.Text = "Process Save";
            this.btn_process_save.UseVisualStyleBackColor = true;
            this.btn_process_save.Click += new System.EventHandler(this.btn_process_save_Click);
            // 
            // btn_process5
            // 
            this.btn_process5.Location = new System.Drawing.Point(526, 501);
            this.btn_process5.Name = "btn_process5";
            this.btn_process5.Size = new System.Drawing.Size(125, 27);
            this.btn_process5.TabIndex = 12;
            this.btn_process5.Text = "2text(sample)";
            this.btn_process5.UseVisualStyleBackColor = true;
            this.btn_process5.Click += new System.EventHandler(this.btn_process5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(657, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "2text(comma)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_process5);
            this.Controls.Add(this.btn_process_save);
            this.Controls.Add(this.cb_csv);
            this.Controls.Add(this.btn_process4);
            this.Controls.Add(this.btn_process3);
            this.Controls.Add(this.tb_file2);
            this.Controls.Add(this.btn_open2);
            this.Controls.Add(this.btn_process2);
            this.Controls.Add(this.tb_file);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.btn_open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.Button btn_process;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.Button btn_process2;
        private System.Windows.Forms.TextBox tb_file2;
        private System.Windows.Forms.Button btn_open2;
        private System.Windows.Forms.Button btn_process3;
        private System.Windows.Forms.Button btn_process4;
        private System.Windows.Forms.CheckBox cb_csv;
        private System.Windows.Forms.Button btn_process_save;
        private System.Windows.Forms.Button btn_process5;
        private System.Windows.Forms.Button button1;
    }
}

