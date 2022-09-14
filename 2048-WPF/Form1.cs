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
        public int[,] GameField = new int[6, 6];
        public bool WASD = false;
        public Panel[,] panels;
        
        public Form1()
        {
            InitializeComponent();
            FillTheMatrix();
           /* panels = new Panel[,]{
                { p11,p12,p13,p14 },
                { p21,p22,p23,p24 },
                { p31,p32,p33,p34 },
                { p41,p42,p43,p44 }
            }; */
        }
        private void Display()
        {
            for (int sor = 1; sor < 5; sor++)
            {
                for (int oszlop = 1; oszlop < 5; oszlop++)
                {
                    //panels[sor - 1, oszlop - 1];
                }
            }
        }
        private void FillTheMatrix()
        {
            for (int i = 0; i < 6; i++) 
                for (int j = 0; j < 6; j++) 
                    GameField[i, j] = (i == 0 || i == 5 || j == 0 || j == 5) ? 1 : 0;
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

        private void SwitchToKbdBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (WASD)
            {
                
                switch (e.KeyChar.ToString().ToUpper())
                {
                    case "W":
                        DoMove(0);
                        break;
                    case "A":
                        DoMove(3);
                        break;
                    case "S":
                        DoMove(2);
                        break;
                    case "D":
                        DoMove(1);
                        break;
                }
            }
        }
    }
}
