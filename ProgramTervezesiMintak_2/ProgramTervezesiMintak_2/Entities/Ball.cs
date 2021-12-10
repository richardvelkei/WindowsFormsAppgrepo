﻿using ProgramTervezesiMintak_2.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTervezesiMintak_2.Entities
{
    public class Ball : Toy
    {
        /*
        public Ball()
        {
            AutoSize = false;
            Width = Height = 50;
            Paint += Ball_Paint;
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }*/

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), 0, 0, Width, Height);
        }
        /*
        public void MoveBall()
        {
            Left++;
        }
        */
    }
}
