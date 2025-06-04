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
            

        }
        


    }
}
