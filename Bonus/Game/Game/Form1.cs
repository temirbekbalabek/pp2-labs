using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        List<Button> body=new List<Button>();
        int n = 12,k=1,m;
        int cnt = 1;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            m = Height - 125;
            InitializeComponent();
            Button btn = new Button();
            btn.Location = new Point(n, m);
            btn.Size = new Size(15, 20);
            btn.Text = cnt.ToString();
            body.Add(btn);
            Controls.Add(body[0]);
            cnt++;
            k++;
        }
        /*bool Checking(int x, int y)
        {
            
        }*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k % 10 == 0)
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
                for(int i = 1; i < body.Count; i++)
                {
                    int a = body[i].Location.X;
                    int b = body[i].Location.Y;
                    b++;
                    body[i].Location = new Point(a,b);
                }
            }
            k++;
        }
        
    }
}
