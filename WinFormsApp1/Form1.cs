namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void CenterButtons(params Button[] buttons)
        {
            int spacing = 30;
            int totalHeight = buttons.Sum(b => b.Height + spacing) - spacing;
            int startY = (this.ClientSize.Height - totalHeight) / 2;

            foreach (Button b in buttons)
            {
                int x = (this.ClientSize.Width - b.Width) / 2;
                b.Location = new Point(x, startY);
                startY += b.Height + spacing;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterButtons(button1, button3);
            button1.Click += button1_Click;
            button3.Click += button3_Click;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 hra = new Form3();
            hra.Show();  
            this.Hide();  
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form6 hra = new Form6();
            hra.Show();
            this.Hide();
        }



    }
}
