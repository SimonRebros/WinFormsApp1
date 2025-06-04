namespace WinFormsApp1
{
    partial class Form6
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
            pictureBox1 = new PictureBox();
            bullettemp = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            exit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bullettemp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.spaceship;
            pictureBox1.Location = new Point(322, 711);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // bullettemp
            // 
            bullettemp.BackColor = Color.DarkSlateGray;
            bullettemp.Location = new Point(356, 690);
            bullettemp.Name = "bullettemp";
            bullettemp.Size = new Size(5, 15);
            bullettemp.TabIndex = 5;
            bullettemp.TabStop = false;
            bullettemp.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.enemy_1;
            pictureBox2.Location = new Point(292, 58);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(103, 106);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(78, 473);
            label1.Name = "label1";
            label1.Size = new Size(91, 38);
            label1.TabIndex = 7;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exit
            // 
            exit.BackColor = Color.RosyBrown;
            exit.Location = new Point(697, 12);
            exit.Name = "exit";
            exit.Size = new Size(43, 29);
            exit.TabIndex = 8;
            exit.Text = "<--";
            exit.UseVisualStyleBackColor = false;
            exit.Visible = false;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 803);
            Controls.Add(exit);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(bullettemp);
            Controls.Add(pictureBox1);
            Name = "Form6";
            Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bullettemp).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox bullettemp;
        private PictureBox pictureBox2;
        private Label label1;
        private Button exit;
    }
}