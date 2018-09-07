using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject.Actor;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam_26.Scene.Stage
{
    public class Base_Chara : Character
    {
        public Base_Chara(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            BeAffect = false;
        }
    }
}
