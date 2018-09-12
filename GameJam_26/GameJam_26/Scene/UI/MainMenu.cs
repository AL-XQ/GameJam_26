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
using InfinityGame.Device;
using Microsoft.Xna.Framework.Input;

namespace GameJam_26.Scene.UI
{
    public class MainMenu : UIWindow
    {
        private AnimeButton start;
        private AnimeButton credit;
        private AnimeButton exit;
        private int index = 0;

        private int Index { get => index; set => SetIndex(value); }
        public MainMenu(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
            canMove = false;
            canClose = false;
            BorderOn = false;
            backColor = Color.Transparent;
        }

        private void SetIndex(int value)
        {
            int t = value;
            if (t == -1)
                t = 2;
            else if (t == 3)
                t = 0;
            switch (index)
            {
                case 0:
                    start.OnLeave(null, null);
                    break;
                case 1:
                    credit.OnLeave(null, null);
                    break;
                case 2:
                    exit.OnLeave(null, null);
                    break;
            }
            index = t;
            switch (index)
            {
                case 0:
                    start.OnEnter(null, null);
                    break;
                case 1:
                    credit.OnEnter(null, null);
                    break;
                case 2:
                    exit.OnEnter(null, null);
                    break;
            }

        }

        public override void Initialize()
        {
            Index = 0;
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

            start.Size = new Size(size.Width * 4 / 5, size.Height / 4);
            credit.Size = start.Size;
            exit.Size = start.Size;
            start.Location = new Point(size.Width / 2 - start.Size.Width / 2, 30);
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
            start.Image = ImageManage.GetSImage("button01");
            credit.Image = ImageManage.GetSImage("button01");
            exit.Image = ImageManage.GetSImage("button01");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (visible && !((TitleScene)parent).StageSelect.Visible)
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
                    start.OnClick(null, null);
                    break;
                case 1:
                    credit.OnClick(null, null);
                    break;
                case 2:
                    exit.OnClick(null, null);
                    break;
            }
        }

        private void Start(object sender, EventArgs e)
        {
            ((TitleScene)parent).StageSelect.Visible = true;
            ((TitleScene)parent).StageSelect.Initialize();
        }

        private void Exit(object sender, EventArgs e)
        {
            Program.Exit();
        }
    }
}
