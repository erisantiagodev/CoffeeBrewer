﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefactoredCoffeeBrewer
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        public DateTime dateOfBrewing;
        public Form1()
        {
            InitializeComponent();
        }

        private void startTimer_Click(object sender, EventArgs e)
        {
            timer.Start();

            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = dateOfBrewing.Subtract(DateTime.Now);
            timeRemaining.Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string coffeeDate = Convert.ToString(brewingDate.Value);
            dateOfBrewing = DateTime.Parse(coffeeDate);
            IMessage obj = new Brewing(dateOfBrewing);


            DateTime currentTime = DateTime.Now;
            DateTime userTime = brewingDate.Value;

            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                obj.BeginBrewing();
                obj.EndBrewing();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }
    }
}
