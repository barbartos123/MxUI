using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    public class DivisionController
    {
        public Division Division;

        public virtual void Layout( ref LayoutStyle layout ) { }
        public virtual void Interact( ref InteractStyle interact ) { }
        public virtual void Design( ref DesignStyle design ) { }
    }
}