using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MxUI.Renderers;

namespace MxUI
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager Graphics;

        public static SpriteBatch SpriteBatch;

        public static Texture2D Pixel;

        public static MouseState MouseState = new MouseState( );

        public static MouseState MouseStateLast = new MouseState( );

        public Game1( )
        {
            Graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        Division Substrate;

        Division Form;

        Division Button;

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

            Substrate = new Division( );
            Substrate.Interact.IsInteractive = true;
            Substrate.Events.OnMouseLeftClickAfter += Events_OnMouseLeftClickAfter1;

            Form = new Division( );
            Form.Layout.Left = 96;
            Form.Layout.Top = 96;
            Form.Layout.Width = 500;
            Form.Layout.Height = 300;
            Form.Design.Color = Color.DarkBlue;
            Form.BindRenderer<PixelRenderer>( );

            Button = new Division( );
            Button.Layout.Left = 96;
            Button.Layout.Top = 96;
            Button.Layout.Width = 128;
            Button.Layout.Height = 64;
            Button.Interact.IsInteractive = true;
            Button.Design.Color = Color.Orange;
            Button.BindRenderer<PixelRenderer>( );
            Button.Events.OnMouseLeftClickAfter += Events_OnMouseLeftClickAfter;

            Substrate.Register( Form );
            Form.Register( Button );

            // TODO: use this.Content to load your game content here
        }

        private void Events_OnMouseLeftClickAfter1( )
        {
            Console.WriteLine( "Substrate 被单击了" );
        }

        private void Events_OnMouseLeftClickAfter( )
        {
            Console.WriteLine( "Button 被单击了" );
        }

        protected override void Update( GameTime gameTime )
        {
            Substrate.Layout.Width = Graphics.GraphicsDevice.Viewport.Width;
            Substrate.Layout.Height = Graphics.GraphicsDevice.Viewport.Height;

            MouseStateLast = MouseState;
            MouseState = Mouse.GetState( );



            if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState( ).IsKeyDown( Keys.Escape ) )
                Exit( );

            Substrate.DoUpdate( );

            Substrate.Seek( )?.Events.Execute( );

            base.Update( gameTime );
        }
        protected override void Draw( GameTime gameTime )
        {
            GraphicsDevice.Clear( Color.Black );

            SpriteBatch.Begin( SpriteSortMode.Deferred, BlendState.AlphaBlend );
            Substrate.DoRender( SpriteBatch );
            SpriteBatch.End( );
            // TODO: Add your drawing code here

            base.Draw( gameTime );
        }
    }
}