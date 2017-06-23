using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtandseevermg
{
    class Interface
    {
        protected string[] boutons; //Un nombre N de boutons
        protected int nbboutons;
        protected int focusBoutons;

        public Interface(int nbboutons)
        {
            Boutons = new string[nbboutons];
            focusBoutons = 0;
            this.Nbboutons = nbboutons;
        }

        public Interface()
        {

        }

        public string Nom { get => nom; set => nom = value; }
        public string[] Boutons { get => boutons; set => boutons = value; }
        public int Nbboutons { get => nbboutons; set => nbboutons = value; }
        public int FocusBoutons { get => focusBoutons; set => focusBoutons = value; }

        public virtual void Draw(SpriteBatch spriteBatch, SpriteFont princFont)
        {
            //Redéfinies dans les classes filles

        }
        public void majNbBoutons(int nb)
        {
            nbboutons = nb;
            boutons = new string[nbboutons];

        }

    }

}
