﻿using System;
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
        public int[,] GameField =
        {
            {1,1,1,1,1,1 },
            {1,2,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,2,0,0,0,1 },
            {1,0,0,0,0,1 },
            {1,1,1,1,1,1 }
        };
        
        public bool WASD = false;
        public Label[,] labels;
        
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
            Display();
        }
        private void Display()
        {
            for (int sor = 1; sor < 5; sor++)
            {
                for (int oszlop = 1; oszlop < 5; oszlop++)
                {
                    labels[sor - 1, oszlop - 1].Text= GameField[sor, oszlop].ToString()=="0"?" ": GameField[sor, oszlop].ToString();
                }
            }
        }
        private void FillTheMatrix()
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    GameField[i, j] = (i == 0 || i == 5 || j == 0 || j == 5) ? 1 : 0;
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
