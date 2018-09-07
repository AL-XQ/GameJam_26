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
using InfinityGame.Device;
using InfinityGame.Device.KeyboardManage;
using Microsoft.Xna.Framework.Input;

namespace GameJam_26.Scene
{
    public class PlayScene : StageScene
    {
        private Ending ending;
        private BackMenu backMenu;
        private Label label01;
        private Label label02;
        private Label label03;


        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        public override void Initialize()
        {
            label01.Text = "";
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            new Stage01(GraphicsDevice, this, "Stage01");
            label01 = new Label(graphicsDevice, this);
            label01.TextSize = 24f;
            label02 = new Label(graphicsDevice, this);
            label02.TextSize = 24f;
            label03 = new Label(graphicsDevice, this);
            label03.TextSize = 24f;
            ShowStage = stages["Stage01"];
            ending = new Ending(graphicsDevice, this);
            ending.Size = new Size(size.Width * 4 / 5, size.Height * 2 / 3);
            ending.Location = (size / 2 - ending.Size / 2).ToPoint();
            backMenu = new BackMenu(graphicsDevice, this);
            backMenu.Size = new Size(size.Width * 2 / 7, size.Height / 3);
            backMenu.Location = (size / 2 - backMenu.Size / 2).ToPoint();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            label01.Location = new Point(size.Width / 2 - label01.Size.Width / 2, 10);
            //backMenu.Text = GetText("BackMenu");
            label02.Location = new Point(size.Width / 2 - label01.Size.Width / 2, size.Height - label01.Size.Height - 10);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            var t = ((Base_Stage)stages["Stage01"]);
            if (t.Turn > 0)
                label01.Text = $"残り：{t.Turn}ターン";
            else
            {
                var it = (Item)t.stageObjs["item01"];
                if (it.Owner != null)
                {
                    int s = (int)it.Owner.Player.Index;
                    label01.Text = $"ゲームオーバー、勝者{s}";
                }
                else
                    label01.Text = $"ゲームオーバー、引き分け";
            }
            label02.Text = $"ターン残り時間：{(t.Timedown / 60.0f).ToString("00.00")}秒";
            label03.Text = $"プレイヤー{t.Pl_Index}のターン";
            if (GameKeyboard.GetKeyTrigger(Keys.Escape))
            {
                backMenu.Visible = !backMenu.Visible;
            }
            if (backMenu.Visible || ending.Visible)
            {
                backMenu.Update(gameTime);
                ending.Update(gameTime);
                return;
            }
            base.Update(gameTime);
        }

    }
}
