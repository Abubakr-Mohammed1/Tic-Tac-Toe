using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        void CheckWinner()
        {

        }

        void ChangeTurn()
        {
            if (lblTurn.Text == "Player 1")
                lblTurn.Text = "Player 2";
            else
                lblTurn.Text = "Player 1";
        }

        void GameTurn(PictureBox pb)
        {
            if (pb.Tag == null || pb.Tag.ToString() != "Empty")
            {
                MessageBox.Show("Wrong Choice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblTurn.Text == "Player 1")
            {
                pb.Image = Properties.Resources.X;
                pb.Tag = "X";
            }
            else if (lblTurn.Text == "Player 2")
            {
                pb.Image = Properties.Resources.O;
                pb.Tag = "O";
            }

            ChangeTurn();

        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 15);

            // Vertical Lines
            e.Graphics.DrawLine(pen, 1023, 190, 1023, 890);
            e.Graphics.DrawLine(pen, 1256, 190, 1256, 890);

            // Horizontal Lines
            e.Graphics.DrawLine(pen, 790, 423, 1490, 423);
            e.Graphics.DrawLine(pen, 790, 656, 1490, 656);

            pen.Dispose();
        }

        private void pics_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            GameTurn(pb);
        }
    }
}
