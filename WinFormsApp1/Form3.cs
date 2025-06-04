using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Click += button1_Click;
            button3.Click += button3_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 hra = new Form2();
            hra.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 hra = new Form4();
            hra.Show();
            this.Hide();
        }
    }
}
