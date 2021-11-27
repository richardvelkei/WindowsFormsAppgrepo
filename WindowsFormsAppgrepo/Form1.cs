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
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            lastname.Text = Resource1.Lastname;
            firstname.Text = Resource1.Firstname;
            btnadd.Text = Resource1.Add;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.LastName = lastnamebox.Text;
            u.FirstName = firstnamebox.Text;
            users.Add(u);
        }
    }
}
