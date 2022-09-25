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
        public static int[,] GameField;
        public bool WASD = false;
        public Label[,] labels;
        private static Mve mve;
        public static int moves = 0;
        public bool completed = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Display()
        {
            for (int sor = 1; sor < GameField.GetLength(0)-1; sor++)
            {
                for (int oszlop = 1; oszlop < GameField.GetLength(1)-1; oszlop++)
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
            for (int i = 0; i < GameField.GetLength(0); i++)
                for (int j = 0; j < GameField.GetLength(1); j++)
                    GameField[i, j] = (i == 0 || i == GameField.GetLength(0)-1 || j == 0 || j == GameField.GetLength(1)-1) ? 1 : 0;
        }
        private static bool CheckMovent()
        {
            for (int i = 1; i < GameField.GetLength(0)-1; i++)
			{
                for (int g = 1; g < GameField.GetLength(1)-1; g++)
			    {
                    if (GameField[i,g]==GameField[i+1,g] || GameField[i,g]==GameField[i-1,g] || GameField[i,g]==GameField[i,g-1] || GameField[i,g]==GameField[i,g+1])
                    {
                        return false;
                    }
			    }   
			}
            return true;
        }
        private static bool CanSpawn()
        {
            for (int i = 0; i < GameField.GetLength(0); i++)
			{
                for (int g = 0; g < GameField.GetLength(1); g++)
    			{
                    if (GameField[i,g]==0) return true;
		    	}
			}
            return false;
        }
        public static void Random2(int count)
        {
            if (CanSpawn())
            {
                int gen = 0;
                while (count != gen)
                {
                    Random x = new Random(), y = new Random();
                    int X = x.Next(1, GameField.GetLength(0) - 1), Y = y.Next(1, GameField.GetLength(1)-1);
                    if (GameField[X, Y] == 0)
                    {
                        GameField[X, Y] = x.Next(1, 3) == 1 ? 2 : 4;
                        gen += 1;
                    }
                }
            }
            else
            {
                if (CheckMovent())
                {
                    MessageBox.Show("Game Over!");
                }
            }
        }
        private void checkWin()
        {
            for (int i = 0; i < GameField.GetLength(0); i++) 
                for (int j = 0; j < GameField.GetLength(0); j++) 
                    if (GameField[i, j] == 2048) CreateHighScores();
        }
        private void CreateHighScores()
        {
            HighScoreDialog hs = new HighScoreDialog(moves);
            hs.Show();
        }
        private void UpBtn_Click(object sender, EventArgs e)
        {
            mve.Up();
            Display();
            checkWin();
        }
        private void LeftBtn_Click(object sender, EventArgs e)
        {
            mve.Left();
            Display();
            checkWin();
        }
        private void RightBtn_Click(object sender, EventArgs e)
        {
            mve.Right();
            Display();
            checkWin();
        }
        private void DownBtn_Click(object sender, EventArgs e)
        {
            mve.Down();
            Display();
            checkWin();
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
                        Display();
                        checkWin();
                        break;
                    case "A":
                        mve.Left();
                        Display();
                        checkWin();
                        break;
                    case "S":
                        mve.Down();
                        Display();
                        checkWin();
                        break;
                    case "D":
                        mve.Right();
                        Display();
                        checkWin();
                        break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            int number = Convert.ToInt32(numericUpDown1.Value);

            labels = new Label[number, number];
            GameField = new int[number + 2, number + 2];
            
            FillTheMatrix();
            Random2(2);

            for (int sor= 0; sor< labels.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < labels.GetLength(1); oszlop++)
                {
                    labels[sor, oszlop] = new Label()
                    {
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(50, 50),
                        Top = sor  * 50,
                        Font = new Font("Arial", 16, FontStyle.Bold),
                        Left = oszlop * 50,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    Controls.Add(labels[sor, oszlop]);
                }
            }

            SetPositions();
            
            mve = new Mve(GameField);
            Display();
        }
        private void SetPositions()
        {
            Width = (GameField.GetLength(0) - 2) * 50 + 15;

            UpBtn.Top = (GameField.GetLength(0) - 2) * 50;
            UpBtn.Left = (Width / 2) - 25;

            SwitchToKbdBtn.Top = (GameField.GetLength(0) - 2) * 50 + SwitchToKbdBtn.Height;
            SwitchToKbdBtn.Left = (Width / 2) - 25;

            DownBtn.Top = (GameField.GetLength(0) - 2) * 50 + DownBtn.Height * 2;
            DownBtn.Left = Width/2-25;

            LeftBtn.Top = (GameField.GetLength(0) - 2) * 50 + LeftBtn.Height;
            LeftBtn.Left = (Width / 2 - 25) - LeftBtn.Width;

            RightBtn.Top = (GameField.GetLength(0) - 2) * 50 + RightBtn.Height;
            RightBtn.Left = (Width / 2 - 25) + RightBtn.Width;

            Height = DownBtn.Top + DownBtn.Height*2;

            UpBtn.Visible = true;
            DownBtn.Visible = true;
            LeftBtn.Visible = true;
            RightBtn.Visible = true;
            SwitchToKbdBtn.Visible = true;
        }
    }
}
