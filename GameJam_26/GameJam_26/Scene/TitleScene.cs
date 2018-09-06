using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.GameGraphics;
using InfinityGame.Scene;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using InfinityGame.Element;

using GameJam_26.Scene.UI;

namespace GameJam_26.Scene
{
    public class TitleScene : BaseScene
    {
        private MainMenu mainMeun;
        

        public TitleScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            mainMeun = new MainMenu(graphicsDevice, this);
            mainMeun.Size = new Size(size.Width / 5, size.Height / 2);
            mainMeun.Location = (size / 2 - mainMeun.Size / 2).ToPoint();
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            mainMeun.Text = GetText("mainMendragonu");
            base.LoadContent();
        }
    }
}
