using System;
using Microsoft.Xna.Framework;

namespace MxUI
{
    public static class VectorEx
    {
        public static Vector2 Closer( this ref Vector2 current, Vector2 target, float i, float maxi )
        {
            float x = current.X;
            float y = current.Y;
            float tx = target.X;
            float ty = target.Y;
            x *= maxi - i;
            x /= maxi;
            y *= maxi - i;
            y /= maxi;
            tx *= i;
            tx /= maxi;
            ty *= i;
            ty /= maxi;
            current = new Vector2( x + tx, y + ty );
            return new Vector2( x + tx, y + ty );        }
    }
    public class VectorGradienter
    {
        public Vector2 Default;
        public Vector2 Current;
        public Vector2 Target;
        public void Set( Vector2 vector )
        {
            Default = vector;
            Current = vector;
            Target = vector;
        }
        public float Time;
        public float Timer;
        private bool _start;
        private float _currentValue;
        public Vector2 Update( )
        {
            if( _start )
            {
                Timer += (float)EngineInfo.GameTime.ElapsedGameTime.TotalSeconds;
                if( Timer <= Time )
                {
                    _currentValue = Timer / Time;
                    Current.Closer( Target, _currentValue, 1f );
                }
            }
            if( Timer > Time )
            {
                Current = Target;
                _start = false;
                Timer = 0;
            }
            return Current;
        }
        public void Start( )
        {
            Current = Default;
            Timer = 0;
            _start = true;
        }
        public void Stop( )
        {
            _start = false;
            Timer = 0;
        }
    }
}