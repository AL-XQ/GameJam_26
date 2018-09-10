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
        private int t_timedown = 15 * 60;
        private float resistance = 0.008f;
        private float g_v = 2f;
        private bool gameOver = false;

        public List<ConChara> charas = new List<ConChara>();
        public List<Item> items = new List<Item>();
        public float runf = 0;
        public int Pl_Index { get => pl_index; set => pl_index = value; }
        public int Turn { get => turn; }
        public int Timedown { get => timedown; }
        /// <summary>
        /// 抵抗力
        /// </summary>
        public float Resistance { get => resistance; }
        /// <summary>
        /// GameJam専用重力
        /// </summary>
        public float G_V { get => g_v; }
        public Base_Stage(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            EndOfLeftUp = new Point(0, 0);
            EndOfRightDown = IGConfig.screen.ToPoint();
        }
        public override void Initialize()
        {
            turn = 12;
            turnstate = 0;
            gameOver = false;
            pl_index = rnd.Next(2);
            timedown = t_timedown;
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
            if (!gameOver)
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
                    if (timedown > 0)
                        timedown--;
                    if (players[pl_index].Update(gameTime) || timedown == 0)
                    {
                        players[pl_index].TrunReset();
                        turnstate = 1;
                    }
                }
                else if (turnstate == 1 && runf == 0)
                    ChangeTurn();
                if (turn <= 0)
                    gameOver = true;
            }
            foreach (var l in players)
            {
                l.FreeUpdate(gameTime);
            }
            base.Update(gameTime);
        }

        private void ChangeTurn()
        {
            timedown = t_timedown;
            ChangePlayer();
            turn--;
            turnstate = 0;
            ((PlayScene)StageScene).ChangeTrun(pl_index);
        }

        public void ChangePlayer()
        {
            switch (pl_index)
            {
                case 0:
                    players[0].ResetV();
                    pl_index = 1;
                    break;
                case 1:
                    players[1].ResetV();
                    pl_index = 0;
                    break;
                case 2:
                    players[0].ResetV();
                    pl_index = 0;
                    break;
                case 3:
                    players[1].ResetV();
                    pl_index = 1;
                    break;
                default:
                    players[0].ResetV();
                    players[1].ResetV();
                    pl_index = 0;
                    break;
            }
        }
    }
}
