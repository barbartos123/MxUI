﻿using Microsoft.Xna.Framework;
using MxUI.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    public class Container : Division
    {
        public Division Button;

        public Division List;

        public override void OnInit( )
        {
            Interact.IsInteractive = false;
            Button = new Division( );
            NineCutRenderer renderer = Button.BindRenderer<NineCutRenderer>( );
            renderer.Texture = Main.Button;
            renderer.Cut = 4;
            Button.Layout.Width = 128;
            Button.Layout.Height = 64;
            Button.Layout.Left = 64;
            Button.Layout.Top = 64;
            Button.Events.OnMouseLeftUp += ( ) =>
            {
                Button.Design.Color = Color.White;
            };
            Button.Events.OnMouseLeftDown += ( ) =>
            {
                Button.Design.Color = Color.Gray;
            };
            Register( Button );

            List = new Division( );
            List.Controller = new LinearMenuController( );
            List.Controller.Division = List;
            List.Layout.Left = Button.Layout.Left + Button.Layout.Width + 64;
            List.Layout.Top = 64;
            Division div;
            for( int count = 0; count < 4; count++ )
            {
                div = new Division( );
                div.Layout.Width = 96;
                div.Layout.Height = 32;
                div.BindRenderer<PixelRenderer>( );
                div.Events.OnMouseLeftClickBefore += ( ) => { Console.WriteLine( "Menu's button is click." ); };
                List.Register( div );
            }
            Register( List );

            base.OnInit( );
        }
        public override void OnUpdate( )
        {
            Layout.Width = Main.Graphics.GraphicsDevice.Viewport.Width;
            Layout.Height = Main.Graphics.GraphicsDevice.Viewport.Height;
            Seek( )?.Events.Execute( );
            base.OnUpdate( );
        }
    }
}