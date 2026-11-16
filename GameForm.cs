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

        void GameOver()
        {
            lblWinner.Text = lblTurn.Text;
            lblTurn.Text = "Game Over";

            MessageBox.Show("Game Over.", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool CheckWinner()
        {
            if (pic1.Tag == "X" && pic2.Tag == "X" && pic3.Tag == "X")
                return true;

            else if (pic1.Tag == "O" && pic2.Tag == "O" && pic3.Tag == "O")
                return true;

            else if (pic4.Tag == "X" && pic5.Tag == "X" && pic6.Tag == "X")
                return true;

            else if (pic4.Tag == "O" && pic5.Tag == "O" && pic6.Tag == "O")
                return true;

            else if (pic7.Tag == "X" && pic8.Tag == "X" && pic9.Tag == "X")
                return true;

            else if (pic7.Tag == "O" && pic8.Tag == "O" && pic9.Tag == "O")
                return true;


            else if (pic1.Tag == "X" && pic5.Tag == "X" && pic9.Tag == "X")
                return true;

            else if (pic1.Tag == "O" && pic5.Tag == "O" && pic9.Tag == "O")
                return true;

            else if (pic3.Tag == "X" && pic5.Tag == "X" && pic7.Tag == "X")
                return true;

            else if (pic3.Tag == "O" && pic5.Tag == "O" && pic7.Tag == "O")
                return true;


            else if (pic1.Tag == "X" && pic4.Tag == "X" && pic7.Tag == "X")
                return true;

            else if (pic1.Tag == "O" && pic4.Tag == "O" && pic7.Tag == "O")
                return true;

            else if (pic2.Tag == "X" && pic5.Tag == "X" && pic8.Tag == "X")
                return true;

            else if (pic2.Tag == "O" && pic5.Tag == "O" && pic8.Tag == "O")
                return true;

            else if (pic3.Tag == "X" && pic6.Tag == "X" && pic9.Tag == "X")
                return true;

            else if (pic3.Tag == "O" && pic6.Tag == "O" && pic9.Tag == "O")
                return true;

            return false;
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

            if (CheckWinner())
                GameOver();
            else
                ChangeTurn();

        }

        void StartGame(PictureBox pb)
        {
            GameTurn(pb);
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

            StartGame(pb);
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            lblTurn.Text = "Player 1";
            lblWinner.Text = "In Progress";
            pic1.Image = Properties.Resources.QuestionMark;
            pic2.Image = Properties.Resources.QuestionMark;
            pic3.Image = Properties.Resources.QuestionMark;
            pic4.Image = Properties.Resources.QuestionMark;
            pic5.Image = Properties.Resources.QuestionMark;
            pic6.Image = Properties.Resources.QuestionMark;
            pic7.Image = Properties.Resources.QuestionMark;
            pic8.Image = Properties.Resources.QuestionMark;
            pic9.Image = Properties.Resources.QuestionMark;

            pic1.Tag = "Empty";
            pic2.Tag = "Empty";
            pic3.Tag = "Empty";
            pic4.Tag = "Empty";
            pic5.Tag = "Empty";
            pic6.Tag = "Empty";
            pic7.Tag = "Empty";
            pic8.Tag = "Empty";
            pic9.Tag = "Empty";
        }
    }
}
