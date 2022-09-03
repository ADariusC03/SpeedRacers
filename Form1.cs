using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedRacers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // over.Visible = false;
            game_Menu.Hide();


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            mainLine(gamespeed);
            enemy(gamespeed);
            gameOver();
            point(gamespeed);
            collection();


        }

        // Shows the speed of the pic box white lines moving
        void mainLine(int speed)
        {

            if (pictureBox1.Top >= 500)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += speed;
            }


            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }


            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }


            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }


            if (pictureBox5.Top >= 500)
            {
                pictureBox5.Top = 0;
            }
            else
            {
                pictureBox5.Top += speed;
            }


            if (pictureBox8.Top >= 500)
            {
                pictureBox8.Top = 0;
            }
            else
            {
                pictureBox8.Top += speed;
            }
        }

        // method for the enemy cars speed and location
        Random r = new Random();
        int x;
        void enemy(int speed)
        {
            if (enemy1.Top >= 500)
            {
                x = r.Next(0, 250);

                enemy1.Location = new Point(x, 0);
            }
            else
            {
                enemy1.Top += speed;
            }

            if (enemy2.Top >= 500)
            {
                x = r.Next(0, 380);

                enemy2.Location = new Point(x, 0);
            }
            else
            {
                enemy2.Top += speed;
            }

            if (enemy3.Top >= 500)
            {
                x = r.Next(200, 320);

                enemy3.Location = new Point(x, 0);
            }
            else
            {
                enemy3.Top += speed;
            }

        }



        // Points to collect


        void point(int speed)
        {
            if (point4.Top >= 500)
            {
                x = r.Next(0, 380);
                point4.Location = new Point(x, 0);
            }
            else
            {
                point4.Top += speed;
            }

            if (point3.Top >= 500)
            {
                x = r.Next(0, 380);
                point3.Location = new Point(x, 0);
            }
            else
            {
                point3.Top += speed;
            }

            if (point2.Top >= 500)
            {
                x = r.Next(0, 380);
                point2.Location = new Point(x, 0);
            }
            else
            {
                point2.Top += speed;
            }

            if (point1.Top >= 500)
            {
                x = r.Next(220, 350);
                point1.Location = new Point(x, 0);
            }
            else
            {
                point1.Top += speed;
            }
        }

        // Method to collect points
        int collectp = 0;

        void collection()
        {
            if (Car1.Bounds.IntersectsWith(point4.Bounds))
            {
                collectp++;
                label1.Text = "Points:" + collectp.ToString();
                x = r.Next(50, 300);

                point4.Location = new Point(x, 0);


            }

            if (Car1.Bounds.IntersectsWith(point3.Bounds))
            {
                collectp++;
                label1.Text = "Points:" + collectp.ToString();
                x = r.Next(50, 300);

                point3.Location = new Point(x, 0);


            }

            if (Car1.Bounds.IntersectsWith(point2.Bounds))
            {
                collectp++;
                label1.Text = "Points:" + collectp.ToString();
                x = r.Next(50, 300);

                point2.Location = new Point(x, 0);


            }

            if (Car1.Bounds.IntersectsWith(point1.Bounds))
            {
                collectp++;
                label1.Text = "Points:" + collectp.ToString();
                x = r.Next(50, 300);

                point1.Location = new Point(x, 0);


            }
        }



        private void Car1_Click(object sender, EventArgs e)
        {


        }



        // gamespeed and controls
        int gamespeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                if (Car1.Left > 0)
                {
                    Car1.Left += -8;
                }

            }

            if (e.KeyCode == Keys.Right)
            { // 380 is the border control for the car . 400 is the screen size
                if (Car1.Right < 380)
                    Car1.Left += 8;
            }


            // background speed can increase with one push or held down

            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed < 20)
                {
                    gamespeed++;
                }
            }

            // slows down the background speed when pressed or held down

            if (e.KeyCode == Keys.Down)
            {
                if (gamespeed > 0)
                {
                    gamespeed--;
                }
            }
        }


        // game over when touhing enemy car
        // i want timer to stop once enemy is hit for a game over
        // game_Menu.Show() method helping bring up game menu

        void gameOver()
        {
            if (Car1.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
                game_Menu.Show();
            }

            if (Car1.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
                game_Menu.Show();
            }

            if (Car1.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                over.Visible = true;
                game_Menu.Show();
            }
        }

       

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        
        
        // Restarts the application when clicked

        private void lbl_restart_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            game_Menu.Hide();
            label1.Text = "Points: 0";
            Car1.Location = new Point(56, 381);
            enemy1.Location = new Point(40, 177);
            enemy2.Location = new Point(281, 282);
            enemy3.Location = new Point(204, 23);
            point1.Location = new Point(302, 164);
            point2.Location = new Point(216, 337);
            point3.Location = new Point(115, 282);
            point4.Location = new Point(72, 38);
        }
            // Enables the application to exit when clicked
        private void lbl_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


}

