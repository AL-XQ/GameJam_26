﻿using System;
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
        private float maxSpeed = 40f;
        private Player player;
        private Circle circle;
        private Base_Stage st;
        private Dictionary<string, Item> items = new Dictionary<string, Item>();
        private Vector2 speed = Vector2.Zero;
        private bool skipColl = false;
        private bool skipTrun = false;
        private bool rndve = false;
        private bool run = false;
        public Circle Circle { get => circle; set => circle = value; }
        public Dictionary<string, Item> Items { get => items; }
        public Vector2 Speed { get => speed; set => speed = value; }
        public Player Player { get => player; }
        public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public bool SkipTrun { get => skipTrun; set => skipTrun = value; }
        public bool Rndve { get => rndve; set => rndve = value; }
        public bool Run { get => run; }

        public ConChara(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName, Player player) : base(aGraphicsDevice, aParent, aName)
        {
            this.player = player;
            IsCrimp = true;
            st = (Base_Stage)Stage;
            st.charas.Add(this);
            DrawOrder = 2;
        }

        public override void Initialize()
        {
            run = false;
            skipTrun = false;
            rndve = false;
            color = player.CharaColor;
            speed = Vector2.Zero;
            skipColl = false;
            base.Initialize();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("conchara.png");
            Size = Size.Parse(image.Image.Size) * 4 / 5;
            circle = new Circle(this, Size.Width / 2);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            run = false;
            if (speed.Length() != 0)
            {
                AddVelocity(speed, VeloParam.Run);
                speed -= speed * st.Resistance;
                run = true;
            }
            if (speed.Length() <= 0.05f)
            {
                speed = Vector2.Zero;
            }
            base.Update(gameTime);
            skipColl = false;
        }

        public override void CalAllColl(Dictionary<string, StageObj> tempSO)
        {
            var keys = tempSO.Keys.ToArray();
            foreach (var l in keys)
            {
                if (!tempSO.ContainsKey(l))
                {
                    continue;
                }
                if (tempSO[l] is ConChara)
                {
                    if (((ConChara)tempSO[l]).player.Index != player.Index &&
                        st.Pl_Index == (int)player.Index &&
                        ((ConChara)tempSO[l]).Items.Count > 0)
                    {
                        var it = ((ConChara)tempSO[l]).Items.First().Value;
                        it.SetOwner(null);
                        it.RollDown(new Vector2(speed.X * 0.5f, speed.Length() * 0.7f));
                        st.Pl_Index = (int)player.Index + 2;
                    }
                }
            }

            if (skipColl)
            {
                skipColl = false;
                return;
            }

            foreach (var l in keys)
            {
                if (!tempSO.ContainsKey(l))
                {
                    continue;
                }
                if (tempSO[l] is ConChara)
                {
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
            }
            base.CalAllColl(tempSO);
        }
    }
}
