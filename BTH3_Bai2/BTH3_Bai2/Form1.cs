using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BTH3_Bai2
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = rand.Next(0, this.ClientSize.Width - 100);
            int y = rand.Next(0, this.ClientSize.Height - 30);
            int r = rand.Next(256); 
            int gr = rand.Next(256); 
            int b = rand.Next(256);
            Color randomColor = Color.FromArgb(r, gr, b);
            string textToDraw = "Paint Event";
            using (Font drawFont = new Font("Arial", 16, FontStyle.Bold))
            using (Brush drawBrush = new SolidBrush(randomColor))
            {
                g.DrawString(textToDraw, drawFont, drawBrush, x, y);
            }
        }

        private void btnRepaint_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
