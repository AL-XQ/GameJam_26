using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam_26.Scene.Stage
{
    public class Base_Stage : BaseStage
    {
        public Base_Stage(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            EndOfLeftUp = new Point(0, 0);
            EndOfRightDown = new Point(1920, 1080);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void PreLoadContent()
        {
            
        }
        public override void LoadContent()
        {

        }
    }
}
