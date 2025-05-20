// al deze usings moeten ook bij de references van het project aangevinkt staan
using Connect4.Entities;
using System.Windows.Forms;
using System.Drawing;

namespace Connect4.Bll
{
    // alle velden in mijn speelveld
    // zijn ofwel leeg, ofwel rood, ofwel geel
    public enum FieldState
    {
        Empty, // default waarde
        Red,
        Yellow
    }

    public class Game
    {
        // het speelveld
        public FieldState[,] Grid { get; set; }
        // koppeling met form
        public Form Form { get; set; }

        // constructor
        // we geven bij het aanmaken van een Game
        // ook de form mee om die hierin te kunnen gebruiken
        public Game(Form form)
        {
            // speelveld altijd starten met
            // 6 rijen en 7 kolommen
            Grid = new FieldState[6, 7];
            Form = form;
        }

        // grijze / rode / gele tokens 'tekenen' op de form
        public void DrawTokens()
        {
            // alle standaard lege 'tokens' tekenen
            // dubbele loop: alle rijen overlopen en daarbinnen
            // alle kolommen overlopen
            for (int row = 0; row < Grid.GetLength(0); row ++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    // nieuwe token maken
                    Token token = new Token();
                    // locatie van token instellen
                    // maal 60 omdat er ruimte tussen moet staan
                    // plus 50 omdat we niet tegen de rand willen plakken
                    token.Location = new Point(col * 60 + 50, row * 60 + 50);
                    // token toevoegen aan de form
                    Form.Controls.Add(token);
                }
            }
        }
    }
}
