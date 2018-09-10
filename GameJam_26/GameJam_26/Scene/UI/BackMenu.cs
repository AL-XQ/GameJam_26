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

using InfinityGame.Device.KeyboardManage;
using Microsoft.Xna.Framework.Input;

namespace GameJam_26.Scene.UI
{
    public class BackMenu : UIWindow
    {
        private AnimeButton back;
        private AnimeButton reset;
        private AnimeButton title;
        private AnimeButton exit;
        private int index = 0;

        private int Index { get => index; set => SetIndex(value); }
        public BackMenu(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
            BorderOn = false;
            CanClose = false;
            CanMove = false;
            backColor = Color.Transparent;
        }

        private void SetIndex(int value)
        {
            int t = value;
            if (t == -1)
                t = 3;
            else if (t == 4)
                t = 0;
            switch (index)
            {
                case 0:
                    back.OnLeave(null, null);
                    break;
                case 1:
                    reset.OnLeave(null, null);
                    break;
                case 2:
                    title.OnLeave(null, null);
                    break;
                case 3:
                    exit.OnLeave(null, null);
                    break;
            }
            index = t;
            switch (index)
            {
                case 0:
                    back.OnEnter(null, null);
                    break;
                case 1:
                    reset.OnEnter(null, null);
                    break;
                case 2:
                    title.OnEnter(null, null);
                    break;
                case 3:
                    exit.OnEnter(null, null);
                    break;
            }

        }
        public override void Initialize()
        {
            Index = 0;
            visible = false;
            base.Initialize();
        }
        private void RegistEvent()
        {
            title.Click += Title;
            reset.Click += Reset;
            exit.Click += Exit;
            back.Click += Back;
        }
        public override void PreLoadContent()
        {
            back = new AnimeButton(graphicsDevice, this);
            reset = new AnimeButton(graphicsDevice, this);
            title = new AnimeButton(graphicsDevice, this);
            exit = new AnimeButton(graphicsDevice, this);
            back.Size = new Size(Size.Width * 4 / 5, Size.Height / 5);
            reset.Size = back.Size;
            title.Size = back.Size;
            exit.Size = back.Size;
            back.Location = new Point(size.Width / 2 - back.Size.Width / 2, 20);
            reset.Location = back.Location + new Point(0, back.Size.Height + 10);
            title.Location = reset.Location + new Point(0, reset.Size.Height + 10);
            exit.Location = title.Location + new Point(0, title.Size.Height + 10);

            RegistEvent();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            back.Text = GetText("Back");
            reset.Text = GetText("Reset");
            title.Text = GetText("Title");
            exit.Text = GetText("Exit");
            back.TextAlign = ContentAlignment.MiddleCenter;
            reset.TextAlign = ContentAlignment.MiddleCenter;
            title.TextAlign = ContentAlignment.MiddleCenter;
            exit.TextAlign = ContentAlignment.MiddleCenter;
            back.Image = ImageManage.GetSImage("button01");
            reset.Image = back.Image;
            title.Image = back.Image;
            exit.Image = back.Image;
            Image = ImageManage.GetSImage("window.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (visible)
            {
                if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.DPadUp))
                    Index--;
                if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.DPadDown))
                    Index++;
                if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Start))
                    Enter();
            }
            base.Update(gameTime);
        }

        private void Enter()
        {
            switch (index)
            {
                case 0:
                    back.OnClick(null, null);
                    break;
                case 1:
                    reset.OnClick(null, null);
                    break;
                case 2:
                    title.OnClick(null, null);
                    break;
                case 3:
                    exit.OnClick(null, null);
                    break;
            }
        }

        private void Back(object sender, EventArgs e)
        {
            Close();
        }

        private void Reset(object sender, EventArgs e)
        {
            GameRun.Instance.scenes["play"].Initialize();
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
