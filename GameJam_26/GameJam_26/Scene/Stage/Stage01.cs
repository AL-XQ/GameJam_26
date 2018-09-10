﻿using System;
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
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            new Wall(graphicsDevice, this, "wall01");
            new Wall(graphicsDevice, this, "wall02");
            new Niddle(graphicsDevice, this, "niddle03");
            new Item(graphicsDevice, this, "item01");
            new Item(graphicsDevice, this, "item02");
            new Item(graphicsDevice, this, "item03");
            new PanicArea(graphicsDevice, this, "paa01");
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
