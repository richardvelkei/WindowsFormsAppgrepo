using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppgrepo.Entities;

namespace WindowsFormsAppgrepo
{
    public partial class Form1 : Form
    {
        BindigList<User> users = new BindigList<User>();

        public Form1()
        {
            InitializeComponent();
            lastname.Text = Resource1.Lastname;
            firstname.Text = Resource1.Firstname;
            btnadd.Text = Resource1.Add;

           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
