using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    /// <summary>
    /// 划分元素.
    /// </summary>
    public class Division
    {
        /// <summary>
        /// 划分元素的布局样式.
        /// </summary>
        public LayoutStyle Layout;

        public InteractStyle Interact;

        /// <summary>
        /// 划分元素的设计样式.
        /// </summary>
        public DesignStyle Design;

        public DivisionEvents Events;

        /// <summary>
        /// 该划分元素的父元素.
        /// </summary>
        public Division Parent;

        /// <summary>
        /// 该划分元素的子元素列表.
        /// </summary>
        public List<Division> Children = new List<Division>( );

        /// <summary>
        /// 指定划分元素的渲染器.
        /// </summary>
        public DivisionRenderer Renderer;
        /// <summary>
        /// 绑定渲染器.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T BindRenderer<T>( ) where T : DivisionRenderer, new()
        {
            Renderer = new T( );
            Renderer._division = this;
            return (T)Renderer;
        }

        public Division( )
        {
            Events = new DivisionEvents( );
            Design.Color = Color.White;
        }

        public void DoUpdate( )
        {
            if( Parent != null )
                Layout.Calculate( Parent.Layout );
            if( ContainsPoint( Game1.MouseState.Position ) )
                Interact.Interaction = true;
            else
                Interact.Interaction = false;
            for( int count = 0; count < Children.Count; count++ )
                Children[count].DoUpdate( );
        }
        public void DoRender( SpriteBatch batch )
        {
            Renderer?.Render( batch );
            for( int count = 0; count < Children.Count; count++ )
                Children[count].DoRender( batch );
        }
        public bool Register( Division div )
        {
            if( div.Parent != null || Children.Contains( div ) )
                return false;
            div.Parent = this;
            Children.Add( div );
            return true;
        }

        /// <summary>
        /// 寻找当前最先可交互的元素.
        /// </summary>
        /// <returns></returns>
        public Division Seek( )
        {
            Division result = null;
            for( int count = Children.Count - 1; count >= 0; count-- )
            {
                result = Children[count].Seek( );
                if( result != null )
                    return result;
            }
            if( Interact.IsInteractive && Interact.Interaction )
            {
                result = this;
            }
            return result;
        }

        public bool ContainsPoint( Point point ) => Layout.TotalHitBox.Contains( point );
    }
}