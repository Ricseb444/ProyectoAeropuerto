﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoAeropuerto
{
    public partial class FAlert : Form
    {
        public FAlert()
        {
            InitializeComponent();
        }
       
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            error,
            info
        }

        private FAlert.enmAction action;
        private int x, y;              

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;                
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                FAlert frm = (FAlert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.pictureBox1.Image = Properties.Resources.Ok1;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Warning:
                    this.pictureBox1.Image = Properties.Resources.Warning_Shield;
                    this.BackColor = Color.DarkOrange;
                    break;
                case enmType.error:
                    this.pictureBox1.Image = Properties.Resources.Sad_Cloud;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.info:
                    this.pictureBox1.Image = Properties.Resources.Info1;
                    this.BackColor = Color.RoyalBlue;
                    break;
            }

            this.lblMsg.Text = msg;

            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }
    }
}
