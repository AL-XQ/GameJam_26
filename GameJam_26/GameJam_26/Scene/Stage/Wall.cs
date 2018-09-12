using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Element;
using InfinityGame.Def;
using Microsoft.Xna.Framework;
using InfinityGame.Device;
using InfinityGame.Stage.StageObject;

namespace GameJam_26.Scene.Stage
{
    public class Wall : Base_Crimp
    {
        private int S_T = 30;
        private int L_T = 300;
        private Random rnd = new Random();
        public Wall(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {

        }

        public override void Initialize()
        {
            /*int x = rnd.Next(S_T, L_T);
            int y = 300 - x;
            Size = new Size(x, y);
            Coordinate = new Vector2(rnd.Next(IGConfig.screen.Width / 4, IGConfig.screen.Width * 3 / 4), rnd.Next(IGConfig.screen.Height / 4, IGConfig.screen.Height * 3 / 4));*/
            base.Initialize();
        }

        public override void LoadContent()
        {
            Desi();
            base.LoadContent();
        }

        public virtual void Desi()
        {
            Image = ImageManage.GetSImage("wall.png");
        }

        public override void CalAllColl(Dictionary<string, StageObj> tempSO)
        {
            var keys = tempSO.Keys.ToArray();
            foreach (var l in keys)
            {
                if (tempSO[l] is Wall && tempSO[l].NewSpace.Contains(NewSpace))
                {
                    Initialize();
                }
            }
            base.CalAllColl(tempSO);
        }

        public override void Draw2(GameTime gameTime)
        {
            if (Image != null)
            {
                if (DrawLocation.X <= Stage.StageScene.Size.Width && DrawLocation.Y <= Stage.StageScene.Size.Height)
                {
                    if (DrawLocation.X >= -Size.Width && DrawLocation.Y >= -Size.Height)
                    {
                        spriteBatch.Draw(Image.ImageT[iTIndex], new Rectangle(DrawLocation, Size.ToPoint()), new Rectangle(new Point(0, 0), size.ToPoint()), Color * Refract);
                    }
                }
            }
        }
    }
}
