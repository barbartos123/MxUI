using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI.Renderers
{
    public class PixelRenderer : DivisionRenderer
    {
        public override void RendererInit( )
        {

        }
        public override void Render( SpriteBatch batch )
        {
            batch.Draw( Game1.Pixel, Division.Layout.TotalHitBox, null, Division.Design.Color, 0f, Vector2.Zero, SpriteEffects.None, 1f );
        }
    }
}