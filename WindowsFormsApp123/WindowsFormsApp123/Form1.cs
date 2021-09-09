using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp123
{
    public partial class Form1 : Form
    {
        int time = 0;
        int sw = 1;
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "시간:" + time;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int a = rand.Next(8, 13);
            move(5); //구름
            over();
            if (time < 5) {
                obmove(5);
            }
            else if (time >= 5 && time<10)
            {
                obmove(5);
                ob2move(5);
            } else if (time >= 10 && time <15)
            {
                obmove(a);
            } else if (time >= 15)
            {
                switch (sw)
                {
                    case 1: obmove(a);
                        if (obPB.Left == 400)
                        {
                            sw = 2;
                        }
                        break;
                    case 2: ob2move(a);
                        if (ob2PB.Left == 400)
                        {
                            sw = 1;
                        }
                        break;
                }
            }
        }

        private void move(int length)
        {
            if(pictureBox1.Left <= 0)
            {
                pictureBox1.Left = 400;
            } else
            {
                pictureBox1.Left -= length;
            }
            if (pictureBox2.Left <= 0)
            {
                pictureBox2.Left = 400;
            }
            else
            {
                pictureBox2.Left -= length;
            }
            if (pictureBox3.Left <= 0)
            {
                pictureBox3.Left = 400;
            }
            else
            {
                pictureBox3.Left -= length;
            }
            if (pictureBox4.Left <= 0)
            {
                pictureBox4.Left = 400;
            }
            else
            {
                pictureBox4.Left -= length;
            }
        }

        private void obmove(int length)
        {
            if(obPB.Left <= 0)
            {
                obPB.Left = 400;
            }
            else
            {
                obPB.Left -= length;
            }
        }

        private void ob2move(int length)
        {
            if (ob2PB.Left <= 0)
            {
                ob2PB.Left = 400;
            }
            else
            {
                ob2PB.Left -= length;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                if(CharPB.Top >= 193)
                CharPB.Top -= 50;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                CharPB.Top = 193;
            }
        }

        private void over()
        {
            if (CharPB.Bounds.IntersectsWith(obPB.Bounds) || CharPB.Bounds.IntersectsWith(ob2PB.Bounds))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                DialogResult dr = MessageBox.Show("기록:"+time+" 다시 시작하시겠습니까?", "?",MessageBoxButtons.OKCancel);
                if(dr == DialogResult.OK)
                {
                    Application.Restart();
                } else if (dr== DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = "시간:" + time++;
        }
    }
}
