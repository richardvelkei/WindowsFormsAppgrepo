﻿using ProgramTervezesiMintak_2.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProgramTervezesiMintak_2.Entities
{
    class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            Image x = Image.FromFile("Images/car.png");
            g.DrawImage(x, new Rectangle(0, 0, this.Width, this.Height));
        }

    }
}
