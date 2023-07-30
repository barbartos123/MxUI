using System;
using System.Collections.Generic;
using System.Text;

namespace MxUI.Resources
{
    public abstract class Resource<T> where T : class
    {
        public abstract T Get( string path );
    }
}