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

namespace GameJam_26.Scene.Stage
{
    public class Wall : Base_Crimp
    {
        private int S_T = 30;
        private int L_T = 200;
        private Random rnd = new Random();
        public Wall(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {

        }

        public override void Initialize()
        {
            Size = new Size(rnd.Next(S_T, L_T), rnd.Next(S_T,S_T));
            Coordinate = new Vector2(rnd.Next(IGConfig.screen.Width / 4, IGConfig.screen.Width * 3 / 4), rnd.Next(IGConfig.screen.Height / 4, IGConfig.screen.Height * 3 / 4));
            Color = Color.Blue;
            base.Initialize();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("stageborder.png");
            base.LoadContent();
        }
    }
}
