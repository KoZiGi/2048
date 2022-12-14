using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace _2048_WPF
{
    class Mve
    {
        private static int[,] Matrix;
        private static int fs;
        private static int palyameret;
        private static int mc = 0;
        public static int[,] TempMatrix;
        public Mve(int[,] m) {
            Matrix = m;
            palyameret = Matrix.GetLength(0);
            fs = palyameret-2;
            TempMatrix = new int[palyameret, palyameret];
            MirrorMatrix();
        }
        private void MirrorMatrix()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int g = 0; g < Matrix.GetLength(0); g++)
                {
                    TempMatrix[i,g] = Matrix[i,g];
                }
            }
        }
        private void Check()
        {
            if (!CheckMatrixes())
            {
                Form1.moves++;
                Form1.Random2(1);
                MirrorMatrix();
            }
        }
        private bool CheckMatrixes()
        {
            return Matrix == TempMatrix;
        }
        public void Up()
        {
            for (int sor = 1; sor < palyameret - 1; sor++)
            {
                for (int oszlop = 1; oszlop < palyameret - 1; oszlop++)
                {
                    mc = 1;
                    MoveTo(sor, oszlop, 0);
                }
            }
            Check();
        }
        
        public void Right()
        {
            for (int oszlop = palyameret - 2; oszlop > 0; oszlop--)
            {
                for (int sor = palyameret - 2; sor > 0; sor--)
                {
                    mc = 1;
                    MoveTo(sor, oszlop, 1);
                }
            }
            Check();
        }
        public void Down()
        {
            for (int sor = palyameret - 2; sor > 0; sor--)
            {
                for (int oszlop = palyameret - 2; oszlop > 0; oszlop--)
                {
                    mc = 1;
                    MoveTo(sor, oszlop, 2);
                }
            }
            Check();
        }
        public void Left()
        {
            for (int oszlop = 1; oszlop < palyameret - 1; oszlop++)
            {
                for (int sor = 1; sor < palyameret - 1; sor++)
                {
                    mc = 1;
                    MoveTo(sor, oszlop, 3);
                }
            }
            Check();
        }
        private void MoveTo(int row, int col, int dir)
        {
            if (dir == 0 || dir == 2)
            {
                if (dir == 0)
                {

                    if (Matrix[row - 1, col] == 0 )
                    {
                        Matrix[row - 1, col] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row - 1, col, dir);
                    }


                    if (Matrix[row, col] == Matrix[row - 1, col]&&mc<Math.Floor(Convert.ToDouble(fs/2)))
                    {
                        Matrix[row - 1, col] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        mc++;
                        MoveTo(row - 1, col, dir);
                    }


                }
                if (dir == 2)
                {
                    if (Matrix[row + 1, col] == 0)
                    {
                        Matrix[row + 1, col] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row + 1, col, dir);
                    }
                    if (Matrix[row, col] == Matrix[row + 1, col]&&mc<Math.Floor(Convert.ToDouble(fs/2)))
                    {
                        Matrix[row + 1, col] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        mc++;
                        MoveTo(row + 1, col, dir);
                    }
                }
            }
            if (dir == 1 || dir == 3)
            {
                if (dir == 1)
                {
                    if (Matrix[row, col+1] == 0)
                    {
                        Matrix[row, col+1] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row, col+1, dir);
                    }
                    if (Matrix[row, col] == Matrix[row, col+1] && mc < Math.Floor(Convert.ToDouble(fs / 2)))
                    {
                        Matrix[row, col+1] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        mc++;
                        MoveTo(row, col+1, dir);
                    }
                }
                if (dir == 3)
                {
                    if (Matrix[row, col-1] == 0)
                    {
                        Matrix[row, col-1] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row, col-1, dir);
                    }
                    if (Matrix[row, col] == Matrix[row, col-1] && mc < Math.Floor(Convert.ToDouble(fs / 2)))
                    {
                        Matrix[row, col-1] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        mc++;
                        MoveTo(row, col-1, dir);
                    }
                }
            }
        }
    }
}
