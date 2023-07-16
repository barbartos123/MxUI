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

        /// <summary>
        /// 划分元素本身的宽度.
        /// </summary>
        public int Width;

        /// <summary>
        /// 划分元素本身的高度.
        /// </summary>
        public int Height;

        public Rectangle HitBox => new Rectangle( Left, Top, Width, Height );
        public Rectangle TotalHitBox => new Rectangle( TotalLeft, TotalTop, Width, Height );

        public void Calculate( LayoutStyle parent )
        {
            TotalLeft = parent.TotalLeft + Left;
            TotalTop = parent.TotalTop + Top;

        }
    }
}