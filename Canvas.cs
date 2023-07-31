using System;
using System.Collections.Generic;
using System.Text;

namespace MxUI
{
    public class Canvas : Division
    {
        public override sealed bool IsCanvas => true;
        public override void OnInit( )
        {
            Design.Anchor = Layout.HalfF;
            base.OnInit( );
        }
    }
}