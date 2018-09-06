using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.UI.UIContent;
using InfinityGame.UI;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Element;
using Microsoft.Xna.Framework;

namespace GameJam_26.Scene.UI
{
    public class BackMenu : UIWindow
    {
        private AnimeButton back;
        private AnimeButton title;
        private AnimeButton exit;
        public BackMenu(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void PreLoadContent()
        {
            back = new AnimeButton(graphicsDevice, this);
            title = new AnimeButton(graphicsDevice, this);
            exit = new AnimeButton(graphicsDevice, this);
            back.Size = new Size(250, 75);
            title.Size = new Size(250, 75);
            exit.Size = new Size(250, 75);
            back.Location = new Point(10, 10);
            title.Location = new Point(10, 95);
            exit.Location = new Point(10, 180);
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            back.Text = GetText("back");
            title.Text = GetText("title");
            exit.Text = GetText("exit");
            back.TextAlign = ContentAlignment.MiddleCenter;
            title.TextAlign = ContentAlignment.MiddleCenter;
            exit.TextAlign = ContentAlignment.MiddleCenter;

            base.LoadContent();
        }
    }
}
