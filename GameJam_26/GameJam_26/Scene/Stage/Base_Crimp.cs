﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.Device;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Stage.StageObject.Block;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StrikeWars.Scene.Stage
{
    public class Base_Crimp : Crimp
    {
        /// <summary>
        /// 反発係数
        /// </summary>
        public float repul = 0.8f;
        public Base_Crimp(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            DrawOrder = 4;
        }

        public override void CalAllColl(Dictionary<string, StageObj> tempSO)
        {
            var keys = tempSO.Keys.ToArray();
            foreach (var l in keys)
            {
                if (tempSO.ContainsKey(l))
                {
                    if (tempSO[l] is ConChara)
                    {
                        var t = (ConChara)tempSO[l];
                        var c = t.Circle;
                        if (c.Center.X < Coordinate.X && c.Center.Y < Coordinate.Y)
                        {
                            Vector2 ll = c.Center - Coordinate;
                            ll.Normalize();
                            Vector2 r = -t.Speed;
                            r.Normalize();
                            float l_l = Vector2.Dot(r, ll);
                            ll *= l_l;
                            Vector2 nn = ll - r;
                            Vector2 nsn = r + 2 * nn;
                            Vector2 ns = nsn * t.Speed.Length();
                            t.Speed = ns;

                        }
                        else if (c.Center.X > Coordinate.X + size.Width && c.Center.Y < Coordinate.Y)
                        {
                            Vector2 ll = c.Center - (Coordinate + new Vector2(size.Width, 0));
                            ll.Normalize();
                            Vector2 r = -t.Speed;
                            r.Normalize();
                            float l_l = Vector2.Dot(r, ll);
                            ll *= l_l;
                            Vector2 nn = ll - r;
                            Vector2 nsn = r + 2 * nn;
                            Vector2 ns = nsn * t.Speed.Length();
                            t.Speed = ns;
                        }
                        else if (c.Center.X > Coordinate.X + size.Width && c.Center.Y > Coordinate.Y + size.Height)
                        {
                            Vector2 ll = c.Center - (Coordinate + size.ToVector2());
                            ll.Normalize();
                            Vector2 r = -t.Speed;
                            r.Normalize();
                            float l_l = Vector2.Dot(r, ll);
                            ll *= l_l;
                            Vector2 nn = ll - r;
                            Vector2 nsn = r + 2 * nn;
                            Vector2 ns = nsn * t.Speed.Length();
                            t.Speed = ns;
                        }
                        else if (c.Center.X < Coordinate.X && c.Center.Y > Coordinate.Y + size.Height)
                        {
                            Vector2 ll = c.Center - (Coordinate + new Vector2(0, size.Height));
                            ll.Normalize();
                            Vector2 r = -t.Speed;
                            r.Normalize();
                            float l_l = Vector2.Dot(r, ll);
                            ll *= l_l;
                            Vector2 nn = ll - r;
                            Vector2 nsn = r + 2 * nn;
                            Vector2 ns = nsn * t.Speed.Length();
                            t.Speed = ns;
                        }
                        else if (c.Center.X < Coordinate.X)
                        {
                            float X = -Math.Abs(t.Speed.X) * repul;
                            float Y = t.Speed.Y;
                            t.Speed = new Vector2(X, Y);
                        }
                        else if (c.Center.Y < Coordinate.Y)
                        {
                            float X = t.Speed.X;
                            float Y = -Math.Abs(t.Speed.Y) * repul;
                            t.Speed = new Vector2(X, Y);
                        }
                        else if (c.Center.X > Coordinate.X + size.Width)
                        {
                            float X = Math.Abs(t.Speed.X) * repul;
                            float Y = t.Speed.Y;
                            t.Speed = new Vector2(X, Y);
                        }
                        else if (c.Center.Y > Coordinate.Y + size.Height)
                        {
                            float X = t.Speed.X;
                            float Y = Math.Abs(t.Speed.Y) * repul;
                            t.Speed = new Vector2(X, Y);
                        }
                    }
                    else if (tempSO[l] is Item)
                    {
                        var t = (Item)tempSO[l];
                        if (t.Coordinate.X < Coordinate.X &&
                            t.Coordinate.Y + t.Size.Height > Coordinate.Y &&
                            t.Coordinate.Y < Coordinate.Y + size.Height)
                        {
                            float X = -Math.Abs(t.Speed.X) * repul;
                            float Y = t.Speed.Y;
                            t.Speed = new Vector2(X, Y);
                        }
                        else if (t.Coordinate.X + t.Size.Width > Coordinate.X + size.Width &&
                                 t.Coordinate.Y + t.Size.Height > Coordinate.Y &&
                                 t.Coordinate.Y < Coordinate.Y + size.Height)
                        {
                            float X = Math.Abs(t.Speed.X) * repul;
                            float Y = t.Speed.Y;
                            t.Speed = new Vector2(X, Y);
                        }
                        else if (t.Coordinate.Y < Coordinate.Y)
                        {
                            float X = t.Speed.X;
                            float Y = -Math.Abs(t.Speed.Y) * repul;
                            t.Speed = new Vector2(X, Y);
                        }
                        else if (t.Coordinate.Y + t.Size.Height > Coordinate.Y + size.Height)
                        {
                            float X = t.Speed.X;
                            float Y = Math.Abs(t.Speed.Y) * repul;
                            t.Speed = new Vector2(X, Y);
                        }
                    }
                }
            }
            base.CalAllColl(tempSO);
        }
    }
}
