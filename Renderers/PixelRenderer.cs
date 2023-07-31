using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MxUI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI.Renderers
{
    public class PixelRenderer : DivisionRenderer
    {
        public override void RendererInit( ) { }
        public override void Render( SpriteBatch batch )
        {
            batch.Draw( TextureResource.Get( "Pixel" ),
                Division.Layout.TotalLocationF + Division.Design.Anchor,
                Division.Layout.TotalHitBox,
                Division.Design.Color,
                0f,
                Division.Design.Anchor,
                Division.Design.Scale,
                SpriteEffects.None, 1f );
        }
    }
}