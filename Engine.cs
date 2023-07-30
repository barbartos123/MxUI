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
        public static Container Container;

        public Engine( )
        {
            EngineInfo.Graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = new TimeSpan( 0, 0, 0, 0, (int)Math.Round( 1000f / 120f ) );
        }

        protected override void Initialize( )
        {
            EngineInfo.Graphics.PreferredBackBufferWidth = 1280;
            EngineInfo.Graphics.PreferredBackBufferHeight = 720;
            EngineInfo.Graphics.ApplyChanges( );
            base.Initialize( );
        }

        protected override void LoadContent( )
        {
            new TextureResource( );
            EngineInfo.SpriteBatch = new SpriteBatch( GraphicsDevice );
            Container.DoInitialize( );
        }
        protected override void Update( GameTime gameTime )
        {
            EngineInfo.GetInformationFromDevice( gameTime );
            Container.DoUpdate( );
            base.Update( gameTime );
        }
        protected override void Draw( GameTime gameTime )
        {
            GraphicsDevice.Clear( Color.Black );
            EngineInfo.SpriteBatch.Begin( SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp );
            Container.DoRender( EngineInfo.SpriteBatch );
            EngineInfo.SpriteBatch.End( );
            base.Draw( gameTime );
        }
    }
}