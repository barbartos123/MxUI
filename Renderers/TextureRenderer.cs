﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI.Renderers
{
    public class TextureRenderer : DivisionRenderer
    {
        public Texture2D Texture;
        public override void RendererInit( ) { }
        public override void Render( SpriteBatch batch )
        {
            if( Texture != null )
                batch.Draw( Texture, Division.Layout.TotalLocationF + Division.Design.Anchor, null, Division.Design.Color, 0f, Division.Design.Anchor, Division.Design.Scale, SpriteEffects.None, 1f );
        }
    }
}