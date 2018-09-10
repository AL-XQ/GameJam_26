using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using InfinityGame.Def;
using InfinityGame.Device;
using InfinityGame.Device.KeyboardManage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

namespace GameJam_26.Scene.Stage
{
    public class Player
    {
        private Color charaColor;
        private PlayerIndex index;
        private Base_Stage stage;
        private List<ConChara> charas = new List<ConChara>();
        private int foucs;
        private Mark mark;
        private StageField markBase;
        private Vector2 mksz = new Vector2(300, 120);
        public Vector2 lastv = Vector2.Zero, nowv = Vector2.Zero;
        private Random rnd = new Random();

        private int _Foucs { get => foucs; set => SetFoucs(value); }
        public PlayerIndex Index { get => index; }
        public List<ConChara> Charas { get => charas; }
        public ConChara Foucs { get => charas[foucs]; }
        public Color CharaColor { get => charaColor; }
        public Player(PlayerIndex index, Base_Stage stage)
        {
            this.index = index;
            this.stage = stage;
            switch (index)
            {
                case PlayerIndex.One:
                    charaColor = Color.Green;
                    break;
                case PlayerIndex.Two:
                    charaColor = Color.Blue;
                    break;
            }
        }

        public void Initialize()
        {
            /*if (index == 0)
            {
                charas[0].Coordinate = new Vector2(IGConfig.screen.Height / 25 + 10, IGConfig.screen.Height / 25 + 10);
                charas[1].Coordinate = new Vector2(IGConfig.screen.Height / 25 + 10, IGConfig.screen.Height / 2 - charas[1].Size.Height / 2);
                charas[2].Coordinate = new Vector2(IGConfig.screen.Height / 25 + 10, IGConfig.screen.Height - IGConfig.screen.Height / 25 - charas[1].Size.Height - 10);
            }
            else
            {
                charas[0].Coordinate = new Vector2(IGConfig.screen.Width - IGConfig.screen.Height / 25 - charas[0].Size.Width - 10, IGConfig.screen.Height / 25 + 10);
                charas[1].Coordinate = new Vector2(IGConfig.screen.Width - IGConfig.screen.Height / 25 - charas[1].Size.Width - 10, IGConfig.screen.Height / 2 - charas[1].Size.Height / 2);
                charas[2].Coordinate = new Vector2(IGConfig.screen.Width - IGConfig.screen.Height / 25 - charas[2].Size.Width - 10, IGConfig.screen.Height - IGConfig.screen.Height / 25 - charas[1].Size.Height - 10);
            }*/
            foreach (var l in Charas)
            {
                l.Color = Color.White;
            }
            foucs = 1;
            mark.Size = Size.Parse(mksz.ToPoint());
        }

        public void PreLoadContent()
        {
            for (int i = 0; i < 3; i++)
            {
                charas.Add(new ConChara(stage.GraphicsDevice, stage, index.ToString() + "_" + i.ToString(), this));
            }
            mark = new Mark(stage.GraphicsDevice, stage, index.ToString() + "_mark");
            markBase = new StageField(stage.GraphicsDevice, stage, index.ToString() + "_markBase");
        }

        public void LoadContent()
        {
            mark.Image = ImageManage.GetSImage("yajirusi.png");
            //markBase.Color = Color.Green;
            markBase.Image = ImageManage.GetSImage("markbase.png");
            markBase.DrawOrder = 0;
        }

        private void SetFoucs(int value)
        {
            bool endtrun = true;
            foreach(var l in charas)
            {
                if (!l.SkipTrun)
                {
                    endtrun = false;
                    break;
                }
            }
            if (endtrun)
                return;
            if (value == -1)
                foucs = 2;
            else if (value == 3)
                foucs = 0;
            else
                foucs = value;
            if (Foucs.SkipTrun)
                _Foucs++;
        }

        public void ResetV()
        {
            nowv = Vector2.Zero;
            lastv = Vector2.Zero;
        }

        public void FreeUpdate(GameTime gameTime)
        {
            markBase.Size = Foucs.Size + new Size(20, 20);
            markBase.Coordinate = Foucs.Circle.Center - (markBase.Size / 2).ToVector2();
            mark.Size = Size.Parse((mksz * nowv.Length()).ToPoint());
            mark.Coordinate = Foucs.Circle.Center;
            mark.Rotation = (float)Math.Atan2(nowv.Y, nowv.X);
            mark.DrawOrder = 10;
            if (Foucs.Rndve)
                mark.Visible = false;
            else
                mark.Visible = true;
            if (Foucs.SkipTrun)
                _Foucs++;
        }

        public bool Update(GameTime gameTime)
        {
            lastv = nowv;
            nowv = IGGamePad.GetLeftVelocity(index);
            if (nowv.Length() > 1f)
                nowv.Normalize();
            if (IGGamePad.GetKeyTrigger(index, Buttons.DPadLeft) || IGGamePad.GetKeyTrigger(index, Buttons.DPadUp))
            {
                _Foucs--;
            }
            else if (IGGamePad.GetKeyTrigger(index, Buttons.DPadRight) || IGGamePad.GetKeyTrigger(index, Buttons.DPadDown))
            {
                _Foucs++;
            }
            if (nowv.Length() > 0.0f && IGGamePad.GetKeyTrigger(index, Buttons.RightShoulder)/*(nowv - lastv).Length() >= 0.3f && nowv.Length() <= lastv.Length() && nowv.Length() < 0.1f*/)
            {
                if (Foucs.SkipTrun)
                    return false;
                Vector2 f = Vector2.Zero;
                if (!Foucs.Rndve)
                    f = -nowv;
                else
                    f = new Vector2(rnd.Next(101) / 100f, rnd.Next(101) / 100f);
                Foucs.Speed = f * f * f * Foucs.MaxSpeed;
                ResetV();
                return true;
            }
            return false;
        }

        public void TrunReset()
        {
            foreach (var l in charas)
            {
                l.SkipTrun = false;
            }
        }
    }
}
