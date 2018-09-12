using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.Device.KeyboardManage;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrikeWars.Scene.UI
{
    public class StageSelect : UIWindow
    {
        private int index = 0;
        private int stagesnum = 2;
        private int tm = 2;

        private List<Icon> stages = new List<Icon>();
        private int Index { get => index; set => SetIndex(value); }
        public StageSelect(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
            visible = false;
            canMove = false;
            canClose = false;
            BorderOn = false;
            backColor = Color.Transparent;
        }

        public override void Initialize()
        {
            tm = 2;
            IndexFocus();
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            Size = new Size(parent.Size.Width / 3, parent.Size.Width / 5);
            Location = ((parent.Size - Size) / 2).ToPoint();
            for (int i = 0; i < stagesnum; i++)
            {
                stages.Add(new Icon(graphicsDevice, this));
            }
            for (int i = 0; i < stagesnum; i++)
            {
                stages[i].Location = new Point(150 + i * 150, 100);
                stages[i].Text = "ステージ" + (i + 1).ToString();
                stages[i].Stage = "Stage" + (i + 1).ToString("00");
            }
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            for (int i = 0; i < stagesnum; i++)
            {
                stages[i].Image = ImageManage.GetSImage("stageicon" + i.ToString() + ".png");
            }
            Image = ImageManage.GetSImage("window.png");
            base.LoadContent();
        }

        private void SetIndex(int value)
        {
            int t = value;
            if (t == -1)
                t = stages.Count - 1;
            else if (t == stages.Count)
                t = 0;
            stages[index].OnLeave(null, null);
            index = t;
            stages[index].OnEnter(null, null);
        }

        public void IndexFocus()
        {
            Index = index;
        }

        public override void Update(GameTime gameTime)
        {
            if (visible)
            {
                if (tm > 0)
                    tm--;
                if (tm == 0)
                {
                    if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.DPadLeft))
                        Index--;
                    if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.DPadRight))
                        Index++;
                    if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Start))
                        Enter();
                    if (GameKeyboard.GetKeyTrigger(Keys.Escape) || IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Back))
                        visible = false;
                }
            }
            base.Update(gameTime);
        }

        private void Enter()
        {
            stages[index].OnClick(null, null);
            visible = false;
        }
    }
}
