using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public override bool IsCanvas => base.IsCanvas;
        public override void OnInit( )
        {
            Interact.IsInteractive = false;
            Layout.Width = EngineInfo.Graphics.GraphicsDevice.Viewport.Width;
            Layout.Height = EngineInfo.Graphics.GraphicsDevice.Viewport.Height;
            EngineInfo.Engine.Window.ClientSizeChanged += Window_ClientSizeChanged;
            base.OnInit( );
        }

        private void Window_ClientSizeChanged( object sender, EventArgs e )
        {
            Layout.Width = EngineInfo.Graphics.GraphicsDevice.Viewport.Width;
            Layout.Height = EngineInfo.Graphics.GraphicsDevice.Viewport.Height;
            Canvas?.Dispose( );
            Canvas = new RenderTarget2D( EngineInfo.Graphics.GraphicsDevice, Layout.Width, Layout.Height, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents );
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