using Olympics.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Olympics
{
    public partial class Form1 : Form
    {
        List<OlympicsResult> results = new List<OlympicsResult>();
        public Form1()
        {
            InitializeComponent();
            FileLoader("Summer_olympic_Medals.csv");
            ComboFeltolt();
            Osztalyozas();
            dataGridView1.DataSource = results;

        }

        private void Osztalyozas()
        {
            foreach (OlympicsResult item in results)
            {
                item.Position = Helyezes(item);
            }
        }

        int Helyezes(OlympicsResult res) 
        {
            int counter = 0;
            var szurt = from x in results where x.Year == res.Year && x.Country != res.Country select x;
            foreach (OlympicsResult item in szurt)
            {
                if (item.Medals[0] > res.Medals[0]) counter++;
                else if ((item.Medals[0] == res.Medals[0]) && (item.Medals[1] > res.Medals[1])) counter++;
                else if ((item.Medals[0] == res.Medals[0]) && (item.Medals[1] == res.Medals[1]) && (item.Medals[2] > res.Medals[2])) counter++;
            }
            return counter + 1;
        }

        private void ComboFeltolt()
        {
            var years = (from x in results orderby x.Year select x.Year).Distinct();
            cbxEv.DataSource = years.ToList();
        }

        void FileLoader(string fajlnev)
        {
            using (StreamReader sr = new StreamReader(fajlnev))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] mezok = sor.Split(',');
                    OlympicsResult or = new OlympicsResult();
                    or.Year = int.Parse(mezok[0]);
                    or.Country = mezok[3];
                    int[] mtomb = new int[3];
                    mtomb[0] = int.Parse(mezok[5]);
                    mtomb[1] = int.Parse(mezok[6]);
                    mtomb[2] = int.Parse(mezok[7]);
                    or.Medals = mtomb;
                    results.Add(or);

                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // javítani!
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheets;

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheets = xlWB.ActiveSheet;

                ExcelFeltolt();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlWB = null;
            }

        }

        private void ExcelFeltolt()
        {
            var headers = new string[]
            {
             "Helyezés",
             "Ország",
             "Arany",
             "Ezüst",
             "Bronz"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheets.Cells[1, i + 1] = headers[i];
            }

            var filteredResult = from x in results where x.Year == (int)cbxEv.SelectedItem orderby x.Position select x;
            int aktsor = 2;
            foreach (var item in filteredResult)
            {
                xlSheets.Cells[aktsor, 1] = item.Position;
                xlSheets.Cells[aktsor, 2] = item.Country;
                for (int i = 0; i < 3; i++)
                {
                    xlSheets.Cells[aktsor, 3 + i] = item.Medals[i];
                }
                aktsor++;
            }
        }

        private void cbxEv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filteredResult = from x in results where x.Year == (int)cbxEv.SelectedItem select x;
            dataGridView1.DataSource = filteredResult.ToList();
        }
    }
}
