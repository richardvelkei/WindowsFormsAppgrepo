using Mikroszimulacio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroszimulacio
{
    public partial class Form1 : Form
    {
        List<Person> Population;
        List<BirthProbabilities> BirthProbabilities;
        List<DeathProbabilities> DeathProbabilities;

        Random rng = new Random(1234);


        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Users\richa\source\repos\WindowsFormsAppgrepo\Mikroszimulacio\Mikroszimulacio\Files\nép-teszt.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Users\richa\source\repos\WindowsFormsAppgrepo\Mikroszimulacio\Mikroszimulacio\Files\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Users\richa\source\repos\WindowsFormsAppgrepo\Mikroszimulacio\Mikroszimulacio\Files\halál.csv");

            Simulation();

        }

        private void Simulation()
        {
            for (int year = 2005; year < 2024; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SzimulacioLepes(Population[i], year);
                }

                int ferfiakszama = (from x in Population where x.Gender == Gender.Male select x).Count();
                int nokszama = (from x in Population where x.Gender == Gender.Female select x).Count();

                Console.WriteLine(string.Format("Év: {0} Férfiak: {1} Nők: {2}", year, ferfiakszama, nokszama));

            }
        }

        private void SzimulacioLepes(Person person, int year)
        {
            if (!person.IsAlive) return;

            int kor = year - person.BirthYear;

            double halalvaloszinuseg = (from x in DeathProbabilities where x.Gender == person.Gender && x.Age == year select x.P).FirstOrDefault();
            double veletlen = rng.NextDouble();

            if (veletlen <= halalvaloszinuseg)
                person.IsAlive = false;

            if (person.IsAlive && person.Gender == Gender.Female)
            {
                double szuletesvalszinuseg = (from x in BirthProbabilities where x.Age == year select x.P).FirstOrDefault();
                veletlen = rng.NextDouble();
                if (veletlen <= szuletesvalszinuseg)
                {
                    Person baba = new Person();
                    baba.BirthYear = year;
                    baba.NbrOfChildren = 0;
                    baba.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(baba);
                }
            }
        }

        public List<BirthProbabilities> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbabilities> result = new List<BirthProbabilities>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    String[] items = line.Split(';');
                    Person p = new Person();
                    p.BirthYear = int.Parse(items[0]);
                    p.Gender = (Gender)Enum.Parse(typeof(Gender), items[1]);
                    p.NbrOfChildren = int.Parse(items[2]);
                    result.Add(p);
                }
            }

            return result;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Simulation((int)numericUpDown1.Value, nepessegBox.Text);
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) richTextBox1.Text = ofd.FileName;
        }

        /*public List<BirthProbabilities> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbabilities> result = new List<BirthProbabilities>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    String[] items = line.Split(';');
                    BirthProbabilities p = new BirthProbabilities();
                    p.Age = int.Parse(items[0]);
                    p.NbrOfChildren = int.Parse(items[1]);
                    p.P = int.Parse(items[2]);
                    result.Add(p);
                }
            }
        
        }*/

    }
}
