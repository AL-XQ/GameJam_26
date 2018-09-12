using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
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
        }

        public override void PreLoadContent()
        {
            ms = new Label(graphicsDevice, this);
            ms.TextSize = 24f;
            ms.Text = GetText("cdt");
            base.PreLoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (visible && IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Back))
                Visible = false;
            base.Update(gameTime);
        }
    }
}
