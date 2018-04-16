using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        List<Button> list;
        public Form1()
        {
            InitializeComponent();
            list = new List<Button>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    btn.Text = "";
                    btn.Location = new Point(i * 51+25, j * 51);
                    btn.Click += Buttons_Click;
                    list.Add(btn);
                    Controls.Add(btn);
                }
            }
        }
        private void Buttons_Click(object sender,EventArgs e)
        {
            Button btn = sender as Button;
            Point location;
            location = btn.Location;
            for (int i = 0; i < 36; i++)
            {
                    if (btn.Location.X == list[i].Location.X || btn.Location.Y == list[i].Location.Y)
                    {
                        list[i].BackColor = Color.Blue;
                    }
                
            }

        }
    }
}
