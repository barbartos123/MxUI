using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    public class LinearMenuController : DivisionController
    {
        public override void Layout( ref LayoutStyle layout )
        {
            Division currentDiv;
            Division _last = null;
            for( int count = 0; count < Division.Children.Count; count++ )
            {
                currentDiv = Division.Children[count];
                if( _last != null )
                {
                    currentDiv.Layout.Top = _last.Layout.Top + _last.Layout.Height + 6;
                }
                _last = currentDiv;
            }
            _last = null;
            base.Layout( ref layout );
        }
    }
}