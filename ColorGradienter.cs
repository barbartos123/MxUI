using System;
using Microsoft.Xna.Framework;

namespace MxUI
{
    public static class ColorEx
    {
        /// <summary>
        /// 对颜色进行线性插值.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="i"></param>
        /// <param name="maxi"></param>
        /// <returns></returns>
        public static Color Closer( this ref Color current, Color target, float i, float maxi )
        {
            float r = current.R;
            float g = current.G;
            float b = current.B;
            float a = current.A;
            float tr = target.R;
            float tg = target.G;
            float tb = target.B;
            float ta = target.A;
            r *= maxi - i;
            r /= maxi;
            g *= maxi - i;
            g /= maxi;
            b *= maxi - i;
            b /= maxi;
            a *= maxi - i;
            a /= maxi;
            tr *= i;
            tr /= maxi;
            tg *= i;
            tg /= maxi;
            tb *= i;
            tb /= maxi;
            ta *= i;
            ta /= maxi;
            current = new Color( (int)(r + tr), (int)(g + tg), (int)(b + tb), (int)(a + ta) );
            return new Color( (int)(r + tr), (int)(g + tg), (int)(b + tb), (int)(a + ta) );
        }
    }
    public class ColorGradienter
    {
        public Color Default;
        public Color Current;
        public Color Target;
        public void Set( Color color )
        {
            Default = color;
            Current = color;
            Target = color;
        }
        public float Time;
        public float Timer;
        private bool _start;
        private float _currentValue;
        public Color Update( )
        {
            if( _start )
            {
                Timer += (float)EngineInfo.GameTime.ElapsedGameTime.TotalSeconds;
                if ( Timer <= Time )
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