﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAR_2021.Entities;

namespace VAR_2021
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> ticks = new List<Tick>(); 
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();

        public Form1()
        {
            InitializeComponent();
            ticks = context.Tick.ToList();
            dataGridView1.DataSource = ticks;

            CreatePortfolio();

            List<decimal> Nyeresegek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdoDatum = (from x in ticks select x.TradingDay).Min();
            DateTime zaroDatum = new DateTime(2016, 12, 30);
            TimeSpan z = zaroDatum - kezdoDatum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdoDatum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdoDatum.AddDays(i));
                Nyeresegek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var nyeresegekRendezve = (from x in Nyeresegek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyeresegekRendezve[nyeresegekRendezve.Count() / 5].ToString());
        }

        private void CreatePortfolio()
        {
            PortfolioItem p = new PortfolioItem();
            p.Index = "OTP";
            p.Volume = 10;
            Portfolio.Add(p);

            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in ticks
                            where item.Index == x.Index.Trim()
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
