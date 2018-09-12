using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.Device.KeyboardManage;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrikeWars.Scene.UI
{
    public class Cridit : UIWindow
    {
        private Label ms;
        public Cridit(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
            visible = false;
            canMove = false;
            canClose = false;
            BorderOn = false;
            backColor = Color.Transparent;
        }

        public override void PreLoadContent()
        {
            ms = new Label(graphicsDevice, this);
            ms.TextSize = 24f;
            ms.BDText.ForeColor = System.Drawing.Color.Gainsboro;
            ms.Text = "\r\n" +
                "\r\n" +
                "     「StrikeWars」について\r\n" +
                "　　　メインプログラマー兼リーダー：謝　少杰\r\n" +
                "　　　ディレクター：三橋　洋希\r\n" +
                "　　　グラフィック：湯田　将貴\r\n" +
                "　　　　　　　　　　石井　柾希\r\n" +
                "　　　プランナー：山中　凌斗\r\n" +
                "　　　プログラマー：靳　尚卿\r\n" +
                "　　　メンター：林　佳叡\r\n" +
                "　　　　　　　　朝倉　大夢\r\n";
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("window.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (visible && (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Back)) || GameKeyboard.GetKeyTrigger(Keys.Escape))
                Visible = false;
            base.Update(gameTime);
        }
    }
}
