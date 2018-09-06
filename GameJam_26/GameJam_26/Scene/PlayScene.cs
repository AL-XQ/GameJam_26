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
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using Microsoft.Xna.Framework;
using InfinityGame.Element;
using GameJam_26.Scene.UI;
namespace GameJam_26.Scene
{
    public class PlayScene : StageScene
    {
        private UIWindow ending;
        private BackMenu backMenu;

       
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
            ending = new UIWindow(graphicsDevice, this);
            ending.Size = new Size(size.Width * 4 / 5, size.Height * 2 / 3);
            ending.Location = (size / 2 - ending.Size / 2).ToPoint();
            backMenu = new BackMenu(graphicsDevice, this);
            backMenu.Size = new Size(size.Width/5,size.Height/2);
            backMenu.Location = (size / 2 - backMenu.Size / 2).ToPoint();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            backMenu.Text = GetText("backMenu");
            base.LoadContent();
        }

    }
}
