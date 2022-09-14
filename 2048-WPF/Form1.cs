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
        public int[,] GameField = new int[6, 6];
        bool WASD = false;
        public int moves = 0;
        public Form1()
        {
            InitializeComponent();
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
            DoMove(0);
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            DoMove(3);
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            DoMove(1);
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            DoMove(2);
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
    }
}
