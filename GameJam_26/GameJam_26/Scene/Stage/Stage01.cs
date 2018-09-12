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
            Vector2 size_b = new Vector2(ms.Width / 12f, ms.Height / 12f);//横と縦を12分
            Size size0 = new Size((int)size_b.X, (int)size_b.Y);
            Size size1 = new Size((int)size_b.X, (int)(size_b.Y * 2));
            Size size2 = new Size((int)(size_b.X * 4), (int)size_b.Y);
            Size size3 = new Size((int)(size_b.X * 2), (int)(size_b.Y * 4));

            stageObjs["wall00"].Size = size0;
            stageObjs["wall01"].Size = size0;
            stageObjs["niddle00"].Size = size0;
            stageObjs["niddle01"].Size = size0;
            stageObjs["wall02"].Size = size1;
            stageObjs["wall03"].Size = size1;
            stageObjs["wall04"].Size = size1;
            stageObjs["wall05"].Size = size1;
            stageObjs["bendingarea00"].Size = size2;
            stageObjs["bendingarea01"].Size = size2;
            stageObjs["panicarea00"].Size = size3;
            stageObjs["panicarea01"].Size = size3;

            stageObjs["wall00"].Coordinate = new Vector2(sp + 11 * size_b.X, sp);
            stageObjs["wall01"].Coordinate = new Vector2(sp, sp + 11 * size_b.Y);
            stageObjs["niddle00"].Coordinate = new Vector2(sp, sp);
            stageObjs["niddle01"].Coordinate = new Vector2(sp + 11 * size_b.X, sp + 11 * size_b.Y);
            stageObjs["wall02"].Coordinate = new Vector2(sp + 3 * size_b.X, sp + 2 * size_b.Y);
            stageObjs["wall03"].Coordinate = new Vector2(sp + 8 * size_b.X, sp + 2 * size_b.Y);
            stageObjs["wall04"].Coordinate = new Vector2(sp + 3 * size_b.X, sp + 8 * size_b.Y);
            stageObjs["wall05"].Coordinate = new Vector2(sp + 8 * size_b.X, sp + 8 * size_b.Y);
            stageObjs["bendingarea00"].Coordinate = new Vector2(sp + 4 * size_b.X, sp + 2 * size_b.Y);
            stageObjs["bendingarea01"].Coordinate = new Vector2(sp + 4 * size_b.X, sp + 9 * size_b.Y);
            stageObjs["panicarea00"].Coordinate = new Vector2(sp + 2 * size_b.X, sp + 4 * size_b.Y);
            stageObjs["panicarea01"].Coordinate = new Vector2(sp + 8 * size_b.X, sp + 4 * size_b.Y);

            stageObjs["item00"].Coordinate = new Vector2(sp + 5.5f * size_b.X, sp + 0.5f * size_b.Y);
            stageObjs["item01"].Coordinate = new Vector2(sp + 5.5f * size_b.X, sp + 5.5f * size_b.Y);
            stageObjs["item02"].Coordinate = new Vector2(sp + 5.5f * size_b.X, sp + 10.5f * size_b.Y);

            stageObjs["One_0"].Coordinate = new Vector2(sp + 0.5f * size_b.X, sp + 5.5f * size_b.Y);
            stageObjs["One_1"].Coordinate = new Vector2(sp + 1f * size_b.X, sp + 4f * size_b.Y);
            stageObjs["One_2"].Coordinate = new Vector2(sp + 1f * size_b.X, sp + 7f * size_b.Y);

            stageObjs["Two_0"].Coordinate = new Vector2(sp + 11f * size_b.X, sp + 5.5f * size_b.Y);
            stageObjs["Two_1"].Coordinate = new Vector2(sp + 10.5f * size_b.X, sp + 4f * size_b.Y);
            stageObjs["Two_2"].Coordinate = new Vector2(sp + 10.5f * size_b.X, sp + 7f * size_b.Y);

            ((BendingArea)stageObjs["bendingarea00"]).Power = new Vector2(0, 0.5f);
            ((BendingArea)stageObjs["bendingarea01"]).Power = new Vector2(0, -0.5f);

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
            new BendingArea(graphicsDevice, this, "bendingarea00");
            new BendingArea(graphicsDevice, this, "bendingarea01");

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
