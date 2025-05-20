using System;
using System.Windows.Forms;
using Connect4.Entities;
using Connect4.Bll;
using System.Drawing;
using System.Diagnostics;

namespace Connect4
{
    public partial class frmConnect4 : Form
    {
        // Game property
        public Game Game { get; set; }

        public frmConnect4()
        {
            InitializeComponent();
        }

        // Load --> gebeurt bij het opstarten van de form
        private void FrmConnect4_Load(object sender, EventArgs e)
        {
            StartGame();
            GenerateButtons();
            // testen of game grid werkt
            Debug.WriteLine(Game.Grid[0, 0]); // in het Output tabblad zou Empty moeten verschijnen
        }

        // spel opstarten
        private void StartGame()
        {
            // huidige form waarin we werken = this
            Game = new Game(this);
            // empty token vakjes tekenen
            Game.DrawTokens();
        }

        // code om de buttons te maken
        private void GenerateButtons()
        {
            //Button button = new Button();
            //button.Size = new Size(50, 30);
            //button.Location = new Point(50, 10);
            //Controls.Add(button);

            // loop die loopt vanaf 0 tot aan het aantal kolommen van mijn grid
            for (int i = 0; i < Game.Grid.GetLength(1); i++)
            {
                Button button = new Button();
                button.Size = new Size(50, 30);
                // naam button instellen met op het einde het huidige kolom cijfer
                button.Name = "btnCol" + i;
                // plaats dynamisch instellen op basis van kolom
                button.Location = new Point(i * 60 + 50, 10);

                // click event toevoegen aan button
                button.Click += Button_Click;

                // effectief tonen op form
                Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // sender = waarop we geklikt hebben
            // maar staat standaard als 'object' ingesteld
            // dus moeten we casten naar Button
            string buttonName = ((Button)sender).Name;
            // buttonName bestaat uit 7 letters, dus de length is 7
            // met substring wil ik vanaf karakter 6 (de 7de letter) tot aan het einde van de string
            string colNumber = buttonName.Substring(buttonName.Length-1);

            MessageBox.Show($"Je hebt op kolom {colNumber} geklikt!");
        }
    }
}
