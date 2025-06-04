namespace WinFormsApp1
{
    partial class Form2
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
            pictureBox2 = new PictureBox();
            bullettemp = new PictureBox();
            exit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bullettemp).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.spaceship;
            pictureBox1.Location = new Point(330, 720);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.enemy_2;
            pictureBox2.Location = new Point(300, 60);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(103, 106);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // bullettemp
            // 
            bullettemp.BackColor = Color.DarkSlateGray;
            bullettemp.Location = new Point(364, 699);
            bullettemp.Name = "bullettemp";
            bullettemp.Size = new Size(5, 15);
            bullettemp.TabIndex = 2;
            bullettemp.TabStop = false;
            bullettemp.Visible = false;
            // 
            // exit
            // 
            exit.BackColor = Color.RosyBrown;
            exit.Location = new Point(697, 12);
            exit.Name = "exit";
            exit.Size = new Size(43, 29);
            exit.TabIndex = 9;
            exit.Text = "<--";
            exit.UseVisualStyleBackColor = false;
            exit.Visible = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 803);
            Controls.Add(exit);
            Controls.Add(bullettemp);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            Shown += Form2_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bullettemp).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox bullettemp;
        private Button exit;
    }
}