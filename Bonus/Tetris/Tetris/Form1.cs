using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        List<Button> body = new List<Button>();
        int k = 1;
        int cnt = 0;
        public Form1()
        {
            InitializeComponent();
            label1.ForeColor = Color.Red;
            label1.Text = cnt.ToString();

        }
        bool Checking1()
        {
            int x1 = button1.Location.X;
            int y1 = button1.Location.Y;
            int bw1 = button1.Width;
            int bh1 = button1.Height;
            for (int i = 0; i < body.Count; i++)
            {
                int x2 = body[i].Location.X;
                int y2 = body[i].Location.Y;
                int bw2 = body[i].Width;
                int bh2 = body[i].Height;
                if (x2 > x1 && y2>y1)
                {
                    if (x2 + bw2 - x1 < bw1 + bw2 && y2+bh2-y1<bh1+bh2)
                        return true;
                }
                if (x2 > x1 && y2 < y1)
                {
                    if (x2 + bw2 - x1 < bw1 + bw2 && y1 + bh1 - y2 < bh1 + bh2)
                        return true;
                }
                if (x1>x2 && y1>y2)
                {
                    if ((x1 + bw1 - x2 < bw1+bw2) && (y1+bh1-y2 < bh1 + bh2))
                        return true;
                }
                if (x1 > x2 && y2>y1)
                {
                    if ((x1 + bw1 - x2 < bw1 + bw2) && (y2 + bh2 - y1 < bh1 + bh2))
                        return true;
                }
            }
            return false;
        }

        public void Checking3()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (body[i].Location.Y == Height - 20)
                {
                    body.Remove(body[i]);
                    Controls.Remove(body[i]);
                    cnt++;
                    label1.Text = cnt.ToString();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k % 5 == 0)
            {
                Random r = new Random();
                int x = r.Next(1, Width - 10);
                Button btn = new Button();
                btn.Size = new Size(15, 15);
                btn.Text = "b";
                btn.BackColor = Color.Black;
                btn.Location = new Point(x, 0);
                btn.Enabled = false;
                body.Add(btn);
                Controls.Add(btn);
            }
            else
            {
                if (Checking1())
                {
                    timer1.Stop();
                    MessageBox.Show("GAME OVER"+"\nYOUR SCORE IS "+int.Parse(label1.Text));
                }
                Checking3();
                for (int i = 0; i < body.Count; i++)
                {
                    int a = body[i].Location.X;
                    int b = body[i].Location.Y;
                    b+=5;
                    body[i].Location = new Point(a, b);
                }
            }
            k++;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                int k = button1.Location.X;
                int j = button1.Location.Y;
                j -= 5;
                button1.Location = new Point(k, j);
            }
            if (e.KeyCode == Keys.S)
            {
                int k = button1.Location.X;
                int j = button1.Location.Y;
                j += 5;
                button1.Location = new Point(k, j);
            }
            if (e.KeyCode == Keys.A)
            {
                int k = button1.Location.X;
                int j = button1.Location.Y;
                k -= 5;
                button1.Location = new Point(k, j);
            }
            if (e.KeyCode == Keys.D)
            {
                int k = button1.Location.X;
                int j = button1.Location.Y;
                k += 5;
                button1.Location = new Point(k, j);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
