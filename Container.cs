using Microsoft.Xna.Framework;
using MxUI.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    public class Container : Division
    {
        public override void OnInit( )
        {
            Interact.IsInteractive = false;
            base.OnInit( );
        }
        public override void OnUpdate( )
        {
            Layout.Width = EngineInfo.Graphics.GraphicsDevice.Viewport.Width;
            Layout.Height = EngineInfo.Graphics.GraphicsDevice.Viewport.Height;
            Seek( )?.Events.Execute( );
            base.OnUpdate( );
        }
    }
}