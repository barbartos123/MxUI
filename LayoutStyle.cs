using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    /// <summary>
    /// 为划分元素指定布局样式.
    /// </summary>
    public struct LayoutStyle
    {
        /// <summary>
        /// 划分元素相对于父元素的左侧距离.
        /// </summary>
        public int Left;
        /// <summary>
        /// 划分元素相对于屏幕的左侧距离.
        /// </summary>
        public int TotalLeft;

        /// <summary>
        /// 划分元素相对于父元素的顶侧距离.
        /// </summary>
        public int Top;
        /// <summary>
        /// 划分元素相对于屏幕的顶侧距离.
        /// </summary>
        public int TotalTop;

        public Point Location => new Point( Left , Top );
        public Vector2 LocationF => new Vector2( Left, Top );

        public Point TotalLocation => new Point( TotalLeft, TotalTop );
        public Vector2 TotalLocationF => new Vector2( TotalLeft, TotalTop );

        public Matrix CanvasMatrix =>
            Matrix.CreateTranslation( new Vector3( -TotalLocationF, 0 ) ) *
            Matrix.CreateScale( 1f ) *
            Matrix.CreateRotationZ( 0f ) *
            Matrix.CreateTranslation( Vector3.Zero );

        /// <summary>
        /// 划分元素本身的宽度.
        /// </summary>
        public int Width;

        /// <summary>
        /// 划分元素本身的高度.
        /// </summary>
        public int Height;

        public Point Size => new Point( Width , Height );
        public Vector2 SizeF => new Vector2( Width , Height );

        public Point Half => new Point( Width / 2, Height / 2 );
        public Vector2 HalfF => new Vector2( Width / 2, Height / 2 );

        public Rectangle HitBox => new Rectangle( Left, Top, Width, Height );
        public Rectangle TotalHitBox => new Rectangle( TotalLeft, TotalTop, Width, Height );

        public void Calculate( LayoutStyle parent )
        {
            TotalLeft = parent.TotalLeft + Left;
            TotalTop = parent.TotalTop + Top;
        }
    }
}