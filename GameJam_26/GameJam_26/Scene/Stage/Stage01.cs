using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Device;

using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Element;
using InfinityGame.Def;
using Microsoft.Xna.Framework;

namespace GameJam_26.Scene.Stage
{
    public class Stage01 : Base_Stage
    {
        public Stage01(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {

        }

        public override void Initialize()
        {
            Size sc = IGConfig.screen;
            Size ms = sc;
            int sp = ms.Height / 25;
            ms -= new Size(sp * 2, sp * 2);
            Size size0 = new Size(ms.Width / 12, ms.Height / 12);
            Size size1 = new Size(size0.Width, size0.Height * 2);
            Size size2 = new Size(size0.Width * 4, size0.Height);
            Size size3 = new Size(size0.Width * 2, size0.Height * 4);

            stageObjs["wall00"].Size = size0;
            stageObjs["wall01"].Size = size0;
            stageObjs["niddle00"].Size = size0;
            stageObjs["niddle01"].Size = size0;
            stageObjs["wall02"].Size = size1;
            stageObjs["wall03"].Size = size1;
            stageObjs["wall04"].Size = size1;
            stageObjs["wall05"].Size = size1;
            stageObjs["niddle02"].Size = size2;
            stageObjs["niddle03"].Size = size2;
            stageObjs["panicarea00"].Size = size3;
            stageObjs["panicarea01"].Size = size3;

            stageObjs["wall00"].Coordinate = new Vector2(sp + 11 * size0.Width, sp);
            stageObjs["wall01"].Coordinate = new Vector2(sp, sp + 11 * size0.Height);
            stageObjs["niddle00"].Coordinate = new Vector2(sp, sp);
            stageObjs["niddle01"].Coordinate = new Vector2(sp + 11 * size0.Width, sp + 11 * size0.Height);
            stageObjs["wall02"].Coordinate = new Vector2(sp + 3 * size0.Width, sp + size0.Height);
            stageObjs["wall03"].Coordinate = new Vector2(sp + 8 * size0.Width, sp + size0.Height);
            stageObjs["wall04"].Coordinate = new Vector2(sp + 3 * size0.Width, sp + 9 * size0.Height);
            stageObjs["wall05"].Coordinate = new Vector2(sp + 8 * size0.Width, sp + 9 * size0.Height);
            stageObjs["niddle02"].Coordinate = new Vector2(sp + 4 * size0.Width, sp + 2 * size0.Height);
            stageObjs["niddle03"].Coordinate = new Vector2(sp + 4 * size0.Width, sp + 9 * size0.Height);
            stageObjs["panicarea00"].Coordinate = new Vector2(sp + 2 * size0.Width, sp + 4 * size0.Height);
            stageObjs["panicarea01"].Coordinate = new Vector2(sp + 8 * size0.Width, sp + 4 * size0.Height);

            stageObjs["item00"].Coordinate = new Vector2(sp + 5.5f * size0.Width, sp + 0.5f * size0.Height);
            stageObjs["item01"].Coordinate = new Vector2(sp + 5.5f * size0.Width, sp + 5.5f * size0.Height);
            stageObjs["item02"].Coordinate = new Vector2(sp + 5.5f * size0.Width, sp + 10.5f * size0.Height);

            stageObjs["One_0"].Coordinate = new Vector2(sp + 0.5f * size0.Width, sp + 5.5f * size0.Height);
            stageObjs["One_1"].Coordinate = new Vector2(sp + 1f * size0.Width, sp + 4f * size0.Height);
            stageObjs["One_2"].Coordinate = new Vector2(sp + 1f * size0.Width, sp + 7f * size0.Height);

            stageObjs["Two_0"].Coordinate = new Vector2(sp + 11.5f * size0.Width, sp + 5.5f * size0.Height);
            stageObjs["Two_1"].Coordinate = new Vector2(sp + 11f * size0.Width, sp + 4f * size0.Height);
            stageObjs["Two_2"].Coordinate = new Vector2(sp + 11f * size0.Width, sp + 7f * size0.Height);

            base.Initialize();
        }

        public override void PreLoadContent()
        {
            new Wall(graphicsDevice, this, "wall00");
            new Wall(graphicsDevice, this, "wall01");
            new Wall(graphicsDevice, this, "wall02");
            new Wall(graphicsDevice, this, "wall03");
            new Wall(graphicsDevice, this, "wall04");
            new Wall(graphicsDevice, this, "wall05");

            new Niddle(graphicsDevice, this, "niddle00");
            new Niddle(graphicsDevice, this, "niddle01");
            new Niddle(graphicsDevice, this, "niddle02");
            new Niddle(graphicsDevice, this, "niddle03");

            new PanicArea(graphicsDevice, this, "panicarea00");
            new PanicArea(graphicsDevice, this, "panicarea01");

            new Item(graphicsDevice, this, "item00");
            new Item(graphicsDevice, this, "item01");
            new Item(graphicsDevice, this, "item02");

            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            stageObjs["field"].Image = ImageManage.GetSImage("field.png");
            stageObjs["field"].Color = Color.YellowGreen;
            Color c = Color.Peru;
            stageObjs["border_top"].Color = c;
            stageObjs["border_left"].Color = c;
            stageObjs["border_right"].Color = c;
            stageObjs["border_bottom"].Color = c;
            var im = ImageManage.GetSImage("stageborder.png");
            stageObjs["border_top"].Image = im;
            stageObjs["border_left"].Image = im;
            stageObjs["border_right"].Image = im;
            stageObjs["border_bottom"].Image = im;
            base.LoadContent();
        }
    }
}
