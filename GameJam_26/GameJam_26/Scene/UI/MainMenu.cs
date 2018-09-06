using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using InfinityGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam_26.Scene.UI
{
    public class MainMenu : UIWindow
    {
        private AnimeButton start;
        private AnimeButton credit;
        private AnimeButton exit;
        public MainMenu(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        private void RegistEvent()
        {
            start.Click += Start;
            exit.Click += Exit;
        }

        public override void PreLoadContent()
        {
            start = new AnimeButton(graphicsDevice, this);
            credit = new AnimeButton(graphicsDevice, this);
            exit = new AnimeButton(graphicsDevice, this);

            start.Size = new Size(size.Width * 4 / 5, size.Height * 1 / 4);
            credit.Size = start.Size;
            exit.Size = start.Size;
            start.Location = new Point(size.Width / 2 - start.Size.Width / 2, 60);
            credit.Location = start.Location + new Point(0, start.Size.Height + 10);
            exit.Location = credit.Location + new Point(0, credit.Size.Height + 10);

            RegistEvent();
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            start.Text = GetText("Start");
            credit.Text = GetText("Credit");
            exit.Text = GetText("Exit");
            start.TextAlign = ContentAlignment.MiddleCenter;
            credit.TextAlign = ContentAlignment.MiddleCenter;
            exit.TextAlign = ContentAlignment.MiddleCenter;
            base.LoadContent();
        }

        private void Start(object sender, EventArgs e)
        {
            var sc = GameRun.Instance.scenes;
            sc["title"].IsRun = false;
            sc["play"].IsRun = true;
        }

        private void Exit(object sender, EventArgs e)
        {
            Program.Exit();
        }
    }
}
