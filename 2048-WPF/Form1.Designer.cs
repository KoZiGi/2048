
namespace _2048_WPF
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
            this.UpBtn = new System.Windows.Forms.Button();
            this.SwitchToKbdBtn = new System.Windows.Forms.Button();
            this.DownBtn = new System.Windows.Forms.Button();
            this.RightBtn = new System.Windows.Forms.Button();
            this.LeftBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // UpBtn
            // 
            this.UpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpBtn.Location = new System.Drawing.Point(101, 268);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(40, 40);
            this.UpBtn.TabIndex = 1;
            this.UpBtn.Text = "Fel";
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // SwitchToKbdBtn
            // 
            this.SwitchToKbdBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchToKbdBtn.Location = new System.Drawing.Point(101, 314);
            this.SwitchToKbdBtn.Name = "SwitchToKbdBtn";
            this.SwitchToKbdBtn.Size = new System.Drawing.Size(40, 40);
            this.SwitchToKbdBtn.TabIndex = 1;
            this.SwitchToKbdBtn.UseVisualStyleBackColor = true;
            this.SwitchToKbdBtn.Click += new System.EventHandler(this.SwitchToKbdBtn_Click);
            this.SwitchToKbdBtn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SwitchToKbdBtn_KeyPress);
            // 
            // DownBtn
            // 
            this.DownBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownBtn.Location = new System.Drawing.Point(101, 360);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(40, 40);
            this.DownBtn.TabIndex = 1;
            this.DownBtn.Text = "Le";
            this.DownBtn.UseVisualStyleBackColor = true;
            this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
            // 
            // RightBtn
            // 
            this.RightBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightBtn.Location = new System.Drawing.Point(147, 314);
            this.RightBtn.Name = "RightBtn";
            this.RightBtn.Size = new System.Drawing.Size(40, 40);
            this.RightBtn.TabIndex = 1;
            this.RightBtn.Text = "Jobb";
            this.RightBtn.UseVisualStyleBackColor = true;
            this.RightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            // 
            // LeftBtn
            // 
            this.LeftBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftBtn.Location = new System.Drawing.Point(55, 314);
            this.LeftBtn.Name = "LeftBtn";
            this.LeftBtn.Size = new System.Drawing.Size(40, 40);
            this.LeftBtn.TabIndex = 1;
            this.LeftBtn.Text = "Bal";
            this.LeftBtn.UseVisualStyleBackColor = true;
            this.LeftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "GEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(25, 380);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 20);
            this.numericUpDown1.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 442);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LeftBtn);
            this.Controls.Add(this.RightBtn);
            this.Controls.Add(this.DownBtn);
            this.Controls.Add(this.SwitchToKbdBtn);
            this.Controls.Add(this.UpBtn);
            this.Name = "Form1";
            this.Text = "2048";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button SwitchToKbdBtn;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Button RightBtn;
        private System.Windows.Forms.Button LeftBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

