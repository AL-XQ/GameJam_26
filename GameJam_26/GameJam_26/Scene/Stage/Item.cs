using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Stage.StageObject.Block;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Def;

namespace GameJam_26.Scene.Stage
{
    public class Item : Block
    {
        private ConChara owner;
        private Base_Stage st;
        private Vector2 speed = Vector2.Zero;
        private Random rnd = new Random();

        public ConChara Owner { get => owner; }
        public Vector2 Speed { get => speed; }
        public Item(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            st = (Base_Stage)Stage;
            st.items.Add(this);
        }

        public override void Initialize()
        {
            Coordinate = new Vector2(rnd.Next(IGConfig.screen.Width / 4, IGConfig.screen.Width * 3 / 4), rnd.Next(IGConfig.screen.Height / 4, IGConfig.screen.Height * 3 / 4));
            base.Initialize();
        }

        public void SetOwner(ConChara chara)
        {
            if (owner != null && chara != owner)
                owner.Item = null;
            owner = chara;
            if (owner != null)
            {
                owner.Item = this;
                visible = false;
            }
            else
                visible = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (owner != null)
                Coordinate = owner.Coordinate;
            base.Update(gameTime);
        }

        public void RollDown(Vector2 v)
        {

        }

        public override void CalCrimpColl(Dictionary<string, StageObj> tempSO)
        {
            if (speed.Length() == 0)
            {
                var keys = tempSO.Keys.ToArray();
                foreach (var l in keys)
                {
                    if (tempSO[l] is ConChara)
                    {
                        var c = (ConChara)tempSO[l];
                        if ((int)c.Player.Index == st.Pl_Index && c.Player.Foucs.Name == c.Name)
                        {
                            SetOwner(c);
                            c.Item = this;
                        }
                    }
                }
            }
            base.CalCrimpColl(tempSO);
        }
    }
}
