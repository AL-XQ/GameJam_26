using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.UI.UIContent;
using InfinityGame.UI;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Element;
using Microsoft.Xna.Framework;
using InfinityGame;
namespace GameJam_26.Scene.UI
{
    public class Ending : UIWindow
    {
        private Label end;
        public Ending(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
            //visible = false;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        private void RegistEvent()
        {
            
            
        }
        public override void PreLoadContent()
        {
            end = new Label(graphicsDevice, this);
            end.TextSize = 48f;
            end.Size = new Size(Size.Width * 4 / 5, Size.Height * 1 / 4);
            RegistEvent();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            end.Location = new Point(size.Width / 2 - end.Size.Width / 2, 60);
            end.Text = GetText("Ending");
            end.TextAlign = ContentAlignment.MiddleCenter;
            base.LoadContent();
        }

    }
}
