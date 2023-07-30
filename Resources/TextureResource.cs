using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MxUI.Resources
{
    public class TextureResource
    {
        public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>( );

        public static Texture2D Get( string path )
        {
            string _temp = string.Concat( "Textures\\" , path );
            if( Textures.TryGetValue( _temp , out Texture2D result ) )
                return result;
            else
                return null;
        }
        public TextureResource( )
        {
            string _temp;
            string[ ] _texturePaths = Directory.GetFiles( string.Concat( EngineInfo.Engine.Content.RootDirectory, "\\Textures" ), "*.*", SearchOption.AllDirectories );
            Texture2D _texture;
            foreach( var path in _texturePaths )
            {
                _temp = path.Replace( ".xnb", "" ).Replace( "Content\\", "" );
                _texture = EngineInfo.Engine.Content.Load<Texture2D>( _temp );
                 Textures.Add( _temp , _texture );
            }
        }
    }
}