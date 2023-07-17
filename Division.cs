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

        /// <summary>
        /// 划分元素的交互样式.
        /// </summary>
        public InteractStyle Interact;

        /// <summary>
        /// 划分元素的设计样式.
        /// </summary>
        public DesignStyle Design;

        /// <summary>
        /// 划分元素的事件.
        /// </summary>
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
        /// 指定划分元素的控制器.
        /// </summary>
        public DivisionController Controller;

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
            Events.Division = this;
            Design.Color = Color.White;
            Interact.IsInteractive = true;
        }

        public void DoInitialize( )
        {
            OnInit( );
            Renderer?.RendererInit( );
            if( Parent != null )
                Layout.Calculate( Parent.Layout );
            for( int count = 0; count < Children.Count; count++ )
                Children[count].DoInitialize( );
        }
        public virtual void OnInit( ) { }
        public void DoUpdate( )
        {
            Interact.InteractionLast = Interact.Interaction;
            if( ContainsPoint( Main.MouseState.Position ) )
                Interact.Interaction = true;
            else
                Interact.Interaction = false;
            Events.IndentExecut( );
            Controller?.Layout( ref Layout );
            if( Parent != null )
                Layout.Calculate( Parent.Layout );
            Controller?.Interact( ref Interact );
            Controller?.Design( ref Design );
            OnUpdate( );
            for( int count = Children.Count - 1; count >= 0; count-- )
                Children[count].DoUpdate( );
        }
        public virtual void OnUpdate( ) { }
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