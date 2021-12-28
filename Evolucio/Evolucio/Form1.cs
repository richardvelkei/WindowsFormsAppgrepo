﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsHardestGame;

namespace Evolucio
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        GameArea ga;

        //Induló populáció

        int populationSize = 100;
        int nbrOfSteps = 10;
        int nbrOfStepsIncrement = 10;
        int generation = 1;

        // Gyozteskezeles

        Brain winnerBrain;

        public Form1()
        {
            InitializeComponent();

            gc.GameOver += Gc_GameOver;

            ga = gc.ActivateDisplay();
            this.Controls.Add(ga);
            for (int i = 0; i < populationSize; i++)
            {
                gc.AddPlayer(nbrOfSteps);
            }
            gc.Start();
            
            //gc.AddPlayer();
            //gc.Start(true);


        }

        private void Gc_GameOver(object sender)
        {
            generation++;
            generationLabel.Text = string.Format("{0}. generáció", generation);

            var playerList = from p in gc.GetCurrentPlayers()
                             orderby p.GetFitness() descending
                             select p;
            var topplayers = playerList.Take(populationSize / 2).ToList();

            gc.ResetCurrentLevel();
            foreach (Player p in topplayers)
            {
                Brain b = p.Brain.Clone();
                if (generation % 3 == 0)
                    gc.AddPlayer(b.ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b);

                if (generation % 3 == 0)
                    gc.AddPlayer(b.Mutate().ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b.Mutate());
            }
            gc.Start();

            var winners = from p in topplayers where p.IsWinner select p;
            if (winners.Count() > 0)
            {
                winnerBrain = winners.FirstOrDefault().Brain.Clone();
                gc.GameOver -= Gc_GameOver;
                startBtn.Visible = true;
                return;
            }

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            gc.ResetCurrentLevel();
            gc.AddPlayer(winnerBrain.Clone());
            gc.AddPlayer();
            ga.Focus();
            gc.Start(true);
        }
    }
}
