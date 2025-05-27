// al deze usings moeten ook bij de references van het project aangevinkt staan
using Connect4.Entities;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

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

                    // controleren wat de huidige FieldState is 
                    // van het vakje binnen de Grid array
                    // en op basis daarvan eventueel het kleur
                    // van mijn token aanpassen
                    switch (Grid[row, col])
                    {
                        case FieldState.Red:
                            token.BackColor = Color.Red;
                            break;
                        case FieldState.Yellow:
                            token.BackColor = Color.Yellow;
                            break;
                        // default is in principe niet nodig tenzij
                        // de Token class geen standaard backcolor heeft bij constructor
                        default:
                            token.BackColor = Color.LightGray; // standaard kleur
                            break;
                    }

                    // alternatief
                    /*if (Grid[row, col] == FieldState.Red) token.BackColor = Color.Red;
                    if (Grid[row, col] == FieldState.Yellow) token.BackColor = Color.Yellow;*/                 

                    // locatie van token instellen
                    // maal 60 omdat er ruimte tussen moet staan
                    // plus 50 omdat we niet tegen de rand willen plakken
                    token.Location = new Point(col * 60 + 50, row * 60 + 50);
                    // token toevoegen aan de form
                    Form.Controls.Add(token);
                    // token naar de voorgrond brengen
                    token.BringToFront(); 
                }
            }

            
        }

        // methode om een token te droppen in een bepaalde kolom
        public void DropToken(int col)
        {
            // starten bij de laatste rij van de huidige kolom en 'aftellen'
            // zodat we telkens een rij hoger gaan om te controleren waar het 
            // eerste lege vakje zit van de kolom
            for(int row = Grid.GetLength(0) - 1; row >= 0; row--)
            {
                // als het vakje leeg is, dan kunnen we daar een token plaatsen
                if (Grid[row, col] == FieldState.Empty)
                {
                    // we plaatsen een rode token
                    Grid[row, col] = FieldState.Red; // of Yellow, afhankelijk van de beurt
                    DrawTokens(); // hertekenen van de tokens
                    break; // we stoppen met zoeken naar een lege plaats in deze kolom
                }
            }
        }
    }
}
