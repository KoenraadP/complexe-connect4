// deze moeten ook bij de references van het project aangevinkt staan
using System.Windows.Forms;
using System.Drawing;

namespace Connect4.Entities
{
    public class Token : Panel // overerven van Panel (zit in System.Windows.Forms)
    {
        // default constructor maken
        // standaard moet een token vierkant zijn en rood (op dit moment)
        public Token()
        {
            Width = 50;
            Height = 50;
            BackColor = Color.Red; // zit in System.Drawing
        }
    }
}
