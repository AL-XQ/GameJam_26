using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Stage.StageObject.Block;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Def;

using InfinityGame.Device;
using InfinityGame.Element;

namespace GameJam_26.Scene.Stage
{
    public class Base_Stage : BaseStage
    {
        private int turn = 12;
        private int turnstate = 0;
        private List<Player> players = new List<Player>();
        private int pl_index = 0;
        private Random rnd = new Random();
        private int timedown = 15 * 60;

        public List<ConChara> charas = new List<ConChara>();
        public List<Item> items = new List<Item>();
        public float runf = 0;
        public int Pl_Index { get => pl_index; }
        public int Turn { get => turn; }
        public Base_Stage(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            EndOfLeftUp = new Point(0, 0);
            EndOfRightDown = IGConfig.screen.ToPoint();
        }
        public override void Initialize()
        {
            pl_index = rnd.Next(2);
            foreach (var l in players)
            {
                l.Initialize();
            }
            base.Initialize();
        }
        public override void PreLoadContent()
        {
            var sf = new StageField(graphicsDevice, this, "field");
            new StageBorder(graphicsDevice, this, "border_top");
            new StageBorder(graphicsDevice, this, "border_left");
            new StageBorder(graphicsDevice, this, "border_right");
            new StageBorder(graphicsDevice, this, "border_bottom");
            sf.Size = IGConfig.screen;
            stageObjs["border_top"].Size = new Size(sf.Size.Width, sf.Size.Height / 25);
            stageObjs["border_left"].Size = new Size(sf.Size.Height / 25, sf.Size.Height - sf.Size.Height * 2 / 25);//WidthをHeightのままにデザイン
            stageObjs["border_bottom"].Size = stageObjs["border_top"].Size;
            stageObjs["border_right"].Size = stageObjs["border_left"].Size;

            stageObjs["border_left"].Coordinate = new Vector2(0, sf.Size.Height / 25);
            stageObjs["border_right"].Coordinate = new Vector2(sf.Size.Width - sf.Size.Height / 25, sf.Size.Height / 25);
            stageObjs["border_bottom"].Coordinate = new Vector2(0, sf.Size.Height - sf.Size.Height / 25);

            players.Add(new Player(PlayerIndex.One, this));
            players.Add(new Player(PlayerIndex.Two, this));
            foreach (var l in players)
            {
                l.PreLoadContent();
            }
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            foreach (var l in players)
            {
                l.LoadContent();
            }
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            runf = 0;
            foreach (var l in charas)
            {
                runf += l.Speed.Length();
            }
            foreach (var l in items)
            {
                runf += l.Speed.Length();
            }
            if (turnstate == 0)
            {
                timedown--;
                if (players[pl_index].Update(gameTime) || timedown == 0)
                    turnstate = 1;
            }
            if (turnstate == 1 && runf == 0)
                ChangeTurn();
            base.Update(gameTime);
        }

        private void ChangeTurn()
        {
            switch (pl_index)
            {
                case 0:
                    pl_index = 1;
                    break;
                case 1:
                    pl_index = 0;
                    break;
                default:
                    pl_index = 0;
                    break;
            }
            turn--;
            turnstate = 0;
        }
    }
}
