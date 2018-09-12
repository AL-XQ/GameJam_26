using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Def;
using InfinityGame.Device;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Stage.StageObject.Block;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam_26.Scene.Stage
{
    public class PanicArea : Block
    {
        private int S_T = 200;
        private int L_T = 500;
        private Random rnd = new Random();
        private Dictionary<string, ConChara> pac = new Dictionary<string, ConChara>();
        private Dictionary<string, ConChara> lastpac = new Dictionary<string, ConChara>();
        public PanicArea(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            IsCrimp = false;
            DrawOrder = 0;
        }

        public override void Initialize()
        {
            /*Size = new Size(rnd.Next(S_T, L_T), rnd.Next(S_T, S_T));
            Coordinate = new Vector2(rnd.Next(IGConfig.screen.Width / 4, IGConfig.screen.Width * 3 / 4), rnd.Next(IGConfig.screen.Height / 4, IGConfig.screen.Height * 3 / 4));*/
            
            base.Initialize();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("hatena.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            var keys1 = lastpac.Keys.ToArray();
            foreach(var l in keys1)
            {
                if (pac.ContainsKey(l))
                    lastpac[l].Rndve = true;
                else
                    lastpac[l].Rndve = false;
            }
            lastpac.Clear();
            lastpac = new Dictionary<string, ConChara>(pac);
            pac.Clear();
            base.Update(gameTime);
        }

        public override void CalAllColl(Dictionary<string, StageObj> tempSO)
        {
            var keys = tempSO.Keys.ToArray();
            foreach (var l in keys)
            {
                if (tempSO[l] is ConChara)
                {
                    if (!pac.ContainsKey(l))
                        pac.Add(l, (ConChara)tempSO[l]);
                }
            }
            base.CalAllColl(tempSO);
        }
    }
}
