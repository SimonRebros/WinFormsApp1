﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        private System.Windows.Forms.Timer enemySpawnTimer;
        private System.Windows.Forms.Timer enemyMoveTimer;
        private List<PictureBox> bullets = new List<PictureBox>();
        private List<PictureBox> enemies = new List<PictureBox>();
        private Random rand = new Random();

        private int enemiesspawned = 0;
        private int enemiesdestroyed = 0;
        private const int maxenemies = 20;

        private bool gameOver = false;

        public Form5()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form5_KeyDown;
            this.MouseDown += Form5_MouseDown;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

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

            MessageBox.Show("Game Over!");
            Environment.Exit(0);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            enemySpawnTimer = new System.Windows.Forms.Timer();
            enemySpawnTimer.Interval = 2000;
            enemySpawnTimer.Tick += EnemySpawnTimer_Tick;
            enemySpawnTimer.Start();

            enemyMoveTimer = new System.Windows.Forms.Timer();
            enemyMoveTimer.Interval = 3;
            enemyMoveTimer.Tick += EnemyMoveTimer_Tick;
            enemyMoveTimer.Start();
        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            int y = (ClientSize.Height - pictureBox1.Height);
            int x = (ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Location = new Point(x, y);

            pictureBox2.Visible = false;
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
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

                            enemiesdestroyed++;

                            if (enemiesdestroyed == maxenemies)
                            {
                                gameOver = true;
                                enemySpawnTimer?.Stop();
                                enemyMoveTimer?.Stop();
                                MessageBox.Show("Win!");
                                Environment.Exit(0);
                            }

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

        private void EnemySpawnTimer_Tick(object sender, EventArgs e)
        {
            if (gameOver || enemiesspawned >= maxenemies)
            {
                enemySpawnTimer.Stop();
                return;
            }

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

            enemiesspawned++;
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

        private void Form5_KeyDown(object sender, KeyEventArgs e)
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
        }
    }
}



