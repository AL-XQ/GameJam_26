using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameJam_26.Scene.Stage
{
    public class BaseItem : StageObj
    {
        public BaseItem(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {

        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void PreLoadContent()
        {

            base.PreLoadContent();
        }
        

    }
}
