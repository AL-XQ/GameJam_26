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
    class Stage02 : Base_Stage
    {
        public Stage02(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {

        }
        public override void Initialize()
        {
            Size sc = IGConfig.screen;
            Size ms = sc;
            int sp = ms.Height / 25;
            ms -= new Size(sp * 2, sp * 2);
            Vector2 size_b = new Vector2(ms.Width / 12f, ms.Height / 12f);//横と縦を12分
            Size size0 = new Size((int)size_b.X, (int)size_b.Y);//横と縦を12分　トゲと壁
            Size size1 = new Size((int)size_b.X, (int)size_b.Y * 2);//パニックエリア
            Size size2 = new Size((int)size_b.X, (int)size_b.Y * 11);//ベンディングエリア
            Size size3 = new Size((int)size_b.X / 2, (int)size_b.Y * 2);

            stageObjs["wall00"].Size = size3;
            stageObjs["wall01"].Size = size3;
            stageObjs["bendingarea02"].Size = size0;
            stageObjs["bendingarea03"].Size = size0;


            stageObjs["panicarea00"].Size = size1;
            stageObjs["panicarea01"].Size = size1;
            stageObjs["panicarea02"].Size = size1;
            stageObjs["panicarea03"].Size = size1;

            stageObjs["bendingarea00"].Size = size2;
            stageObjs["bendingarea01"].Size = size2;

            stageObjs["wall00"].Coordinate = new Vector2(sp + 0.75f * size_b.X, sp + 5.0f * size_b.Y);
            stageObjs["wall01"].Coordinate = new Vector2(sp + 10.75f * size_b.X, sp + 5.0f * size_b.Y);
            stageObjs["bendingarea02"].Coordinate = new Vector2(sp + 5.525f * size_b.X, sp + 0.75f * size_b.Y);
            stageObjs["bendingarea03"].Coordinate = new Vector2(sp + 5.525f * size_b.X, sp + 10.4f * size_b.Y);


            stageObjs["panicarea00"].Coordinate = new Vector2(sp + 0.5f * size_b.X, sp + 1.6f * size_b.Y);
            stageObjs["panicarea01"].Coordinate = new Vector2(sp + 0.5f * size_b.X, sp + 8.5f * size_b.Y);
            stageObjs["panicarea02"].Coordinate = new Vector2(sp + 10.5f * size_b.X, sp + 1.6f * size_b.Y);
            stageObjs["panicarea03"].Coordinate = new Vector2(sp + 10.5f * size_b.X, sp + 8.5f * size_b.Y);

            stageObjs["bendingarea00"].Coordinate = new Vector2(sp + 2f * size_b.X, sp + 0.59f * size_b.Y);
            stageObjs["bendingarea01"].Coordinate = new Vector2(sp + 9f * size_b.X, sp + 0.59f * size_b.Y);

            stageObjs["item00"].Coordinate = new Vector2(sp + 0.7f * size_b.X, sp + 0.25f * size_b.Y);
            stageObjs["item01"].Coordinate = new Vector2(sp + 0.7f * size_b.X, sp + 10.5f * size_b.Y);
            stageObjs["item02"].Coordinate = new Vector2(sp + 10.7f * size_b.X, sp + 0.25f * size_b.Y);
            stageObjs["item03"].Coordinate = new Vector2(sp + 10.7f * size_b.X, sp + 10.5f * size_b.Y);
            stageObjs["item04"].Coordinate = new Vector2(sp + 5.725f * size_b.X, sp + 5.25f * size_b.Y);

            stageObjs["One_0"].Coordinate = new Vector2(sp + 4.75f * size_b.X, sp + 4.0f * size_b.Y);
            stageObjs["One_1"].Coordinate = new Vector2(sp + 4.5f * size_b.X, sp + 5.25f * size_b.Y);
            stageObjs["One_2"].Coordinate = new Vector2(sp + 4.75f * size_b.X, sp + 6.5f * size_b.Y);

            stageObjs["Two_0"].Coordinate = new Vector2(sp + 6.75f * size_b.X, sp + 4.0f * size_b.Y);
            stageObjs["Two_1"].Coordinate = new Vector2(sp + 7f * size_b.X, sp + 5.25f * size_b.Y);
            stageObjs["Two_2"].Coordinate = new Vector2(sp + 6.75f * size_b.X, sp + 6.5f * size_b.Y);

            ((BendingArea)stageObjs["bendingarea00"]).Power = new Vector2(0.5f, 0);
            stageObjs["bendingarea00"].Image = ImageManage.GetSImage("b_right.png");
            ((BendingArea)stageObjs["bendingarea01"]).Power = new Vector2(-0.5f, 0);
            stageObjs["bendingarea01"].Image = ImageManage.GetSImage("b_left.png");
            ((BendingArea)stageObjs["bendingarea02"]).Power = new Vector2(0, 0.5f);
            stageObjs["bendingarea02"].Image = ImageManage.GetSImage("b_down.png");
            ((BendingArea)stageObjs["bendingarea03"]).Power = new Vector2(0, -0.5f);
            stageObjs["bendingarea03"].Image = ImageManage.GetSImage("b_up.png");

            base.Initialize();
        }
        public override void PreLoadContent()
        {
            new Wall(graphicsDevice, this, "wall00");
            new Wall(graphicsDevice, this, "wall01");

            new BendingArea(graphicsDevice, this, "bendingarea02");
            new BendingArea(graphicsDevice, this, "bendingarea03");


            new PanicArea(graphicsDevice, this, "panicarea00");
            new PanicArea(graphicsDevice, this, "panicarea01");
            new PanicArea(graphicsDevice, this, "panicarea02");
            new PanicArea(graphicsDevice, this, "panicarea03");

            new BendingArea(graphicsDevice, this, "bendingarea00");
            new BendingArea(graphicsDevice, this, "bendingarea01");

            new Item(graphicsDevice, this, "item00");
            new Item(graphicsDevice, this, "item01");
            new Item(graphicsDevice, this, "item02");
            new Item(graphicsDevice, this, "item03");
            new Item(graphicsDevice, this, "item04");

            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            stageObjs["field"].Image = ImageManage.GetSImage("stage02.png");
            stageObjs["border_top"].Image = ImageManage.GetSImage("border_up.png");
            stageObjs["border_left"].Image = ImageManage.GetSImage("border_left.png");
            stageObjs["border_right"].Image = ImageManage.GetSImage("border_right.png");
            stageObjs["border_bottom"].Image = ImageManage.GetSImage("border_down.png");
            base.LoadContent();
        }
    }
}
