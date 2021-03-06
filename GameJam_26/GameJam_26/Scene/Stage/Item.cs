﻿using System;
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
using InfinityGame.Stage;
using InfinityGame.Element;
using InfinityGame.Device;

namespace StrikeWars.Scene.Stage
{
    public class Item : Block, ISpeed
    {
        private ConChara owner;
        private Base_Stage st;
        private Vector2 speed = Vector2.Zero;
        private Random rnd = new Random();
        private float rollDownLine = 0;
        private Vector2 rollDownSpeed = Vector2.Zero;
        private bool run = false;

        public ConChara Owner { get => owner; }
        public Vector2 Speed { get => speed; set => speed = value; }
        public bool Run { get => run; }
        public Item(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            IsCrimp = false;
            DrawOrder = 3;
            st = (Base_Stage)Stage;
            st.items.Add(this);
        }

        public override void Initialize()
        {
            run = false;
            SetOwner(null);
            rollDownLine = 0;
            rollDownSpeed = Vector2.Zero;
            speed = Vector2.Zero;
            //Coordinate = new Vector2(rnd.Next(IGConfig.screen.Width / 4, IGConfig.screen.Width * 3 / 4), rnd.Next(IGConfig.screen.Height / 4, IGConfig.screen.Height * 3 / 4));
            base.Initialize();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("item.png");
            size = Size.Parse(image.Image.Size);
            base.LoadContent();
        }

        public void SetOwner(ConChara chara)
        {
            if (owner != null && chara != owner)
            {
                owner.Items.Remove(Name);
                if (owner.Items.Count == 0)
                    owner.Color = owner.Player.CharaColor;
            }
            owner = chara;
            if (owner != null)
            {
                owner.Items.Add(Name, this);
                if (owner.Player.Index == 0)
                    owner.Color = Color.YellowGreen;
                else
                    owner.Color = Color.Yellow;
                visible = false;
            }
            else
            {
                visible = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            run = false;
            if (owner != null)
            {
                speed = Vector2.Zero;
                rollDownSpeed = Vector2.Zero;
                Coordinate = owner.Coordinate;
            }
            else
            {
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
            }
            if (rollDownLine != 0)
            {
                if (rollDownSpeed.Length() != 0)
                {
                    AddVelocity(rollDownSpeed, VeloParam.Run);
                    run = true;
                }
                if (Coordinate.Y < rollDownLine)
                    rollDownSpeed += new Vector2(0, st.G_V);
                if (rollDownSpeed.Length() <= 0.05f)
                    rollDownSpeed = Vector2.Zero;
                if (Coordinate.Y >= rollDownLine)
                {
                    rollDownSpeed.X -= rollDownSpeed.X * st.Resistance * 20;//着地している状態のみ、抵抗力が発生する、そしてYの運動は高さの表現、Yの抵抗力は別で計算する。
                    float my = Math.Abs(rollDownSpeed.Y);
                    if (my > st.G_V)
                        rollDownSpeed.Y = -my * 4 / 5;
                    else
                        rollDownSpeed.Y = 0;
                }
                float scale = (rollDownLine - Coordinate.Y) * 0.005f + 1;
                size = new Size((int)(image.Image.Size.Width * scale), (int)(image.Image.Size.Height * scale));
                if (rollDownSpeed.Length() == 0)
                {
                    rollDownLine = 0;
                    size = Size.Parse(image.Image.Size);
                }
            }
            base.Update(gameTime);
        }

        public void RollDown(Vector2 v)
        {
            rollDownLine = Coordinate.Y;
            rollDownSpeed = new Vector2(v.X * 0.2f, -Math.Abs(v.Y));
        }

        public override void CalAllColl(Dictionary<string, StageObj> tempSO)
        {
            if (speed.Length() == 0)
            {
                var keys = tempSO.Keys.ToArray();
                foreach (var l in keys)
                {
                    if (rollDownSpeed.Length() == 0 && owner == null)
                    {
                        if (tempSO[l] is ConChara)
                        {
                            var c = (ConChara)tempSO[l];
                            if (/*((int)c.Player.Index == st.Pl_Index % 2 || (int)c.Player.Index == st.Pl_Index - 2)*/ /*&& c.Player.Foucs.Name == c.Name &&*/ c.Items.Count < 1)
                            {
                                SetOwner(c);
                            }
                        }
                        else if (tempSO[l] is Wall && tempSO[l].NewSpace.Contains(NewSpace) || tempSO[l] is Item)
                        {
                            Initialize();
                        }
                    }
                }
            }
            base.CalAllColl(tempSO);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
