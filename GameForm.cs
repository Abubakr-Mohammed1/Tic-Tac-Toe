using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{



    public partial class GameForm : Form
    {

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public byte PlayCount;
        }


        public GameForm()
        {
            InitializeComponent();
        }

        void EndGame()
        {
            lblTurn.Text = "Game Over";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player 1";
                    break;

                case enWinner.Player2:
                    lblWinner.Text = "Player 2";
                    break;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over.", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }

        public void CheckWinner()
        {
            if (CheckValues(Button1, Button2, Button3))
                return;

            if (CheckValues(Button4, Button5, Button6))
                return;

            if (CheckValues(Button7, Button8, Button9))
                return;

            if (CheckValues(Button1, Button4, Button7))
                return;

            if (CheckValues(Button2, Button5, Button8))
                return;

            if (CheckValues(Button3, Button6, Button9))
                return;

            if (CheckValues(Button1, Button5, Button9))
                return;

            if (CheckValues(Button3, Button5, Button7))
                return;

        }

        public void ChangeImage(Button btn)
        {

            if (GameStatus.GameOver)
            {
                MessageBox.Show("Game is already Over! Please ReStart Game.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;



                }

            }
            else
            {
                MessageBox.Show("Wrong Choice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void ResetButtons(Button btn)
        {
            btn.Image = Resources.QuestionMark;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        private void RestartGame()
        {
            ResetButtons(Button1);
            ResetButtons(Button2);
            ResetButtons(Button3);
            ResetButtons(Button4);
            ResetButtons(Button5);
            ResetButtons(Button6);
            ResetButtons(Button7);
            ResetButtons(Button8);
            ResetButtons(Button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";
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

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void btns_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            ChangeImage(btn);
        }
    }
}
