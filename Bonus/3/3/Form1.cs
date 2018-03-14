using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bonus2
{
    public partial class Form1 : Form
    {
        List<Button> body = new List<Button>();
        int n = 12, k = 1, m;
        int cnt = 1;

        public Form1()
        {
            m = Height - 100;
        }
        int Checking1(int x, int y)
        {
            int dx = x;
            int dy = y;
            for (int i = 1; i < body.Count; i++)
            {
                x = dx;
                y = dy;
                for (int j = 1; j < 16; j++)
                {
                    for (int k = 1; k < 16; k++)
                    {
                        if ((x == body[i].Location.X && y == body[i].Location.Y))
                        {
                            return 1;
                        }
                        x++;
                    }
                    y++;
                    x = dx;
                }
            }
            return 0;
        }

        int Checking2(int x, int y)
        {
            int dx = x;
            int dy = y;
            for (int i = 0; i < body.Count; i++)
            {
                x = dx;
                y = dy;
                for (int j = 1; j < 16; j++)
                {
                    for (int k = 1; k < 16; k++)
                    {
                        if ((x == body[i].Location.X && y == body[i].Location.Y))
                        {
                            return 1;
                        }
                        x--;
                    }
                    y++;
                    x = dx;
                }
            }
            return 0;
        }
        public void Checking3()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (body[i].Location.Y == Height - 50)
                {
                    body.Remove(body[i]);
                    Controls.Remove(body[i]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k % 20 == 0)
            {
                Random r = new Random();
                int x = r.Next(1, Width - 10);
                Button btn = new Button();
                btn.Size = new Size(15, 15);
                btn.Text = cnt.ToString();
                btn.Location = new Point(x, 0);
                body.Add(btn);
                Controls.Add(btn);
                cnt++;
            }
            else
            {
                int aas = Checking1(button1.Location.X, button1.Location.Y);
                int aad = Checking2(button1.Location.X, button1.Location.Y);
                if (aas == 1 || aad == 1)
                {
                    timer1.Stop();
                }
                Checking3();
                for (int i = 0; i < body.Count; i++)
                {
                    int a = body[i].Location.X;
                    int b = body[i].Location.Y;
                    b++;
                    body[i].Location = new Point(a, b);
                }
            }
            k++;
        }

        private void asdf_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
           
    }
}
