using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        private System.Windows.Forms.Timer enemySpawnTimer;
        private System.Windows.Forms.Timer enemyMoveTimer;
        private List<PictureBox> bullets = new List<PictureBox>();
        private List<PictureBox> enemies = new List<PictureBox>();
        private Random rand = new Random();

        private bool gameOver = false;

        private void StopGame()
        {
            if (gameOver) return;
            gameOver = true;

            enemySpawnTimer?.Stop();
            enemyMoveTimer?.Stop();

            foreach (var enemy in enemies.ToList())
            {
                this.Controls.Remove(enemy);
                enemies.Remove(enemy);
                enemy.Dispose();
            }

            foreach (var bullet in bullets.ToList())
            {
                this.Controls.Remove(bullet);
                bullets.Remove(bullet);
                bullet.Dispose();
            }

            MessageBox.Show("again", "znova", MessageBoxButtons.OK, MessageBoxIcon.Information);
            exit.Visible = true;
        }

        public Form6()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form6_KeyDown;
            this.MouseDown += Form6_MouseDown;
            this.Load += Form6_Load;
            this.Shown += Form6_Shown;


        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox bullet = new PictureBox();
                bullet.Size = bullettemp.Size;
                bullet.BackColor = bullettemp.BackColor;

                bullet.Location = new Point(
                pictureBox1.Left + pictureBox1.Width / 2 - bullet.Width / 2,
                pictureBox1.Top - bullet.Height
                );

                this.Controls.Add(bullet);
                bullets.Add(bullet);
                bullet.BringToFront();

                System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();
                bulletTimer.Interval = 10;
                bulletTimer.Tick += (s, ev) =>
                {
                    bullet.Top -= 10;

                    foreach (var enemy in enemies.ToList())
                    {
                        if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                        {
                            this.Controls.Remove(bullet);
                            this.Controls.Remove(enemy);
                            bullets.Remove(bullet);
                            enemies.Remove(enemy);
                            bullet.Dispose();
                            enemy.Dispose();

                            bulletTimer.Stop();

                            MessageBox.Show("congratulations", "gatulujem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            exit.Visible = true;

                            return;
                        }
                    }

                    if (bullet.Top < 0)
                    {
                        bulletTimer.Stop();
                        this.Controls.Remove(bullet);
                        bullet.Dispose();
                    }
                };
                bulletTimer.Start();
            }
        }

        private void SpawnOneEnemy()
        {
            PictureBox enemy = new PictureBox();
            enemy.Size = pictureBox2.Size;
            enemy.Image = pictureBox2.Image;
            enemy.SizeMode = pictureBox2.SizeMode;
            enemy.BackColor = Color.Transparent;

            int x = rand.Next(0, ClientSize.Width - enemy.Width);
            enemy.Location = new Point(x, 0);

            this.Controls.Add(enemy);
            enemies.Add(enemy);
            enemy.BringToFront();

        }
        private async void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = "Hýbeš sa pomocou šípok doľava a doprava";
            await Task.Delay(4000);

            label1.Text = " ";
            await Task.Delay(4000);

            label1.Text = "Teraz ľavým tlačidlom myši traf nepriateľa";
            await Task.Delay(4000);

            label1.Visible = false;

            SpawnOneEnemy();

            enemyMoveTimer = new System.Windows.Forms.Timer();
            enemyMoveTimer.Interval = 20;
            enemyMoveTimer.Tick += EnemyMoveTimer_Tick;
            enemyMoveTimer.Start();
            exit.Click += exit_Click;
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
        }

        private void EnemyMoveTimer_Tick(object sender, EventArgs e)
        {
            foreach (var enemy in enemies.ToList())
            {
                enemy.Top += 3;

                if (enemy.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    StopGame();
                    return;
                }

                if (enemy.Top > ClientSize.Height)
                {
                    StopGame();
                    return;
                }
            }
        }

        private void Form6_Shown(object sender, EventArgs e)
        {
            int y = (ClientSize.Height - pictureBox1.Height);
            int x = (ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Location = new Point(x, y);

            pictureBox2.Visible = false;
        }

        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            int moveAmount = 10;
            int newX = pictureBox1.Left;

            if (e.KeyCode == Keys.Right)
            {
                newX += moveAmount;
                if (newX + pictureBox1.Width > ClientSize.Width)
                    newX = ClientSize.Width - pictureBox1.Width;
            }
            else if (e.KeyCode == Keys.Left)
            {
                newX -= moveAmount;
                if (newX < 0)
                    newX = 0;
            }

            pictureBox1.Location = new Point(newX, pictureBox1.Top);

        }//commit
    }
}

