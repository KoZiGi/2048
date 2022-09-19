using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_WPF
{
    class Mve
    {
        private static int[,] Matrix;
        public Mve(int[,] m) {
            Matrix = m;
        }
        public void Up()
        {
            for (int sor = 1; sor < 5; sor++)
            {
                for (int oszlop = 1; oszlop < 5; oszlop++)
                {
                    MoveTo(sor, oszlop, 0);
                }
            }
        }
        public void Right()
        {
            for (int oszlop = 4; oszlop > 0; oszlop--)
            {
                for (int sor = 4; sor > 0; sor--)
                {
                    MoveTo(sor, oszlop, 1);
                }
            }
        }
        public void Down()
        {
            for (int sor = 4; sor > 0; sor--)
            {
                for (int oszlop = 4; oszlop > 0; oszlop--)
                {
                    MoveTo(sor, oszlop, 2);
                }
            }
        }
        public void Left()
        {
            for (int oszlop = 1; oszlop < 5; oszlop++)
            {
                for (int sor = 1; sor < 5; sor++)
                {
                    MoveTo(sor, oszlop, 3);
                }
            }
        }
        private void MoveTo(int row, int col, int dir)
        {
            if (dir == 0 || dir == 2)
            {
                if (dir == 0)
                {
                    if (Matrix[row - 1, col] == 0 || Matrix[row, col] == Matrix[row - 1, col])
                    {
                        Matrix[row - 1, col] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row - 1, col, dir);
                    }
                }
                if (dir == 2)
                {
                    if (Matrix[row + 1, col] == 0 || Matrix[row, col] == Matrix[row + 1, col])
                    {
                        Matrix[row + 1, col] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row + 1, col, dir);
                    }
                }
            }
            if (dir == 1 || dir == 3)
            {
                if (dir == 1)
                {
                    if (Matrix[row, col+1] == 0 || Matrix[row, col] == Matrix[row, col+1])
                    {
                        Matrix[row, col+1] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row, col+1, dir);
                    }
                }
                if (dir == 3)
                {
                    if (Matrix[row, col-1] == 0 || Matrix[row, col] == Matrix[row, col-1])
                    {
                        Matrix[row, col-1] += Matrix[row, col];
                        Matrix[row, col] = 0;
                        MoveTo(row, col-1, dir);
                    }
                }
            }
        }
    }
}
