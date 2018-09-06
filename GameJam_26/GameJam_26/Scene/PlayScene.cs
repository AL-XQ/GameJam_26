using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.GameGraphics;
using InfinityGame.Scene;
using Microsoft.Xna.Framework.Graphics;

using GameJam_26.Scene.Stage;

namespace GameJam_26.Scene
{
    public class PlayScene : StageScene
    {
        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            new Stage01(GraphicsDevice, this, "Stage01");
            base.PreLoadContent();
        }
    }
}
