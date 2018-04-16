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
   public class Ship
    {
        public Ship()
        {

        }
        public bool Check(List<Button>l1,int[] a,Button btn)
        {
            for (int i = 0; i < 100; i++)
            {
                if (a[i] == 1 && btn == l1[i])
                {
                    return true;
                }
            }
            return false;
        }
        public void IsItPossibleToDraw(List<Button> l1,int[] a, int index,int size)
        {
            a[index] = 1;
            if (index - 10 >= 0)
            {
                if (l1[index - 10].BackColor == Color.White)
                    a[index - 10] = 1;
            }
            if(index + 10 < 100)
            {
                if (l1[index + 10].BackColor == Color.White)
                    a[index + 10] = 1;
            }
            
            if((index+1) % 10 != 0 && index + 1 < 100)
            {
                if (l1[index + 1].BackColor == Color.White)
                    a[index + 1] = 1;
            }
            
            if((index+1) % 10 != 1 && index -1 >0)
            {
                if (l1[index - 1].BackColor == Color.White)
                    a[index - 1] = 1;
            }
           
            if ((index+1) % 10 != 0 && index - 9 > 0)
            {
                if (l1[index - 9].BackColor == Color.White)
                    a[index - 9] = 1;
            }
            
            if((index + 1) % 10 != 1 && index - 11 > 0)
            {
                if (l1[index - 11].BackColor == Color.White)
                    a[index - 11] = 1;
            }
            
            if((index + 1) % 10 != 1 && index+9<100)
            {
                if (l1[index + 9].BackColor == Color.White)
                    a[index + 9] = 1;
            }
           
            if((index + 1) % 10 != 0 && index+11<100)
            {
                if (l1[index + 11].BackColor == Color.White)
                    a[index + 11] = 1;
            }
            
        }
        public void Draw(List<Button>l1,int[] a,Button btn, int size, string direction, Label label)
        {
            for (int i = 0; i < 100; i++)
            {
                if (l1[i] == btn)
                {
                    if (i % 10 + 1 < size && direction=="Left")
                        return;
                    if (10 - (i / 10) < size && direction == "Down")
                        return;
                    int cnt = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (direction == "Left")
                        {
                            if (Check(l1, a, l1[i - j]))
                                cnt++;
                        }
                        else
                        {
                            if (Check(l1, a, l1[i + 10*j]))
                                cnt++;
                        }
                    }
                    if (cnt == 0)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if(direction=="Left")
                            l1[i - k].BackColor = Color.Green;
                            else
                            l1[i + 10*k].BackColor = Color.Green;
                        }
                        int v = int.Parse(label.Text);
                        v--;
                        label.Text = v.ToString();
                        for (int kk = 0; kk < size; kk++)
                        {
                            if (direction == "Left")
                                IsItPossibleToDraw(l1, a, i - kk, size);
                            else
                                IsItPossibleToDraw(l1, a, i + 10*kk, size);
                        }
                    }
                   
                }
            }
        }
    }
}
