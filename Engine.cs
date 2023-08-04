using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MxUI.Renderers;
using MxUI.Resources;

namespace MxUI
{
    public class Engine : Game
    {
        public RenderTarget2D EngineRt;

        public static Container Container;

        public Engine( )
        {
            EngineInfo.Engine = this;
            EngineInfo.Graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = new TimeSpan( 0, 0, 0, 0, (int)Math.Round( 1000f / 120f ) );
        }

        protected override sealed void Initialize( )
        {
            EngineInfo.Graphics.PreferredBackBufferWidth = 1280;
            EngineInfo.Graphics.PreferredBackBufferHeight = 720;
            EngineInfo.Graphics.ApplyChanges( );
            base.Initialize( );
        }

        protected override sealed void LoadContent( )
        {
            new TextureResource( );
            EngineInfo.SpriteBatch = new SpriteBatch( GraphicsDevice );
            EngineRt = new RenderTarget2D( EngineInfo.Graphics.GraphicsDevice, EngineInfo.ViewWidth, EngineInfo.ViewHeight, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents );
            Window.ClientSizeChanged += ( s, e ) =>
            {
                EngineRt?.Dispose( );
                EngineRt = new RenderTarget2D( EngineInfo.Graphics.GraphicsDevice, EngineInfo.ViewWidth, EngineInfo.ViewHeight, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents );
            };
            DoInitialize( );
            if( Container == null )
                Container = new Container( );
            Container.DoInitialize( );
        }
        public virtual void DoInitialize( ) { }
        protected override sealed void Update( GameTime gameTime )
        {
            EngineInfo.GetInformationFromDevice( gameTime );
            Container.DoUpdate( );
            DoUpdate( );
            base.Update( gameTime );
        }
        public virtual void DoUpdate( ) { }
        protected override sealed void Draw( GameTime gameTime )
        {
            GraphicsDevice.Clear( Color.White );

            GraphicsDevice.SetRenderTarget( EngineRt );
            EngineInfo.SpriteBatch.Begin( SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp );
            Container.DoRender( EngineInfo.SpriteBatch );
            EngineInfo.SpriteBatch.End( );
            DoRender( EngineInfo.SpriteBatch );

            GraphicsDevice.SetRenderTarget( null );
            EngineInfo.SpriteBatch.Begin( SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp );
            EngineInfo.SpriteBatch.Draw( EngineRt , Vector2.Zero , Color.White );
            EngineInfo.SpriteBatch.End( );

            base.Draw( gameTime );
        }
        public virtual void DoRender( SpriteBatch batch ) { }
    }
}