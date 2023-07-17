using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxUI
{
    public struct InteractStyle
    {
        /// <summary>
        /// 表示划分元素是可交互的.
        /// </summary>
        public bool IsInteractive;

        /// <summary>
        /// 表示当前的交互状态.
        /// </summary>
        public bool Interaction;

        /// <summary>
        /// 表示上一帧的交互状态.
        /// </summary>
        public bool InteractionLast;
    }
}
