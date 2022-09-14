using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_WPF
{
    public partial class Form1 : Form
    {
        public int[,] GameField = new int[4, 4];
        bool WASD = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void DoMove(int direction)
        {

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
