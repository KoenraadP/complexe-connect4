using System;
using System.Windows.Forms;
using Connect4.Entities;
using Connect4.Bll;
using System.Drawing;

namespace Connect4
{
    public partial class frmConnect4 : Form
    {
        public frmConnect4()
        {
            InitializeComponent();
        }

        // Load --> gebeurt bij het opstarten van de form
        private void FrmConnect4_Load(object sender, EventArgs e)
        {
            // token maken
            Token token = new Token();
            // token een positie geven
            // we zetten hiermee de linker boven hoek van ons token op een specifieke plaats
            // voorbeeld: onderaan rechts
            token.Location = new Point(ClientSize.Width 
                - token.Width, ClientSize.Height - token.Height); // Point zit in System.Drawing
            // token toevoegen aan de form
            // Controls = alle mogelijke elementen die op de form staan
            Controls.Add(token);
        }
    }
}
