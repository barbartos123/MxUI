using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    public abstract class DivisionRenderer
    {
        internal Division _division;
        public Division Division => _division;
        public abstract void RendererInit( );
        public abstract void Render( SpriteBatch batch );
    }
}