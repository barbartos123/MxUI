using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MxUI.Renderers;

namespace MxUI
{
    public class Main : Game
    {
        public static GraphicsDeviceManager Graphics;

        public static SpriteBatch SpriteBatch;

        public static Texture2D Pixel;

        public static Texture2D Button;

        public static Texture2D ScaleTest;

        public static MouseState MouseState = new MouseState( );

        public static MouseState MouseStateLast = new MouseState( );

        public static Container Container = new Container( );

        public static GameTime GameTime;

        public Main( )
        {
            Graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize( )
        {
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges( );
            base.Initialize( );
        }

        protected override void LoadContent( )
        {
            SpriteBatch = new SpriteBatch( GraphicsDevice );
            Pixel = Content.Load<Texture2D>( "Pixel" );
            Button = Content.Load<Texture2D>( "Button" );
            ScaleTest = Content.Load<Texture2D>( "ScaleTest" );

            Container.DoInitialize( );
        }
        protected override void Update( GameTime gameTime )
        {
            MouseStateLast = MouseState;
            MouseState = Mouse.GetState( );
            GameTime = gameTime;
            Container.DoUpdate( );
            base.Update( gameTime );
        }
        protected override void Draw( GameTime gameTime )
        {
            GraphicsDevice.Clear( Color.Black );
            SpriteBatch.Begin( SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp );
            Container.DoRender( SpriteBatch );
            SpriteBatch.End( );
            base.Draw( gameTime );
        }
    }
}