using ProgramTervezesiMintak_2.Abstract;
using ProgramTervezesiMintak_2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ProgramTervezesiMintak_2
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        private IToyFactory ballFactory;

        public IToyFactory Factory
        {
            get { return ballFactory; }
            set { ballFactory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy b = Factory.CreateNew();
            _toys.Add(b);
            b.Left = -b.Width;
            panel1.Controls.Add(b);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            if (_toys.Count == 0) return;
            Toy lastToy = _toys[0];

            foreach (Toy item in _toys)
            {
                item.MoveToy();
                if (item.Left > lastToy.Left) lastToy = item;
            }
            if (lastToy.Left > 1000)
            {
                _toys.Remove(lastToy);
                panel1.Controls.Remove(lastToy);
            }

        }

        private void btnBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }
    }
}
