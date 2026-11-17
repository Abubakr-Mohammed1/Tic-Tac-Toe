using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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




        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        break;



                    default:
                }
            }
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

        }

        private void btns_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            ChangeImage(btn);
        }
    }
}
