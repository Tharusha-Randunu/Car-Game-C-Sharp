using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblgameover.Visible = false;
            lblrestart.Visible = false;
            lblexit.Visible = false;
        }
        //executing the programme
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gamespeed);
            enemy(gamespeed);
            gameover();
            coins(gamespeed);
            coinscollection();
        }

        //moving the middle white lines
        void moveline(int speed)
        {
            if (pictureBox1.Top >= 500)
            { pictureBox1.Top = 0; }
            else { pictureBox1.Top += speed; }

            if (pictureBox2.Top >= 500)
            { pictureBox2.Top = 0; }
            else { pictureBox2.Top += speed; }

            if (pictureBox3.Top >= 500)
            { pictureBox3.Top = 0; }
            else { pictureBox3.Top += speed; }

            if (pictureBox4.Top >= 500)
            { pictureBox4.Top = 0; }
            else { pictureBox4.Top += speed; }

        }

        //controls of the player car
        int gamespeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (car.Left > 0)
                    car.Left += -8;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (car.Right < 380)
                    car.Left += 8;
            }

            if (e.KeyCode == Keys.Up)
                if (gamespeed < 21)
                { gamespeed++; }
            if (e.KeyCode == Keys.Down)
                if (gamespeed > 0)
                { gamespeed--; }


        }

        //random enemy cars
        Random r = new Random();
        int x, y;
        void enemy(int speed)
        {
            if (enemy1.Top >= 500)
            {x= r.Next(20,135);
            enemy1.Location = new Point(x, 0);
            }
            else { enemy1.Top += speed; }

            if (enemy2.Top >= 500)
            {
                x = r.Next(150, 250);
                enemy2.Location = new Point(x, 0);
            }
            else { enemy2.Top += speed; }

            if (enemy3.Top >= 500)
            {
                x = r.Next(100, 350);
                enemy3.Location = new Point(x, 0);
            }
            else { enemy3.Top += speed; }
        }


        //random coins
        void coins(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(20, 100);
                coin1.Location = new Point(x, 0);
            }
            else { coin1.Top += speed; }


            if (coin2.Top >= 500)
            {
                x = r.Next(90, 135);
                coin2.Location = new Point(x, 0);
            }
            else { coin2.Top += speed; }


            if (coin3.Top >= 500)
            {
                x = r.Next(120, 350);
                coin3.Location = new Point(x, 0);
            }
            else { coin3.Top += speed; }


            if (coin4.Top >= 500)
            {
                x = r.Next(200, 350);
                coin4.Location = new Point(x, 0);
            }
            else { coin4.Top += speed; }
        }

    
        //gameover
        void gameover()
        {
            if(car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled=false;
                lblgameover.Visible =true;
                lblrestart.Visible = true;
                lblexit.Visible = true;
               
            }

            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                lblgameover.Visible = true;
                lblrestart.Visible = true;
                lblexit.Visible = true;
            }

            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                lblgameover.Visible = true;
                lblrestart.Visible = true;
                lblexit.Visible = true;
            }     
        }


        //collecting coins and scoring
        int coinscollected = 0;

        void coinscollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                coinscollected++;
                lblscore.Text = "Coins : " + coinscollected.ToString();
                x = r.Next(120, 350);
                coin1.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                coinscollected++;
                lblscore.Text = "Coins : " + coinscollected.ToString();
                x = r.Next(120, 350);
                coin2.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                coinscollected++;
                lblscore.Text = "Coins : " + coinscollected.ToString();
                x = r.Next(120, 350);
                coin3.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                coinscollected++;
                lblscore.Text = "Coins : " + coinscollected.ToString();
                x = r.Next(120, 350);
                coin4.Location = new Point(x, 0);
            }

        }


        //restart button
        private void lblrestart_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
            lblrestart.Visible = false;
            lblexit.Visible = false;
            lblgameover.Visible = false;
            lblscore.ResetText();
            coinscollected = 0;
            lblscore.Text = "Coins : 0".ToString();
            
            
        }
        //exit
        private void lblexit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            

        }

       
        
    }
}
