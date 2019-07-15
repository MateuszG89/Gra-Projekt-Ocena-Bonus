using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!","!","N","N",",",",","k","k",
            "Y","Y","7","7","8","8","M","M"
        };

        Label FirstCliced, secondCliced;
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSqures();
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (FirstCliced != null && secondCliced != null)
                return;

            Label clickedLabel1 = sender as Label;

            if (clickedLabel1 == null)
                return;
            if (clickedLabel1.ForeColor == Color.Black)
                return;

            if(FirstCliced == null)
            {
                FirstCliced = clickedLabel1;
                FirstCliced.ForeColor = Color.Black;
                return;
            }

            secondCliced = clickedLabel1;
            secondCliced.ForeColor = Color.Black;

            CheckForWinner();

            if(FirstCliced.Text == secondCliced.Text)
            {
                FirstCliced = null;
                secondCliced = null;
            }
            else
                timer1.Start();


        }

        private void CheckForWinner()
        {
            Label label;
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;

            }

            MessageBox.Show("Kim jesteś? Jesteś Wygranym Gratuluję Wojownik Mateusz!!!");
            Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            FirstCliced.ForeColor = FirstCliced.BackColor;
            secondCliced.ForeColor = secondCliced.BackColor;

            FirstCliced = null;
            secondCliced = null;

        }

        private void AssignIconsToSqures()
        {
            Label label;
            int randomNumber;

            for(int i = 0; i< tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];
                icons.RemoveAt(randomNumber);
            }
        }
    }
}
