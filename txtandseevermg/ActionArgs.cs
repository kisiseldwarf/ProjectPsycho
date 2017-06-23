using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace txtandseevermg
{
    class ActionArgs : Interface
    {
        //nbBoutons = nb arguments dans la zone par rapport à l'action
        Zone LinkedZone;

        public void majzone(Zone zo)
        {
            LinkedZone = zo;
        }
        public override void Draw(SpriteBatch spriteBatch, SpriteFont princFont)
        {
            LinkedZone.
        }
    }
}
