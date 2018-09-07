using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Device;
using InfinityGame.Element;
using Microsoft.Xna.Framework;
using InfinityGame.Stage;

namespace GameJam_26.Scene.Stage
{
    public class ConChara : Base_Chara, ICircle, ISpeed
    {
        private Player player;
        private Circle circle;
        private Base_Stage st;
        private Item item;
        private Vector2 speed = Vector2.Zero;
        private bool skipColl = false;
        public Circle Circle { get => circle; set => circle = value; }
        public Item Item { get => item; set => item = value; }
        public Vector2 Speed { get => speed; set => speed = value; }
        public Player Player { get => player; }
        public ConChara(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName, Player player) : base(aGraphicsDevice, aParent, aName)
        {
            this.player = player;
            IsCrimp = true;
            st = (Base_Stage)Stage;
            st.charas.Add(this);
        }

        public override void Initialize()
        {
            color = player.CharaColor;
            speed = Vector2.Zero;
            skipColl = false;
            base.Initialize();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("conchara.png");
            Size = Size.Parse(image.Image.Size);
            circle = new Circle(this, 50);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            AddVelocity(speed, VeloParam.Run);
            speed -= speed * st.Resistance;
            if (speed.Length() <= 0.1f)
                speed = Vector2.Zero;
            base.Update(gameTime);
            skipColl = false;
        }

        public override void CalAllColl(Dictionary<string, StageObj> tempSO)
        {
            if (skipColl)
            {
                skipColl = false;
                return;
            }
            var keys = tempSO.Keys.ToArray();
            foreach (var l in keys)
            {
                if (!tempSO.ContainsKey(l))
                    continue;
                if (tempSO[l] is ConChara)
                {
                    if (((ConChara)tempSO[l]).player.Index != player.Index &&
                        st.Pl_Index == (int)player.Index &&
                        ((ConChara)tempSO[l]).item != null)
                    {
                        var it = ((ConChara)tempSO[l]).item;
                        it.SetOwner(null);
                        it.RollDown(speed * 0.25f);
                    }
                    Vector2 f = ((ConChara)tempSO[l]).Circle.Center - circle.Center;
                    f.Normalize();
                    Vector2 ss = speed - ((ConChara)tempSO[l]).speed;
                    Vector2 s = ss;
                    s.Normalize();
                    float o = Vector2.Dot(f, s);
                    float sv = o * ss.Length();
                    Vector2 nspeed = f * sv;
                    ((ConChara)tempSO[l]).speed += nspeed;
                    speed += -nspeed;
                    ((ConChara)tempSO[l]).skipColl = true;
                }
                //else if (tempSO[l] is Item)
                //{
                //    ((Item)tempSO[l]).Speed = speed * 0.4f;
                //    speed *= 0.2f;
                //}
            }
            base.CalAllColl(tempSO);
        }
    }
}
