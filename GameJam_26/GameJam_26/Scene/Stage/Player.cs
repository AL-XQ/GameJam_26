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
        private StageField mark;
        public Vector2 lastv = Vector2.Zero, nowv = Vector2.Zero;

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
            if (index == 0)
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
            }
            foreach (var l in Charas)
            {
                l.Color = Color.White;
            }
            foucs = 1;
        }

        public void PreLoadContent()
        {
            for (int i = 0; i < 3; i++)
            {
                charas.Add(new ConChara(stage.GraphicsDevice, stage, index.ToString() + "_" + i.ToString(), this));
            }
            mark = new StageField(stage.GraphicsDevice, stage, index.ToString() + "_mark");
        }

        public void LoadContent()
        {
            mark.Color = Color.Red;
            mark.Image = ImageManage.GetSImage("conchara.png");
            mark.Size = new Size(20, 20);
            mark.DrawOrder = 10;
        }

        public void ResetV()
        {
            nowv = Vector2.Zero;
            lastv = Vector2.Zero;
        }

        public void FreeUpdate(GameTime gameTime)
        {
            mark.Coordinate = Foucs.Circle.Center + nowv * 100f - (mark.Size / 2).ToVector2();
        }

        public bool Update(GameTime gameTime)
        {
            lastv = nowv;
            nowv = IGGamePad.GetLeftVelocity(index);
            if (nowv.Length() > 1f)
                nowv.Normalize();
            if (IGGamePad.GetKeyTrigger(index, Buttons.DPadLeft) || IGGamePad.GetKeyTrigger(index, Buttons.DPadUp))
            {
                foucs--;
                if (foucs == -1)
                    foucs = 2;
            }
            else if (IGGamePad.GetKeyTrigger(index, Buttons.DPadRight) || IGGamePad.GetKeyTrigger(index, Buttons.DPadDown))
            {
                foucs++;
                if (foucs == 3)
                    foucs = 0;
            }
            if (nowv.Length() > 0.1f&&IGGamePad.GetKeyTrigger(index,Buttons.RightShoulder)/*(nowv - lastv).Length() >= 0.3f && nowv.Length() <= lastv.Length() && nowv.Length() < 0.1f*/)
            {
                Vector2 f = -nowv;
                Foucs.Speed = f * f * f * 80f;
                ResetV();
                return true;
            }
            /*if (IGGamePad.GetKeyTrigger(index, Buttons.A))
            {
                ((Item)stage.stageObjs["item01"]).RollDown(new Vector2(20, -20));
            }*/
            return false;
        }
    }
}
