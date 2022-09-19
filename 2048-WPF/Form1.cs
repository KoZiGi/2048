using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2048_WPF
{
    public partial class Form1 : Form
    {
        public static int[,] GameField =
        {
            {1,1,1,1,1,1 },
            {1,0,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,1,1,1,1,1 }
        };
        public bool WASD = false;
        public Label[,] labels;
        Mve mve;
        public int moves = 0;
        public Form1()
        {
            InitializeComponent();
            //FillTheMatrix();
            labels = new Label[,]{
                {l11,l12,l13,l14 },
                {l21,l22,l23,l24 },
                {l31,l32,l33,l34 },
                {l41,l42,l43,l44 }
            };
            Random2(0);
            mve = new Mve(GameField);
            Display();
        }
        private void Display()
        {
            for (int sor = 1; sor < 5; sor++)
            {
                for (int oszlop = 1; oszlop < 5; oszlop++)
                {
                    labels[sor - 1, oszlop - 1].Text = GameField[sor, oszlop] == 0 ? " " : GameField[sor, oszlop].ToString();
                    setcolor(labels[sor-1,oszlop-1]);
                }
            }
        }
        private void setcolor(Label label)
        {
            switch (label.Text)
            {
                case "2":
                    label.BackColor = Color.FromArgb(238,228,218);
                    break;
                case "4":
                    label.BackColor = Color.FromArgb(237, 224, 200);
                    break;
                case "8":
                    label.BackColor = Color.FromArgb(242, 177, 121);
                    break;
                case "16":
                    label.BackColor = Color.FromArgb(245, 149, 99);
                    break;
                case "32":
                    label.BackColor = Color.FromArgb(246, 124, 96);
                    break;
                case "64":
                    label.BackColor = Color.FromArgb(246, 94, 59);
                    break;
                case "128":
                    label.BackColor = Color.FromArgb(237, 207, 115);
                    break;
                case "256":
                    label.BackColor = Color.FromArgb(237, 204, 98);
                    break;
                case "512":
                    label.BackColor = Color.FromArgb(237, 200, 80);
                    break;
                case "1024":
                    label.BackColor = Color.FromArgb(237, 197, 63);
                    break;
                case "2048":
                    label.BackColor = Color.FromArgb(237, 194, 45);
                    break;
                default:
                    label.BackColor = Color.Silver;
                    break;

            }
        }
        private void FillTheMatrix()
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    GameField[i, j] = (i == 0 || i == 5 || j == 0 || j == 5) ? 1 : 0;
        }
        private void Random2(int count)
        {
            if (count == 3)
            {
                return;
            }
            else
            {
                Random x = new Random(), y = new Random();
                int X = x.Next(1,5), Y = y.Next(1, 5);
                if (GameField[X, Y] == 0)
                {
                    GameField[X,Y] = x.Next(1,3) == 1 ? 2 : 4;
                    Random2(count+1);
                }
                else
                {
                    Random2(count+1);
                }
            }
        }
        private void CreateHighScores()
        {
            HighScoreDialog hs = new HighScoreDialog(moves);
            hs.Show();
        }
        private void DoMove(int direction)
        {

        }
        private int[,] Randomize()
        {
            int[,] tempfield = GameField;
            Random x = new Random(), y = new Random();
            int X = x.Next(1, 5), Y = y.Next(1, 5);
            if (tempfield[X, Y] == 0)
            {
                tempfield[X, Y] = x.Next(0, 1) == 0 ? 2 : 4;
                return tempfield;
            }
            else return Randomize();
        } 
        private void UpBtn_Click(object sender, EventArgs e)
        {
            mve.Up();
            Random2(0);
            Display();
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            mve.Left();
            Random2(0);
            Display();
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            mve.Right();
            Random2(0);
            Display();
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            mve.Down();
            Random2(0);
            Display();
        }

        private void SwitchToKbdBtn_Click(object sender, EventArgs e)
        {
            if (UpBtn.Enabled==false)
            {
                UpBtn.Enabled = true;
                LeftBtn.Enabled = true;
                RightBtn.Enabled = true;
                DownBtn.Enabled = true;
                WASD = false;
            }
            else
            {
                UpBtn.Enabled = false;
                LeftBtn.Enabled = false;
                RightBtn.Enabled = false;
                DownBtn.Enabled = false;
                WASD = true;
            }
        }

        private void SwitchToKbdBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (WASD)
            {
                
                switch (e.KeyChar.ToString().ToUpper())
                {
                    case "W":
                        mve.Up();
                        Random2(0);
                        Display();
                        break;
                    case "A":
                        mve.Left();
                        Random2(0);
                        Display();
                        break;
                    case "S":
                        mve.Down();
                        Random2(0);
                        Display();
                        break;
                    case "D":
                        mve.Right();
                        Random2(0);
                        Display();
                        break;
                }
            }
        }
    }
}
