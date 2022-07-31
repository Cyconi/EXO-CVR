namespace EXO_CVR.FishsCumCorner.Forms
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PlayerList = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.UserIDlb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(251, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kick";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(494, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Log Packet Info";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PlayerList
            // 
            this.PlayerList.FormattingEnabled = true;
            this.PlayerList.Location = new System.Drawing.Point(12, 13);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(229, 21);
            this.PlayerList.TabIndex = 3;
            this.PlayerList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(251, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(251, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 26);
            this.button3.TabIndex = 5;
            this.button3.Text = "Lag";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // UserIDlb
            // 
            this.UserIDlb.AutoSize = true;
            this.UserIDlb.ForeColor = System.Drawing.Color.White;
            this.UserIDlb.Location = new System.Drawing.Point(55, 115);
            this.UserIDlb.Name = "UserIDlb";
            this.UserIDlb.Size = new System.Drawing.Size(16, 13);
            this.UserIDlb.TabIndex = 6;
            this.UserIDlb.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "UserID";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(608, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserIDlb);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PlayerList);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "EXO";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox PlayerList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label UserIDlb;
        private System.Windows.Forms.Label label1;
    }
}