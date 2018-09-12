using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.GameGraphics;
using InfinityGame.Scene;
using Microsoft.Xna.Framework.Graphics;

using StrikeWars.Scene.Stage;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using Microsoft.Xna.Framework;
using InfinityGame.Element;
using StrikeWars.Scene.UI;
using InfinityGame.Device;
using InfinityGame.Device.KeyboardManage;
using Microsoft.Xna.Framework.Input;

namespace StrikeWars.Scene
{
    public class PlayScene : StageScene
    {
        private Ending ending;
        private BackMenu backMenu;
        private Label label01;
        private Label label02;
        private Label label03;
        private Panel plp;
        private int plpshowtime = 120;
        private int s_plpshowtime = 120;

        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        public override void Initialize()
        {
            sounds["st"].Stop();
            sounds["end"].Stop();
            plpshowtime = s_plpshowtime;
            label01.Text = "";
            plp.Visible = false;
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            new Stage01(GraphicsDevice, this, "Stage01");
            new Stage02(GraphicsDevice, this, "Stage02");
            System.Drawing.Color tc = System.Drawing.Color.DarkBlue;
            label01 = new Label(graphicsDevice, this);
            label01.TextSize = 24f;
            label01.BDText.ForeColor = tc;
            label02 = new Label(graphicsDevice, this);
            label02.TextSize = 24f;
            label02.BDText.ForeColor = tc;
            label03 = new Label(graphicsDevice, this);
            label03.TextSize = 24f;
            label03.BDText.ForeColor = tc;
            plp = new Panel(graphicsDevice, this);
            plp.BackColor = Color.Transparent;

            ShowStage = stages["Stage02"];
            ending = new Ending(graphicsDevice, this);
            ending.Size = new Size(size.Width * 4 / 5, size.Height * 2 / 3);
            ending.Location = (size / 2 - ending.Size / 2).ToPoint();
            backMenu = new BackMenu(graphicsDevice, this);
            backMenu.Size = new Size(size.Width * 2 / 7, size.Height * 3 / 7);
            backMenu.Location = (size / 2 - backMenu.Size / 2).ToPoint();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            sounds.Add("st", SoundManage.GetSound("st.wav"));
            sounds.Add("end", SoundManage.GetSound("end.wav"));
            sounds.Add("turn", SoundManage.GetSound("turn.wav"));
            sounds["st"].SetSELoopPlay(true);
            sounds["end"].SetSELoopPlay(true);
            sounds["turn"].SetSELoopPlay(false);
            label01.Location = new Point(size.Width / 2 - label01.Size.Width / 2, 10);
            //backMenu.Text = GetText("BackMenu");
            label02.Location = new Point(size.Width / 2 - label02.Size.Width / 2, size.Height - label02.Size.Height - 10);
            label03.Location = new Point(5, 5);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            var t = (Base_Stage)ShowStage;
            if (t.Turn > 0)
                label01.Text = $"残り：{t.Turn}ターン";
            else
            {
                Dictionary<string, object> ed = new Dictionary<string, object>();
                int[] s = new int[2];
                s[0] = 0; s[1] = 0;
                var keys = t.stageObjs.Keys.ToArray();
                foreach (var l in keys)
                {
                    if (t.stageObjs.ContainsKey(l) && t.stageObjs[l] is Item)
                    {
                        var it = (Item)t.stageObjs[l];
                        if (it.Owner != null)
                        {
                            int temp = (int)it.Owner.Player.Index;
                            s[temp]++;
                        }
                    }
                }

                if (s[0] > s[1])
                {
                    label01.Text = $"ゲームオーバー、勝者1";
                    ed["winner"] = 0;
                }
                else if (s[1] > s[0])
                {
                    label01.Text = $"ゲームオーバー、勝者2";
                    ed["winner"] = 1;
                }
                else
                {
                    label01.Text = $"ゲームオーバー、引き分け";
                    ed["winner"] = -1;
                }
                ending.ShowEnding(ed);
            }
            label02.Text = $"ターン残り時間：{(t.Timedown / 120.0f).ToString("00.00")}秒";
            label03.Text = $"プレイヤー{(t.Pl_Index % 2) + 1}のターン";
            if (GameKeyboard.GetKeyTrigger(Keys.Escape) || IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Back))
            {
                backMenu.Visible = !backMenu.Visible;
            }
            if (ending.Visible)
            {
                sounds["st"].Stop();
                sounds["end"].Play();
            }
            else if (backMenu.Visible)
            {
                if (!sounds["st"].GetState(Microsoft.Xna.Framework.Audio.SoundState.Paused))
                    sounds["st"].Pause();
            }
            else
            {
                if (sounds["st"].GetState(Microsoft.Xna.Framework.Audio.SoundState.Paused))
                    sounds["st"].Resume();
                else if (sounds["st"].GetState(Microsoft.Xna.Framework.Audio.SoundState.Stopped))
                    sounds["st"].Play();
            }
            if (backMenu.Visible || ending.Visible || plp.Visible)
            {
                backMenu.Update(gameTime);
                ending.Update(gameTime);
                plp.Update(gameTime);
                if (plp.Visible)
                {
                    if (plpshowtime > 0)
                        plpshowtime--;
                    else
                    {
                        plpshowtime = s_plpshowtime;
                        plp.Visible = false;
                    }
                }
                return;
            }
            label01.Location = new Point(size.Width / 2 - label01.Size.Width / 2, 10);
            label02.Location = new Point(size.Width / 2 - label02.Size.Width / 2, size.Height - label02.Size.Height - 10);
            base.Update(gameTime);
        }

        public void ChangeTrun(int player)
        {
            switch (player)
            {
                case 0:
                    plp.Image = ImageManage.GetSImage("player0.png");
                    break;
                case 1:
                    plp.Image = ImageManage.GetSImage("player1.png");
                    break;
            }
            plp.Size = Size.Parse(plp.Image.Image.Size);
            plp.Location = ((size - plp.Size) / 2).ToPoint();
            plp.Visible = true;
            sounds["turn"].Play();
        }
    }
}
