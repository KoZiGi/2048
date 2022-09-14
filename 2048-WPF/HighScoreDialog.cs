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
    public partial class HighScoreDialog : Form
    {
        public int moves = 0;
        public HighScoreDialog(int moveN)
        {
            InitializeComponent();
            moves = moveN;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTbx.Text != "")
            {
                WriteFile();
            }
            else MessageBox.Show("Kérem írjon be egy nevet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void WriteFile()
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();
            if (File.Exists("highscores.txt"))
            {
                foreach (string line in File.ReadAllLines("highscores.txt"))
                {
                    scores.Add(line.Split('|')[0], Convert.ToInt32(line.Split('|')[1]));
                }
            }
            else
            {
                scores.Add(NameTbx.Text, moves);
            }
            StreamWriter w = new StreamWriter("highscores.txt");
            foreach (KeyValuePair<string, int> kp in scores)
            {
                w.WriteLine($"{kp.Key}|{kp.Value}");
            }
        }
    }
}
