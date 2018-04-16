using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public partial class Form1 : Form
    {
        int k = 0;
        List<Button> l1, l11;
        List<Button> l2, l22;
        int[] a = new int[100];
        Ship ship = new Ship();
        string direction = "";
        public Form1()
        {
            InitializeComponent();
            l1 = new List<Button>();
            l11 = new List<Button>();
            l2 = new List<Button>();
            l22 = new List<Button>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i <10; i++)
            {
                for(int j = 0; j <10; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(35, 35);
                    btn.Location = new Point(j * 35 + 10, i * 35);
                    btn.Text = "";
                    btn.BackColor = Color.White;
                    btn.Click += Buttons1_Click;
                    Controls.Add(btn);
                    l1.Add(btn);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(35, 35);
                    btn.Location = new Point(j * 35 +400, i * 35);
                    btn.Text = "";
                    btn.BackColor = Color.White;
                    btn.Click += Buttons2_Click;
                    Controls.Add(btn);
                    l2.Add(btn);
                }
            }
        }
       
        private void Buttons1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (k == 4)
            {
                if (label4.Text == "0")
                    return;
                if(button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1,a,btn,k,direction,label4);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction, label4);
                }
            }
            if (k == 3)
            {
                if (label3.Text == "0")
                    return;
                if (button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1, a, btn, k, direction,label3);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction, label3);
                }
            }
            if (k == 2)
            {
                if (label2.Text == "0")
                    return;
                if (button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1, a, btn, k, direction,label2);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction, label2);
                }

            }
            if (k == 1)
            {
                if (label1.Text == "0")
                    return;
                if (button1.Text == "Left")
                {
                    direction = "Left";
                    ship.Draw(l1, a, btn, k, direction,label1);
                }
                if (button1.Text == "Down")
                {
                    direction = "Down";
                    ship.Draw(l1, a, btn, k, direction,label1);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Left")
                button1.Text = "Down";
            else
                button1.Text = "Left";
        }
        private void Buttons2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
        }
        private void Ships(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "4")
                k = 4;
            if (btn.Text == "3")
                k = 3;
            if (btn.Text == "2")
                k = 2;
            if (btn.Text == "1")
                k = 1;
        }
    }
}
