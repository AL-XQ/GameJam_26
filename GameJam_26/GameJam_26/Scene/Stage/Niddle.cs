using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Device;
using Microsoft.Xna.Framework;

namespace StrikeWars.Scene.Stage
{
    public class Niddle : Wall
    {
        public Niddle(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {

        }

        public override void Desi()
        {
            Image = ImageManage.GetSImage("doku.png");
        }

        public override void CalAllColl(Dictionary<string, StageObj> tempSO)
        {
            var keys = tempSO.Keys.ToArray();
            foreach(var l in keys)
            {
                if (tempSO[l] is ConChara)
                {
                    ((ConChara)tempSO[l]).SkipTrun = true;
                }
            }
            base.CalAllColl(tempSO);
        }
    }
}
