using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MxUI
{
    public class ScaleController : DivisionController
    {
        public bool Open = false;
        public bool Close = false;

        public float OpenTime = 0.08f;
        public float OpenTimer;

        public float CloseTime = 0.06f;
        public float CloseTimer;

        public override void Design( ref DesignStyle design )
        {
            float delta = (float)EngineInfo.GameTime.ElapsedGameTime.TotalSeconds;
            if( Open )
            {
                Close = false;
                if( OpenTimer < OpenTime )
                {
                    OpenTimer += delta;
                    design.Scale = Vector2.One * (0.7f + 0.3f * OpenTimer / OpenTime );
                }
                else
                {
                    Open = false;
                    OpenTimer = 0;
                    design.Scale = Vector2.One;
                }
            }
            if( Close )
            {
                Open = false;
                if( CloseTimer < CloseTime )
                {
                    CloseTimer += delta;
                    design.Scale = Vector2.One * (1f - 0.3f * CloseTimer / CloseTime);
                }
                else
                {
                    Close = false;
                    CloseTimer = 0;
                    design.Scale = Vector2.One * 0.7f;
                }
            }
            base.Design( ref design );
        }
    }
}