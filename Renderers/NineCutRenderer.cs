using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MxUI.Renderers
{
    public class NineCutRenderer : DivisionRenderer
    {
        public Texture2D Texture;
        public int Cut = 0;
        public override void RendererInit( ) { }
        public override void Render( SpriteBatch batch )
        {
            batch.DrawNineCut( Texture , Division.Design.Color , Division.Layout.TotalHitBox , Cut , 1f );
        }
    }
}