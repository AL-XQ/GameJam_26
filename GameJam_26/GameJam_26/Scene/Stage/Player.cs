using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using InfinityGame.Def;

namespace GameJam_26.Scene.Stage
{
    public class Player
    {
        private PlayerIndex index;
        private Base_Stage stage;
        private List<ConChara> charas = new List<ConChara>();
        private ConChara foucs;

        public PlayerIndex Index { get => index; }
        public List<ConChara> Charas { get => charas; }
        public ConChara Foucs { get => foucs; }
        public Player(PlayerIndex index, Base_Stage stage)
        {
            this.index = index;
            this.stage = stage;
        }

        public void Initialize()
        {
            if (index == 0)
            {
                charas[0].Coordinate = new Vector2(IGConfig.screen.Height / 25 + 10, IGConfig.screen.Height / 25 + 10);
                charas[1].Coordinate = new Vector2(IGConfig.screen.Height / 25 + 10, IGConfig.screen.Height / 2 - charas[1].Size.Height / 2);
                charas[2].Coordinate = new Vector2(IGConfig.screen.Height / 25 + 10, IGConfig.screen.Height - IGConfig.screen.Height / 25 - charas[1].Size.Height - 10);
            }
            else
            {
                charas[0].Coordinate = new Vector2(IGConfig.screen.Width - IGConfig.screen.Height / 25 - charas[0].Size.Width - 10, IGConfig.screen.Height / 25 + 10);
                charas[1].Coordinate = new Vector2(IGConfig.screen.Width - IGConfig.screen.Height / 25 - charas[1].Size.Width - 10, IGConfig.screen.Height / 2 - charas[1].Size.Height / 2);
                charas[2].Coordinate = new Vector2(IGConfig.screen.Width - IGConfig.screen.Height / 25 - charas[2].Size.Width - 10, IGConfig.screen.Height - IGConfig.screen.Height / 25 - charas[1].Size.Height - 10);
            }
        }

        public void PreLoadContent()
        {
            for (int i = 0; i < 3; i++)
            {
                charas.Add(new ConChara(stage.GraphicsDevice, stage, index.ToString() + "_" + i.ToString(), this));
            }
        }

        public void LoadContent()
        {

        }

        public bool Update(GameTime gameTime)
        {
            return false;
        }
    }
}
