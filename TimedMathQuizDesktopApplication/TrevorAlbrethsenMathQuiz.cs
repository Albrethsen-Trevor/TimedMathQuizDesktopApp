using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuizDesktopApplication
{
    public partial class TrevorAlbrethsenMathQuiz : Form
    {

        Random rand = new Random();

        int plusLeft;
        int plusRight;

        int minusLeft;
        int minusRight;

        int timesLeft;
        int timesRight;

        int divisionLeft;
        int divisionRight;

        int timeLeft;

        public TrevorAlbrethsenMathQuiz()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            todaysDate.Text = DateTime.Now.ToString("dd MMMM, yyyy");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }

        private void StartQuiz()
        {
            Sum.Value = 0;
            Sub.Value = 0;
            Mul.Value = 0;
            Div.Value = 0;

            // Addition
            plusLeft = rand.Next(51);
            PlusLeftLabel.Text = plusLeft.ToString();
            plusRight = rand.Next(51);
            PlusRightLabel.Text = plusRight.ToString();

            // Subtraction
            minusLeft = rand.Next(1,101);
            MinusLeftLabel.Text = minusLeft.ToString();
            minusRight = rand.Next(1,minusLeft);
            MinusRightLabel.Text = minusRight.ToString();

            // Multiplication
            timesLeft = rand.Next(2,11);
            TimesLeftLabel.Text = timesLeft.ToString();
            timesRight = rand.Next(2,11);
            TimesRightLabel.Text = timesRight.ToString();

            // Division
            divisionRight = rand.Next(2,11);
            DivisionRightLabel.Text = divisionRight.ToString();
            int temp = rand.Next(2,11);
            divisionLeft = temp * divisionRight;
            DivisionLeftLabel.Text = divisionLeft.ToString();

            timeLeft = 30;
            TimeLeftLabel.Text = "30 Seconds";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckResult())
            {
                timer1.Stop();
                if (timeLeft < 10)
                {
                    TimeLeftLabel.BackColor = DefaultBackColor;
                }
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                TimeLeftLabel.Text = timeLeft + " Seconds";
                if (timeLeft < 10)
                {
                    TimeLeftLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                TimeLeftLabel.Text = "Time's up!!";
                MessageBox.Show("You didn't finish in time!",
                                "Sorry!");
            }
        }

        private bool CheckResult()
        {
            if ((plusLeft + plusRight == Sum.Value) &&
                (minusLeft - minusRight == Sub.Value) &&
                (timesLeft * timesRight == Mul.Value) &&
                (divisionLeft / divisionRight == Div.Value))
                return true;
            else
                return false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
