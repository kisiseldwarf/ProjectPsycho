using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace txtandseevermg
{
    class Menu : Interface
    {
        public Menu()
        {
            nbboutons = 4;
            Boutons = new string[nbboutons];
            boutons[0] = "Act";
            boutons[1] = "Move";
            boutons[2] = "Take";
            boutons[3] = "look";
        }
        public override void Draw(SpriteBatch spriteBatch, SpriteFont princFont)
        {
            for (int i = 0; i < Nbboutons; i++) //Dessin des boutons des actions
            {
                spriteBatch.DrawString(princFont, Boutons[i], new Vector2(102 + boutons[i].Length + i * 70, 430), Color.Gray); //Dessiner les boutons non selectionnés en gris
                if (i == FocusBoutons) //Dessiner le bouton selectionné en blanc
                {
                    spriteBatch.DrawString(princFont, Boutons[i], new Vector2(102 + i * 70 + Boutons[i].Length, 430), Color.WhiteSmoke);
                }
            }
        }
    }
}
