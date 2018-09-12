using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.GameGraphics;
using InfinityGame.Scene;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using InfinityGame.Element;
using InfinityGame.Device;

using StrikeWars.Scene.UI;

namespace StrikeWars.Scene
{
    public class TitleScene : BaseScene
    {
        private MainMenu mainMeun;
        private StageSelect stageSelect;
        private Panel title;
        private Cridit cridit;

        public StageSelect StageSelect { get => stageSelect; }
        public Cridit Cridit { get => cridit; set => cridit = value; }

        public TitleScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            mainMeun = new MainMenu(graphicsDevice, this);
            mainMeun.Size = new Size(size.Width * 2 / 7, size.Height / 3);
            mainMeun.Location = new Point(size.Width / 2 - mainMeun.Size.Width / 2, size.Height * 2 / 3);
            cridit = new Cridit(graphicsDevice, this);
            cridit.Size = size / 2;
            cridit.Location = ((size - cridit.Size) / 2).ToPoint();
            stageSelect = new StageSelect(graphicsDevice, this);
            
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("titlescene.jpg");
            sounds.Add("open", SoundManage.GetSound("open.wav"));
            sounds["open"].SetSELoopPlay(true);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (IsRun && sounds["open"].GetState(Microsoft.Xna.Framework.Audio.SoundState.Stopped))
                sounds["open"].Play();
            base.Update(gameTime);
        }
    }
}
