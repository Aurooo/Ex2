using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex2
{
    public partial class Form1 : Form
    {
        private readonly Random die = new Random();
        int timeLeft;
        int num1, num2;
        private readonly int[] results = new int[4];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            StartQuiz();
        }

        private void StartQuiz()
        {
            sum.ResetText();
            difference.ResetText();
            product.ResetText();
            quotient.ResetText();

            num1 = die.Next(51);
            num2 = die.Next(51);
            results[0] = num1 + num2;
            plusLeftLabel.Text = num1.ToString();
            plusRightLabel.Text = num2.ToString();

            do
            {
                num1 = die.Next(51);
                num2 = die.Next(51);
            } while (num1 < num2);
            results[1] = num1 - num2;
            minusLeftLabel.Text = num1.ToString();
            minusRightLabel.Text = num2.ToString();

            num1 = die.Next(11);
            num2 = die.Next(11);
            results[2] = num1 * num2;
            timesLeftLabel.Text = num1.ToString();
            timesRightLabel.Text = num2.ToString();

            do
            {
                num1 = die.Next(51);
                num2 = die.Next(51);
            } while (num2 == 0 || num1 < num2 || num1 % num2 != 0);
            results[3] = num1 / num2;
            dividedLeftLabel.Text = num1.ToString();
            dividedRightLabel.Text = num2.ToString();


            timeLeft = 20;
            timeLabel.Text = $"{timeLeft} seconds";
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //if (Answers())
            //{
            //    timer.Stop();
            //    timeLabel.Text = "Time's up";
            //    MessageBox.Show("Answers are correct", "Congrats");
            //    startButton.Enabled = true;
            //}
            if (timeLeft > 0)
            {
                timeLeft -= 1;
                timeLabel.Text = $"{timeLeft} seconds";
            }
            else
            {
                if (Answers())
                {
                    timer.Stop();
                    timeLabel.Text = "";
                    MessageBox.Show("Answers are correct", "Congrats");
                    startButton.Enabled = true;
                }
                else
                {
                    timer.Stop();
                    timeLabel.Text = "";
                    MessageBox.Show("Incorrect answers", "Sorry");
                    startButton.Enabled = true;
                }
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (!startButton.Enabled)
                timeLeft = 0;
        }

        private bool Answers() =>
            sum.Value == results[0] &&
            difference.Value == results[1] &&
            product.Value == results[2] &&
            quotient.Value == results[3];
    }
}

