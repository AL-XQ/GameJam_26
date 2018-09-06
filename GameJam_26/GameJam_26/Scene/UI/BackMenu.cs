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
using InfinityGame;
using InfinityGame.Device;

namespace GameJam_26.Scene.UI
{
    public class BackMenu : UIWindow
    {
        private AnimeButton back;
        private AnimeButton title;
        private AnimeButton exit;
        public BackMenu(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
            //visible = false;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        private void RegistEvent()
        {
            title.Click += Title;
            exit.Click += Exit;
            back.Click += Back;
        }
        public override void PreLoadContent()
        {
            back = new AnimeButton(graphicsDevice, this);
            title = new AnimeButton(graphicsDevice, this);
            exit = new AnimeButton(graphicsDevice, this);
            back.Size = new Size(Size.Width * 4 / 5, Size.Height * 1 / 4);
            title.Size = back.Size;
            exit.Size = back.Size;
            back.Location = new Point(size.Width / 2 - back.Size.Width / 2, 60);
            title.Location = back.Location + new Point(0,back.Size.Height+10);
            exit.Location = title.Location + new Point(0,title.Size.Height+10);

            RegistEvent();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            back.Text = GetText("Back");
            title.Text = GetText("Title");
            exit.Text = GetText("Exit");
            back.TextAlign = ContentAlignment.MiddleCenter;
            title.TextAlign = ContentAlignment.MiddleCenter;
            exit.TextAlign = ContentAlignment.MiddleCenter;
            back.Image = ImageManage.GetSImage("button01");
            title.Image = back.Image;
            exit.Image = back.Image;
            base.LoadContent();
        }

        private void Back(object sender, EventArgs e)
        {
            Close();
        }

        private void Title(object sender, EventArgs e)
        {
            var sc = GameRun.Instance.scenes;
            sc["play"].IsRun = false;
            sc["title"].IsRun = true;
            sc["play"].Initialize();
        }

        private void Exit(object sender, EventArgs e)
        {
            Program.Exit();
        }
    }
}
