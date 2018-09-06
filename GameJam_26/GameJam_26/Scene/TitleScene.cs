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
using InfinityGame.Device;

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
            mainMeun.Size = new Size(size.Width * 2 / 7, size.Height / 3);
            mainMeun.Location = new Point(size.Width / 2 - mainMeun.Size.Width / 2, size.Height * 2 / 3);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            mainMeun.Text = GetText("mainMenu");
            image = ImageManage.GetSImage("titlescene.jpg");
            base.LoadContent();
        }
    }
}
