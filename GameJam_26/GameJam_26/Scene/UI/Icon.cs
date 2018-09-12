using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.UI.UIContent;
using InfinityGame.Element;
using InfinityGame.Device;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameJam_26.Scene.Stage;
using InfinityGame;
using InfinityGame.Scene;

namespace GameJam_26.Scene.UI
{
    public partial class Icon : AnimeButton
    {
        private SImage border;
        private bool showBorder;
        private string stage;

        public bool ShowBorder { get { return showBorder; } set { showBorder = value; } }

        public string Stage { get => stage; set => stage = value; }

        public Icon(GraphicsDevice aGraphicsDevice, BaseDisplay aParent) : base(aGraphicsDevice, aParent)
        {
            imageEntity.Enable = false;
            CanMove = false;
            backColor = Color.Transparent;
        }

        public override void PreLoadContent()
        {
            TextSize = 14f;
            TextAlign = ContentAlignment.BottomCenter;
            Size = new Size(100, 100);
            EventRegist();
            base.PreLoadContent();
        }

        private void EventRegist()
        {
            Enter += ShowB;
            Leave += NotShowB;
            Click += I_Click;
        }

        public override void LoadContent()
        {
            border = ImageManage.GetSImage("iconborder.png");
            base.LoadContent();
        }

        public override void Draw2(GameTime gameTime)
        {
            if (showBorder)
                spriteBatch.Draw(border.ImageT[0], new Rectangle(DrawLocation, size.ToPoint()), Color * refract);
            base.Draw2(gameTime);
        }

        private void ShowB(object sender, EventArgs e)
        {
            showBorder = true;
        }

        private void NotShowB(object sender, EventArgs e)
        {
            showBorder = false;
        }

        private void I_Click(object sender, EventArgs e)
        {
            var sc = GameRun.Instance.scenes;
            ((StageScene)sc["play"]).ShowStage = ((StageScene)sc["play"]).stages[stage];
            ((StageScene)sc["play"]).stages[stage].Initialize();
            sc["title"].IsRun = false;
            sc["play"].IsRun = true;
        }
    }
}
