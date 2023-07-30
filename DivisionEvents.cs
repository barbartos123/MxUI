using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    public class DivisionEvents
    {
        public Division Division;

        public event Action OnMouseLeftClickBefore;

        public event Action OnMouseLeftClickAfter;

        public event Action OnMouseLeftDown;

        public event Action OnMouseLeftUp;

        public event Action InteractionStart;

        public event Action InteractionEnd;

        private MouseState _state;

        private MouseState _stateLast;

        public void Execute( )
        {
            _state = EngineInfo.MouseState;
            _stateLast = EngineInfo.MouseStateLast;

            if( _state.LeftButton == ButtonState.Pressed && _stateLast.LeftButton == ButtonState.Released )
                OnMouseLeftClickBefore?.Invoke( );
            else if( _state.LeftButton == ButtonState.Pressed && _stateLast.LeftButton == ButtonState.Pressed )
                OnMouseLeftDown?.Invoke( );
            else if( _state.LeftButton == ButtonState.Released && _stateLast.LeftButton == ButtonState.Pressed )
                OnMouseLeftClickAfter?.Invoke( );
            else
                OnMouseLeftUp?.Invoke( );
        }

        public void IndentExecut( )
        {
            if( Division.Interact.Interaction && !Division.Interact.InteractionLast )
                InteractionStart?.Invoke( );
            else if( !Division.Interact.Interaction && Division.Interact.InteractionLast )
                InteractionEnd?.Invoke( );
        }
    }
}
