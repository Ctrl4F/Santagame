using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaClausIsComingToTown
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int ObstacleSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Tree_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Santa.Top += gravity;
            Moon.Left -= ObstacleSpeed;
            Tree.Left -= ObstacleSpeed;
            Hut.Left -= ObstacleSpeed;
            Hut2.Left -= ObstacleSpeed;
            ScoreLabel.Text = $"Score: {score}";

            if(Moon.Left < -160)
            {
                Moon.Left = 570;
                score++;
            }

            if(Tree.Left < -130)
            {
                Tree.Left = 670;
                score++;
            }

            if(Santa.Top < -25)
            {
                GameOver();
            }

            if(Hut.Left < -150)
            {
                Hut.Left = 670;
            }

            if(Hut2.Left < -40)
            {
                Hut2.Left = 670;
            }

            if(Santa.Bounds.IntersectsWith(Moon.Bounds) || Santa.Bounds.IntersectsWith(Tree.Bounds) || Santa.Bounds.IntersectsWith(Ground.Bounds))
            {
                GameOver();
            }

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void Santa_Click(object sender, EventArgs e)
        {

        }

        private void GameOver()
        {
            timer1.Stop();
            ScoreLabel.Text = $"Game Over";
            PlayAgain.Visible = true;
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
