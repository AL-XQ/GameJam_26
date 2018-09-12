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
using InfinityGame.Device;

namespace GameJam_26.Scene.UI
{
    public class Ending : UIWindow
    {
        private Panel end;
        private List<Panel> charas = new List<Panel>();
        public Ending(GraphicsDevice aGraphicsDevice, BaseDisplay parent) : base(aGraphicsDevice, parent)
        {
            BorderOn = false;
            CanClose = false;
            CanMove = false;
            backColor = Color.Transparent;
        }
        public override void Initialize()
        {
            visible = false;
            base.Initialize();
        }
        private void RegistEvent()
        {


        }
        public override void PreLoadContent()
        {
            for (int i = 0; i < 3; i++)
            {
                charas.Add(new Panel(graphicsDevice, this));
            }
            for (int i = 0; i < 3; i++)
            {
                charas[i].Color = Color.Transparent;
                charas[i].Size = new Size(200, 200);
                charas[i].Location = new Point(size.Width / 2 - charas[i].Size.Width / 2 - 200 + i * 210, 250);
            }
            end = new Panel(graphicsDevice, this);
            end.Size = new Size(Size.Width * 4 / 5, Size.Height * 1 / 4);
            end.BackColor = Color.Transparent;
            RegistEvent();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            end.Location = new Point(size.Width / 2 - end.Size.Width / 2, 100);
            Image = ImageManage.GetSImage("window.png");
            base.LoadContent();
        }

        public void ShowEnding(Dictionary<string, object> args)
        {
            int w = (int)args["winner"];
            switch (w)
            {
                case -1:
                    end.Image = ImageManage.GetSImage("draw.png");
                    break;
                case 0:
                    end.Image = ImageManage.GetSImage("1pWIN.png");
                    for (int i = 0; i < 3; i++)
                    {
                        charas[i].Image = ImageManage.GetSImage("chara" + (i + 1).ToString() + ".png");
                    }
                    break;
                case 1:
                    end.Image = ImageManage.GetSImage("2pWIN.png");
                    for (int i = 0; i < 3; i++)
                    {
                        charas[i].Image = ImageManage.GetSImage("chara" + (i + 4).ToString() + ".png");
                    }
                    break;
                default:
                    end.Image = ImageManage.GetSImage("draw.png");
                    break;
            }
            visible = true;
        }

    }
}
