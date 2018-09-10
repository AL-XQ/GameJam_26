using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam_26.Scene.Stage
{
    public class Mark : StageField
    {
        private float rotation;

        public float Rotation { get => rotation; set => rotation = value; }

        public Mark(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {

        }

        public override void Initialize()
        {
            rotation = 0.0f;
            base.Initialize();
        }

        public override void Draw2(GameTime gameTime)
        {
            if (Image != null)
            {
                if (DrawLocation.X <= Stage.StageScene.Size.Width && DrawLocation.Y <= Stage.StageScene.Size.Height)
                {
                    if (DrawLocation.X >= -Size.Width && DrawLocation.Y >= -Size.Height)
                    {
                        spriteBatch.Draw(Image.ImageT[iTIndex], new Rectangle(DrawLocation, Size.ToPoint()), new Rectangle(new Point(0, 0), new Point(image.Image.Size.Width, image.Image.Size.Height)), Color * refract, rotation, new Vector2(image.Image.Size.Width / 2, image.Image.Size.Height / 2), SpriteEffects.None, 0);
                    }
                }
            }
        }
    }
}
